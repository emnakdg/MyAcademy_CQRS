using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.OrderCommands;
using CQRSProject.Entities;
using CQRSProject.Patterns.ChainOfResponsibility;
using CQRSProject.Patterns.ChainOfResponsibility.Validators;
using CQRSProject.Patterns.Observer;
using CQRSProject.Patterns.Observer.Events;
using CQRSProject.Patterns.UnitOfWork;

namespace CQRSProject.CQRSPattern.Handlers.OrderHandlers
{
    public class CreateOrderCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventPublisher _eventPublisher;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
        {
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
        }

        public async Task<(bool Success, string ErrorMessage, int? OrderId)> Handle(CreateOrderCommand command)
        {
            var order = new Order
            {
                CustomerName = command.CustomerName,
                CustomerEmail = command.CustomerEmail,
                CustomerPhone = command.CustomerPhone,
                ShippingAddress = command.ShippingAddress,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
                OrderItems = command.OrderItems.Select(x => new OrderItem
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice
                }).ToList()
            };
            order.TotalAmount = order.OrderItems.Sum(x => x.Quantity * x.UnitPrice);

            var customerValidator = new CustomerValidator();
            var itemsValidator = new OrderItemsValidator();
            var totalValidator = new TotalAmountValidator();

            customerValidator.SetNext(itemsValidator).SetNext(totalValidator);

            var validationResult = await customerValidator.ValidateAsync(order);
            if (!validationResult.IsValid)
            {
                return (false, validationResult.ErrorMessage, null);
            }

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _unitOfWork.Repository<Order>().AddAsync(order);
                await _unitOfWork.CommitAsync();

                await _eventPublisher.PublishAsync(new OrderCreatedEvent(order));

                return (true, null, order.Id);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return (false, ex.Message, null);
            }
        }
    }
}
