using CQRSProject.Entities;

namespace CQRSProject.Patterns.ChainOfResponsibility
{
    public abstract class OrderValidatorBase : IOrderValidator
    {
        private IOrderValidator _nextValidator;

        public IOrderValidator SetNext(IOrderValidator next)
        {
            _nextValidator = next;
            return next;
        }

        public async Task<ValidationResult> ValidateAsync(Order order)
        {
            var result = await DoValidateAsync(order);
            if (!result.IsValid)
            {
                return result;
            }

            if (_nextValidator != null)
            {
                return await _nextValidator.ValidateAsync(order);
            }

            return ValidationResult.Success();
        }

        protected abstract Task<ValidationResult> DoValidateAsync(Order order);
    }
}
