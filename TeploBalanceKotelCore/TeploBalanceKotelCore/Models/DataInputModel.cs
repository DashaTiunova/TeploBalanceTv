using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TeploBalanceKotelMathLib;

namespace TeploBalanceKotelCore.Models
{
    public class DataInputModel 
    {
        // Создать главный объект, который включает в себя все нужные объекты
        private GasToplivo _cs = new GasToplivo();

        public DataInputModel() { }

        #region Входные параметры 

        ///<summary>
        /// Выход пара, кг/с 
        ///</summary>
        private double _parVyh;
        ///<summary>
        /// Выход пара, кг/с 
        ///</summary>
        public double ParVyh
        {
            get { return _parVyh; }
            set { _parVyh = value; }
        }

        ///<summary>
        /// Расход воды на продувку котла, кг/с
        ///</summary>
        private double _rashWat;
        ///<summary>
        /// Расход воды на продувку котла, кг/с
        ///</summary>
        public double RashWat
        {
            get { return _rashWat; }
            set { _rashWat = value; }
        }
        ///<summary>
        /// Температура питательной воды, °C
        ///</summary>
        private double _tempPitWat;
        ///<summary>
        /// Температура питательной воды, °C
        ///</summary>
        public double TempPitWat
        {
            get { return _tempPitWat; }
            set { _tempPitWat = value; }
        }

        ///<summary>
        /// Температура нагретого пара, °C
        ///</summary>
        private double _tempHeatWat;
        ///<summary>
        /// Температура нагретого пара, °C
        ///</summary>
        public double TempHeatWat
        {
            get { return _tempHeatWat; }
            set { _tempHeatWat = value; }
        }

        ///<summary>
        /// Давление внутри барабана, Па
        ///</summary>
        private double _pressure;
        ///<summary>
        /// Давление внутри барабана, Па
        ///</summary>
        public double Pressure
        {
            get { return _pressure; }
            set { _pressure = value; }
        }

        ///<summary>
        /// Температура рабочего топлива, °C
        ///</summary>
        private double _tempRabT;
        ///<summary>
        /// Температура рабочего топлива, °C
        ///</summary>
        public double TempRabT
        {
            get { return _tempRabT; }
            set { _tempRabT = value; }
        }

        ///<summary>
        /// Содержание СH4, %
        ///</summary>
        private double _sodCH4;
        ///<summary>
        /// Содержание СH4, %
        ///</summary>
        public double SodCH4
        {
            get { return _sodCH4; }
            set { _sodCH4 = value; }
        }

        ///<summary>
        /// Содержание C2H6, %
        ///</summary>
        private double _sodC2H6;
        ///<summary>
        /// Содержание C2H6, %
        ///</summary>
        public double SodC2H6
        {
            get { return _sodC2H6; }
            set { _sodC2H6 = value; }
        }

        ///<summary>
        /// Содержание C3H8, %
        ///</summary>
        private double _sodC3H8;
        ///<summary>
        /// Содержание C3H8, %
        ///</summary>
        public double SodC3H8
        {
            get { return _sodC3H8; }
            set { _sodC3H8 = value; }
        }

        ///<summary>
        /// Содержание C4H10, %
        ///</summary>
        private double _sodC4H10;
        ///<summary>
        /// Содержание C4H10, %
        ///</summary>
        public double SodC4H10
        {
            get { return _sodC4H10; }
            set { _sodC4H10 = value; }
        }

        ///<summary>
        /// Содержание C5H12, %
        ///</summary>
        private double _sodC5H12;
        ///<summary>
        /// Содержание C5H12, %
        ///</summary>
        public double SodC5H12
        {
            get { return _sodC5H12; }
            set { _sodC5H12 = value; }
        }

        ///<summary>
        /// Содержание C6H14, %
        ///</summary>
        private double _sodC6H14;
        ///<summary>
        /// Содержание C6H14, %
        ///</summary>
        public double SodC6H14
        {
            get { return _sodC6H14; }
            set { _sodC6H14 = value; }
        }

