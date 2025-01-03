using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TeploBalanceKotelMathLib;

namespace TeploBalanceKotelCore.Models
{
    public class DataInputModelTverd 
    {
        // Создать главный объект, который включает в себя все нужные объекты
        private TverdToplivo _cs = new TverdToplivo();

        public DataInputModelTverd() { }

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
        /// Содержание водорода, рабочая масса, %
        ///</summary>
        private double _sodH;
        ///<summary>
        /// Содержание водорода, рабочая масса, %
        ///</summary>
        public double SodH
        {
            get { return _sodH; }
            set { _sodH = value; }
        }

        ///<summary>
        /// Содержание углерода, рабочая масса, %
        ///</summary>
        private double _sodC;
        ///<summary>
        /// Содержание углерода, рабочая масса, %
        ///</summary>
        public double SodC
        {
            get { return _sodC; }
            set { _sodC = value; }
        }

        ///<summary>
        /// Содержание кислорода, рабочая масса, %
        ///</summary>
        private double _sodO;
        ///<summary>
        /// Содержание кислорода, рабочая масса, %
        ///</summary>
        public double SodO
        {
            get { return _sodO; }
            set { _sodO = value; }
        }

        ///<summary>
        /// Содержание серы, рабочая масса, %
        ///</summary>
        private double _sodS;
        ///<summary>
        /// Содержание серы, рабочая масса, %
        ///</summary>
        public double SodS
        {
            get { return _sodS; }
            set { _sodS = value; }
        }

        ///<summary>
        /// Содержание водяных паров, рабочая масса, %
        ///</summary>
        private double _sodWP;
        ///<summary>
        /// Содержание водяных паров, рабочая масса, %
        ///</summary>
        public double SodWP
        {
            get { return _sodWP; }
            set { _sodWP = value; }
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