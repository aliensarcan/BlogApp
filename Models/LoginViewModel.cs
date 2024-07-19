using System.ComponentModel.DataAnnotations; // Data annotations'ı içe aktarır

namespace BlogApp.Models
{
    public class LoginViewModel
    {
        [Required] // Zorunlu alan
        [EmailAddress] // E-posta formatında olmalı
        [Display(Name = "Eposta")] // Görüntülenen ad
        public string? Email { get; set; } // Kullanıcının e-posta adresi

        [Required] // Zorunlu alan
        [StringLength(10, ErrorMessage = "{0} alanı en az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 6)] // Karakter uzunluğu kontrolü
        [DataType(DataType.Password)] // Parola tipi
        [Display(Name = "Parola")] // Görüntülenen ad
        public string? Password { get; set; } // Kullanıcının parolası
    }
}
