namespace TeploBalanceKotelCore.Models
{
    public class VariantUserTverdAddDtoModel
    {
        public int UserId { get; set; }
        public int VariantId { get; set; }


        ///<summary>
        /// Выход пара, кг/с 
        ///</summary>
        public double ParVyh { get; set; }

        ///<summary>
        /// Расход воды на продувку котла, кг/с
        ///</summary>
        public double RashWat { get; set; }

        ///<summary>
        /// Температура питательной воды, °C
        ///</summary>
        public double TempPitWat { get; set; }

        ///<summary>
        /// Температура нагретого пара, °C
        ///</summary>
        public double TempHeatWat { get; set; }
        ///<summary>
        /// Давление внутри барабана, Па
        ///</summary>
        public double Pressure { get; set; }

        ///<summary>
        /// Температура рабочего топлива, °C
        ///</summary>
        public double TempRabT { get; set; }

        ///<summary>
        /// Содержание водорода, рабочая масса, %
        ///</summary>
        public double SodH { get; set; }
        ///<summary>
        /// Содержание кислорода, рабочая масса, %
        ///</summary>
        public double SodO { get; set; }

        ///<summary>
        /// Содержание углерода, рабочая масса, %
        ///</summary>
        public double SodC { get; set; }
        ///<summary>
        /// Содержание серы, рабочая масса, %
        ///</summary>
        public double SodS { get; set; }

        ///<summary>
        /// Содержание водяных паров, рабочая масса, %
        ///</summary>
        public double SodWP { get; set; }

        ///<summary>
        /// Коэффициент избытка воздуха, %
        ///</summary>
        public double Alpha { get; set; }

        ///<summary>
        /// Температура воздуха, °C
        ///</summary>
        public double TempVozd { get; set; }

        ///<summary>
        /// Температура уходящих газов, °C
        ///</summary>
        public double TempOut { get; set; }
        ///<summary>
        /// Величина химической неполноты сгорания топлива, %
        ///</summary>
        public double QChem { get; set; }

        ///<summary>
        /// Величина механической неполноты сгорания топлива, %
        ///</summary>
        public double QMech { get; set; }

        ///<summary>
        /// Величина потерь тепла от наружного охлаждения, %
        ///</summary>
        public double QCold { get; set; }

        ///<summary>
        /// Величина потерь тепла с физическим теплом шлаков, %
        ///</summary>
        public double QWarm { get; set; }
    }

}

