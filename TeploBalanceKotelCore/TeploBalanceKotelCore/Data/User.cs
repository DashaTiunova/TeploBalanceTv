using System.ComponentModel.DataAnnotations;

namespace TeploBalanceKotelCore.Data
{
    public class User
    {
        
        [Key] 
        public int ID_User { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required(ErrorMessage = "Вы не ввели имя пользователя")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        public string Email { get; set; }
        public UserRole Role { get; set; }

        [StringLength(20)]
        public string Password { get; set; }
    }
}
