using CQRSProject.Entities;

namespace CQRSProject.Patterns.ChainOfResponsibility.Validators
{
    public class OrderItemsValidator : OrderValidatorBase
    {
        protected override Task<ValidationResult> DoValidateAsync(Order order)
        {
            if (order.OrderItems == null || !order.OrderItems.Any())
            {
                return Task.FromResult(ValidationResult.Failure("Sipariş en az bir ürün içermelidir."));
            }

            foreach (var item in order.OrderItems)
            {
                if (item.Quantity <= 0)
                {
                    return Task.FromResult(ValidationResult.Failure("Ürün miktarı 0'dan büyük olmalıdır."));
                }

                if (item.UnitPrice <= 0)
                {
                    return Task.FromResult(ValidationResult.Failure("Ürün fiyatı 0'dan büyük olmalıdır."));
                }
            }

            return Task.FromResult(ValidationResult.Success());
        }
    }
}
