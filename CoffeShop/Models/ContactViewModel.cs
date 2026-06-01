using System.ComponentModel.DataAnnotations;

namespace CoffeShop.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên của bạn")]
        [Display(Name = "Your name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Your email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập tin nhắn")]
        [Display(Name = "Message")]
        public string Message { get; set; } = string.Empty;
    }
}
