namespace RecuperatorCore.Models
{
    public class VariantAddDtoModel
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int UserId { get; set; }
        /// <summary>
        /// Температура воздуха на выходе из рекуператора, °С
        /// </summary>
        public double Temp_Air_Output { get; set; }

        /// <summary>
        /// Температура воздуха на входе в рекуператор, °С
        /// </summary>
        public double Temp_Air_Input { get; set; }

        /// <summary>
        /// Температура продуктов сгорания перед рекуператором, °С
        /// </summary>
        public double Temp_Product_Input { get; set; }

        /// <summary>
        /// Расход воздуха, м3/с
        /// </summary>
        public double Consump_Air { get; set; }

        /// <summary>
        /// Расход продуктов сгорания, м3/с
        /// </summary>
        public double Consump_Product { get; set; }

        /// <summary>
        /// Количество CO2, %
        /// </summary>
        public double Percent_CO2 { get; set; }

        /// <summary>
        /// Количество H2O, %
        /// </summary>
        public double Percent_H2O { get; set; }

        /// <summary>
        /// Справочные данные - радиус секции
        /// </summary>
        public double Radius_Section { get; set; }
    }
}
