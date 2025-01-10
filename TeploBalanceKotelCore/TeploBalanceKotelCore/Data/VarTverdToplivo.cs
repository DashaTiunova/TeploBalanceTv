
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeploBalanceKotelCore.Data
{
    public class VarTverdToplivo
    {
        /// <summary>
        /// ID расчета
        /// </summary>
        [Key]
        public int VarTverd_Toplivo_ID { get; set; }

        /// <summary>
        /// Дата расчета
        /// </summary>     
        [Required(ErrorMessage = "Вы не заполнили дату выполнения расчета")]
        [Display(Name = "Дата выполнения расчета")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateVariant { get; set; }

        /// <summary>
        /// Название варианта расчета 
        /// </summary>
        
        [Display(Name = "Название варианта")]
        public string? NameVariant_TverdToplivo { get; set; }

        /// <summary>
        /// Комментарий к варианту расчета
        /// </summary>        
        [Display(Name = "Комментарий к  расчету")]
        public string? Description { get; set; }

        [ForeignKey(nameof(User))]
        public int OwnerID_User{ get; set; }
        public User Owner { get; set; }
    }
}
