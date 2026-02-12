using CQRSProject.Entities;

namespace CQRSProject.Patterns.ChainOfResponsibility.Validators
{
    public class CustomerValidator : OrderValidatorBase
    {
        protected override Task<ValidationResult> DoValidateAsync(Order order)
        {
            if (string.IsNullOrWhiteSpace(order.CustomerName))
            {
                return Task.FromResult(ValidationResult.Failure("Müşteri adı boş olamaz."));
            }

            if (string.IsNullOrWhiteSpace(order.CustomerEmail))
            {
                return Task.FromResult(ValidationResult.Failure("Müşteri email adresi boş olamaz."));
            }

            if (string.IsNullOrWhiteSpace(order.CustomerPhone))
            {
                return Task.FromResult(ValidationResult.Failure("Müşteri telefon numarası boş olamaz."));
            }

            if (string.IsNullOrWhiteSpace(order.ShippingAddress))
            {
                return Task.FromResult(ValidationResult.Failure("Teslimat adresi boş olamaz."));
            }

            return Task.FromResult(ValidationResult.Success());
        }
    }
}
