using CQRSProject.Entities;

namespace CQRSProject.Patterns.ChainOfResponsibility
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

        public static ValidationResult Success() => new ValidationResult { IsValid = true };
        public static ValidationResult Failure(string message) => new ValidationResult { IsValid = false, ErrorMessage = message };
    }

    public interface IOrderValidator
    {
        IOrderValidator SetNext(IOrderValidator next);
        Task<ValidationResult> ValidateAsync(Order order);
    }
}
