using System.ComponentModel.DataAnnotations;

namespace Cw48_2.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Ім'я користувача є обов'язковим")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ім'я має бути від 3 до 50 символів")]
        public string name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email є обов'язковим")]
        [EmailAddress(ErrorMessage = "Некоректний формат Email")]
        public string email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Пароль є обов'язковим")]
        [MinLength(6, ErrorMessage = "Пароль повинен містити щонайменше 6 символів")]
        public string password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Роль є обов'язковою")]
        [RegularExpression("^(Standard|Pro)$", ErrorMessage = "Роль може бути лише 'Standard' або 'Pro'")]
        public string Role { get; set; } = "Standard";
    }
}
