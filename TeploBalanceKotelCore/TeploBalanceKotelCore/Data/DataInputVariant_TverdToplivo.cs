
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TeploBalanceKotelCore.Data
{
    public class DataInputVariant_TverdToplivo
    {
        /// <summary>
        /// ID набора исходных данных варианта расчета пользователя
        /// </summary>
        [Key]
        public int ID_DataInputVariant_TverdToplivo { get; set; }

        /// <summary>
        /// ID варианта расчета
        /// </summary>
        [ForeignKey(nameof(VarTverdToplivo))]
        public int ID_Variant_TverdToplivo { get; set; }
        /// <summary>
        /// ID пользователя
        /// </summary>
        [ForeignKey(nameof(User))]
        public int OwnerID_User { get; set; }

        //Имя расчета
        [Required]
        public string Variant_TverdToplivoId_Variant    { get; set; }

        /// <summary>
        /// Выход пара, кг/с
        /// </summary>        
        [Display(Name = "ParVyh")]
        public double ParVyh { get; set; }

        /// <summary>
        /// Расход воды на продувку котла, кг/с
        /// </summary>        
        [Display(Name = "RashWat")]
        public double RashWat { get; set; }

        /// <summary>
        /// Температура питательной воды, °С
        /// </summary>        
        [Display(Name = "TempPitWat")]
        public double TempPitWat { get; set; }

        /// <summary>
        /// Температура нагретого пара, °С
        /// </summary>        
        [Display(Name = "TempHeatWat")]
        public double TempHeatWat { get; set; }

        /// <summary>
        /// Давление внутри барабана, атм
        /// </summary>        
        [Display(Name = "Pressure")]
        public double Pressure { get; set; }

        /// <summary>
        /// Температура рабочего топлива, °С
        /// </summary>        
        [Display(Name = "TempRabT")]
        public double TempRabT { get; set; }

        /// <summary>
        /// Содержание водорода, рабочая масса, %
        /// </summary>        
        [Display(Name = "SodH")]
        public double SodH { get; set; }

        /// <summary>
        /// Содержание углерода, рабочая масса, %
        /// </summary>        
        [Display(Name = "SodC")]
        public double SodC { get; set; }

        /// <summary>
        /// Содержание кислорода, рабочая масса, %
        /// </summary>        
        [Display(Name = "SodO")]
        public double SodO { get; set; }

        /// <summary>
        /// Содержание серы, рабочая масса, %
        /// </summary>        
        [Display(Name = "SodS")]
        public double SodS { get; set; }

        /// <summary>
        /// Содержание водяных паров, рабочая масса, %
        /// </summary>        
        [Display(Name = "SodWP")]
        public double SodWP { get; set; }

        /// <summary>
        /// Коэффициент избытка воздуха, ед.
        /// </summary>        
        [Display(Name = "Alpha")]
        public double Alpha { get; set; }

        /// <summary>
        /// Температура воздуха, °С
        /// </summary>        
        [Display(Name = "TempVozd")]
        public double TempVozd { get; set; }

        /// <summary>
        /// Температура уходящих газов, °С
        /// </summary>        
        [Display(Name = "TempOut")]
        public double TempOut { get; set; }

        /// <summary>
        /// Величина химической неполноты сгорания топлива, %
        /// </summary>        
        [Display(Name = "QChem")]
        public double QChem { get; set; }

        /// <summary>
        /// Величина механической неполноты сгорания топлива, %
        /// </summary>        
        [Display(Name = "QMech")]
        public double QMech { get; set; }

        /// <summary>
        ///Заряд наружного охлаждения
        /// </summary>        
        [Display(Name = "QCold")]
        public double QCold { get; set; }

        /// <summary>
        ///Величина потерь тепла от наружного охлаждения, %
        /// </summary>        
        [Display(Name = "QWarm")]
        public double QWarm { get; set; }
        public VarTverdToplivo VariantsTverdToplivo { get; set; }
        public User Owner { get; set; }
    }
}