        ///<summary>
        /// Содержание CO, %
        ///</summary>
        private double _sodCO;
        ///<summary>
        /// Содержание CO, %
        ///</summary>
        public double SodCO
        {
            get { return _sodCO; }
            set { _sodCO = value; }
        }

        ///<summary>
        /// Содержание CO2,%
        ///</summary>
        private double _sodCO2;
        ///<summary>
        /// Содержание CO2,%
        ///</summary>
        public double SodCO2
        {
            get { return _sodCO2; }
            set { _sodCO2 = value; }
        }

        ///<summary>
        /// Содержание N2, %
        ///</summary>
        private double _sodN2;
        ///<summary>
        /// Содержание N2, %
        ///</summary>
        public double SodN2
        {
            get { return _sodN2; }
            set { _sodN2 = value; }
        }

        ///<summary>
        /// Содержание O2, %
        ///</summary>
        private double _sodO2;
        ///<summary>
        /// Содержание O2, %
        ///</summary>
        public double SodO2
        {
            get { return _sodO2; }
            set { _sodO2 = value; }
        }

        ///<summary>
        /// Содержание H2S, %
        ///</summary>
        private double _sodH2S;
        ///<summary>
        /// Содержание H2S, %
        ///</summary>
        public double SodH2S
        {
            get { return _sodH2S; }
            set { _sodH2S = value; }
        }

        ///<summary>
        /// Содержание H2, %
        ///</summary>
        private double _sodH2;
        ///<summary>
        /// Содержание H2, %
        ///</summary>
        public double SodH2
        {
            get { return _sodH2; }
            set { _sodH2 = value; }
        }

        ///<summary>
        /// Коэффициент избытка воздуха, %
        ///</summary>
        private double _alpha;
        ///<summary>
        /// Коэффициент избытка воздуха, %
        ///</summary>
        public double Alpha
        {
            get { return _alpha; }
            set { _alpha = value; }
        }

        ///<summary>
        /// Температура воздуха, °C
        ///</summary>
        private double _tempVozd;
        ///<summary>
        /// Температура воздуха, °C
        ///</summary>
        public double TempVozd
        {
            get { return _tempVozd; }
            set { _tempVozd = value; }
        }

        ///<summary>
        /// Температура уходящих газов, °C
        ///</summary>
        private double _tempOut;
        ///<summary>
        /// Температура уходящих газов, °C
        ///</summary>
        public double TempOut
        {
            get { return _tempOut; }
            set { _tempOut = value; }
        }

        ///<summary>
        /// Величина химической неполноты сгорания топлива, %
        ///</summary>
        private double _qChem;
        ///<summary>
        /// Величина химической неполноты сгорания топлива, %
        ///</summary>
        public double QChem
        {
            get { return _qChem; }
            set { _qChem = value; }
        }

        ///<summary>
        /// Величина механической неполноты сгорания топлива, %
        ///</summary>
        private double _qMech;
        ///<summary>
        /// Величина механической неполноты сгорания топлива, %
        ///</summary>
        public double QMech
        {
            get { return _qMech; }
            set { _qMech = value; }
        }

        ///<summary>
        /// Величина потерь тепла от наружного охлаждения, %
        ///</summary>
        private double _qCold;
        ///<summary>
        /// Величина потерь тепла от наружного охлаждения, %
        ///</summary>
        public double QCold
        {
            get { return _qCold; }
            set { _qCold = value; }
        }

        ///<summary>
        /// Величина потерь тепла с физическим теплом шлаков, %
        ///</summary>
        private double _qWarm;
        ///<summary>
        /// Величина потерь тепла с физическим теплом шлаков, %
        ///</summary>
        public double QWarm
        {
            get { return _qWarm; }
            set { _qWarm = value; }
        }

        #endregion Входные параметры 
    }
}