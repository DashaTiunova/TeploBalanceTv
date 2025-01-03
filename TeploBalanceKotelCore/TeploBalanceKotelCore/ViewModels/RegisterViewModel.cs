using System.ComponentModel.DataAnnotations;
using TeploBalanceKotelCore.Data;

namespace TeploBalanceKotelCore.ViewModels
{
    public class RegisterViewModel
    {
   
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required(ErrorMessage = "Вы не ввели имя пользователя")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Вы не ввели почтовый адрес")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Вы не ввели пароль")]
        [StringLength(20)]
        public string Password { get; set; }
    }
}
