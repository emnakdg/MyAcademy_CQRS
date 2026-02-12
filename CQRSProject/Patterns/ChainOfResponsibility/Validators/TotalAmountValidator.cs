using CQRSProject.Entities;

namespace CQRSProject.Patterns.ChainOfResponsibility.Validators
{
    public class TotalAmountValidator : OrderValidatorBase
    {
        private const decimal MinimumOrderAmount = 10.00m;

        protected override Task<ValidationResult> DoValidateAsync(Order order)
        {
            if (order.TotalAmount <= 0)
            {
                return Task.FromResult(ValidationResult.Failure("Sipariş tutarı 0'dan büyük olmalıdır."));
            }

            if (order.TotalAmount < MinimumOrderAmount)
            {
                return Task.FromResult(ValidationResult.Failure($"Minimum sipariş tutarı {MinimumOrderAmount:C} olmalıdır."));
            }

            var calculatedTotal = order.OrderItems?.Sum(x => x.Quantity * x.UnitPrice) ?? 0;
            if (Math.Abs(calculatedTotal - order.TotalAmount) > 0.01m)
            {
                return Task.FromResult(ValidationResult.Failure("Sipariş tutarı ürün toplamlarıyla uyuşmuyor."));
            }

            return Task.FromResult(ValidationResult.Success());
        }
    }
}
