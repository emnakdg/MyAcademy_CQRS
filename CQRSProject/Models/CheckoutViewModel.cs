using System.ComponentModel.DataAnnotations;

namespace CQRSProject.Models
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        [Display(Name = "Ad Soyad")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-posta zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-posta")]
        public string CustomerEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon zorunludur.")]
        [Display(Name = "Telefon")]
        public string CustomerPhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Adres zorunludur.")]
        [Display(Name = "Teslimat Adresi")]
        public string ShippingAddress { get; set; } = string.Empty;

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public decimal TotalAmount => CartItems.Sum(x => x.Total);
    }
}
