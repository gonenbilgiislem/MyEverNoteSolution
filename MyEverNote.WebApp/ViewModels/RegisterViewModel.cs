using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEverNote.WebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} Alanını Boş Geçemessiniz."),StringLength(25,ErrorMessage = "{0} max. {1} karakter olmalıdır.")]
        public string Username { get; set; }

        [Display(Name = "Email Adresi")]
        [Required(ErrorMessage = "{0} Alanını Boş Geçemessiniz."),StringLength(70, ErrorMessage = "{0} max. {1} karakter olmalıdır.")]
        [EmailAddress(ErrorMessage = "Geçerli bir Email adresi giriniz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez"),StringLength(25,ErrorMessage = "{0} max. {1} karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez"),StringLength(25,ErrorMessage = "{0} max. {1} karakter olmalıdır.")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "{0} ile {1} uyuşmuyor")]
        public string RePassword { get; set; }
    }

}