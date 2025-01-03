using RecuperatorLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RecuperatorCore.Models
{
    public class DataInputModel 
    {
        // Создать главный объект, который включает в себя все нужные объекты
        private MathLib _cs = new();

        public DataInputModel() { }

        /// <summary>
        /// Температура воздуха на выходе из рекуператора, °С
        /// </summary>
        private double temp_Air_Output;
        /// <summary>
        /// Температура воздуха на выходе из рекуператора, °С
        /// </summary>
        public double Temp_Air_Output
        {
            get { return temp_Air_Output; }
            set { temp_Air_Output = value; }
        }

        /// <summary>
        /// Температура воздуха на входе в рекуператор, °С
        /// </summary>
        private double temp_Air_Input;
        /// <summary>
        /// Температура воздуха на входе в рекуператор, °С
        /// </summary>
        public double Temp_Air_Input
        {
            get { return temp_Air_Input; }
            set { temp_Air_Input = value; }
        }

        /// <summary>
        /// Температура продуктов сгорания перед рекуператором, °С
        /// </summary>
        private double temp_Product_Input;
        /// <summary>
        /// Температура продуктов сгорания перед рекуператором, °С
        /// </summary>
        public double Temp_Product_Input
        {
            get { return temp_Product_Input; }
            set { temp_Product_Input = value; }
        }

        /// <summary>
        /// Расход воздуха, м3/с
        /// </summary>
        private double consump_Air;
        /// <summary>
        /// Расход воздуха, м3/с
        /// </summary>
        public double Consump_Air
        {
            get { return consump_Air; }
            set { consump_Air = value; }
        }

        /// <summary>
        /// Расход продуктов сгорания, м3/с
        /// </summary>
        private double consump_Product;
        /// <summary>
        /// Расход продуктов сгорания, м3/с
        /// </summary>
        public double Consump_Product
        {
            get { return consump_Product; }
            set { consump_Product = value; }
        }

        /// <summary>
        /// Количество CO2, %
        /// </summary>
        private double percent_CO2;
        /// <summary>
        /// Количество CO2, %
        /// </summary>
        public double Percent_CO2
        {
            get { return percent_CO2; }
            set { percent_CO2 = value; }
        }

        /// <summary>
        /// Количество H2O, %
        /// </summary>
        private double percent_H2O;
        /// <summary>
        /// Количество H2O, %
        /// </summary>
        public double Percent_H2O
        {
            get { return percent_H2O; }
            set { percent_H2O = value; }
        }

        /// <summary>
        /// Справочные данные - радиус секции
        /// </summary>
        private double radius_Section;
        /// <summary>
        /// Справочные данные - радиус секции
        /// </summary>
        public double Radius_Section
        {
            get { return radius_Section; }
            set { radius_Section = value; }
        }
    }
}