using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeploBalanceKotelMathLib;

namespace TeploBalanceKotelCore.Models
{
    public class DataOutputModelTverd
    {
        private TverdToplivo _cs = new TverdToplivo();
        private DataInputModelTverd _dataInputTverd = new DataInputModelTverd();

        public DataOutputModelTverd() { }

        public DataOutputModelTverd(DataInputModelTverd DataInputTverd)
        {
            _dataInputTverd = DataInputTverd;

            #region --- Передать исходные данные в экземпляр библиотеки

            _cs.TempPitWat = _dataInputTverd.TempPitWat;
            _cs.TempHeatWat = _dataInputTverd.TempHeatWat;
            _cs.Pressure = _dataInputTverd.Pressure;
            _cs.ParVyh = _dataInputTverd.ParVyh;
            _cs.RashWat = _dataInputTverd.RashWat;
            _cs.TempRabT = _dataInputTverd.TempRabT;
            _cs.SodH = _dataInputTverd.SodH;
            _cs.SodC = _dataInputTverd.SodC;
            _cs.SodO = _dataInputTverd.SodO;
            _cs.SodS = _dataInputTverd.SodS;
            _cs.SodWP = _dataInputTverd.SodWP;
            _cs.Alpha = _dataInputTverd.Alpha;
            _cs.TempVozd = _dataInputTverd.TempVozd;
            _cs.TempOut = _dataInputTverd.TempOut;
            _cs.QChem = _dataInputTverd.QChem;
            _cs.QMech = _dataInputTverd.QMech;
            _cs.QCold = _dataInputTverd.QCold;

            #endregion --- Передать исходные данные в экземпляр библиотеки
        }

        #region --- Получить расчетные показатели

        /// <summary>
        /// Энтальпия питательной воды, Дж/кг
        /// </summary>          
        public double EntPitWat
        {
            get { return _cs.EntPitWat(); }
        }
        /// <summary>
        /// Энтальпия нагретого пара, Дж
        /// </summary>          
        public double EntHeatWat
        {
            get { return _cs.EntHeatWat(); }
        }
        /// <summary>
        /// Энтальпия кипящей воды,Дж
        /// </summary>          
        public double EntBoilWat
        {
            get { return _cs.EntBoilWat(); }
        }
        /// <summary>
        /// Тепло, полезно затраченное на выработку пара, кВт
        /// </summary>
        public double WarmQk
        {
            get { return _cs.WarmQk(); }
        }
        /// <summary>
        /// Физическое тепло подогретого топлива, кДж/м3
        /// </summary>       
        public double WarmFuel
        {
            get { return _cs.WarmFuel(); }
        }

        /// <summary>
        /// низшая теплотворная способность (теплота сгорания) топлива Q_нр,Дж
        /// </summary>        
        public double WarmBurnLow
        {
            get { return _cs.WarmBurnLow(); }
        }
        /// <summary>
        /// удельная теплота парообразования,Дж\кг
        /// </summary>
        public double LambdaAlpha
        {
            get { return _cs.LambdaAlpha(); }
        }

        /// <summary>
        /// высшая теплотворная способность (теплота сгорания) топлива,Дж
        /// </summary>       
        public double WarmBurnHigh
        {
            get { return _cs.WarmBurnHigh(); }
        }
        /// <summary>
        /// теплоемкость газов  азота,Дж\К
        /// </summary>
        public double N2
        {
            get { return _cs.N2(); }
        }

        /// <summary>
        /// теплоемкость газов  кислорода,Дж\К
        /// </summary>     
        public double O2
        {
            get { return _cs.O2(); }
        }

        /// <summary>
        /// теплоемкость газов  углекислого газа co2,Дж\К
        /// </summary>
        public double CO2
        {
            get { return _cs.CO2(); }
        }

        /// <summary>
        /// теплоемкость газов  сернистого газа so2,Дж\К
        /// </summary>      
        public double SO2
        {
            get { return _cs.SO2(); }
        }

        /// <summary>
        /// теплоемкость газов  воды,Дж\К
        /// </summary>      
        public double H2O
        {
            get { return _cs.H2O(); }
        }
        /// <summary>
        /// РАСПОЛАГАЕМОЕ ТЕПЛО Q_p,кДж\кг
        /// </summary>      
        public double WarmHave
        {
            get { return _cs.WarmHave(); }
        }
        /// <summary>
        /// средний состав продуктов сгорания углекислого газа co2,%
        /// </summary>      
        public double BurnCO2
        {
            get { return _cs.BurnCO2(); }
        }
        /// <summary>
        /// средний состав продуктов сгорания сернистого газа so2,%
        /// </summary>      
        public double BurnSO2
        {
            get { return _cs.BurnSO2(); }
        }
        /// <summary>
        /// средний состав продуктов сгорания воды h2o,%
        /// </summary>      
        public double BurnH2O
        {
            get { return _cs.BurnH2O(); }
        }
        /// <summary>
        /// средний состав продуктов сгорания азота n2,%
        /// </summary>      
        public double BurnN2
        {
            get { return _cs.BurnN2(); }
        }
        /// <summary>
        /// средний состав продуктов сгорания кислорода о2,%
        /// </summary>      
        public double BurnO2
        {
            get { return _cs.BurnO2(); }
        }
        /// <summary>
        /// необходимый объем воздуха,м^3
        /// </summary>      
        public double VAlpha
        {
            get { return _cs.VAlpha(); }
        }
        /// <summary>
        /// энтальпия уходящих газов,кДж\кг
        /// </summary>      
        public double EntOutGas
        {
            get { return _cs.EntOutGas(); }
        }
        /// <summary>
        /// потеря с уходящими газами,кДж\кг
        /// </summary>      
        public double LossGas
        {
            get { return _cs.LossGas(); }
        }
        /// <summary>
        /// потеря от химической неполноты сгорания,кДж\кг
        /// </summary>      
        public double LossChem
        {
            get { return _cs.LossChem(); }
        }
        /// <summary>
        /// потеря от механической неполноты сгорания,кДж\кг
        /// </summary>      
        public double LossMech
        {
            get { return _cs.LossMech(); }
        }
        /// <summary>
        /// потеря от наружного охлаждения,кДж\кг
        /// </summary>      
        public double LossOutCold
        {
            get { return _cs.LossOutCold(); }
        }
        /// <summary>
        /// Расходная часть теплового баланса,кДж\кг
        /// </summary>      
        public double LossFullWarm
        {
            get { return _cs.LossFullWarm(); }
        }
        /// <summary>
        /// КПД,%
        /// </summary>      
        public double KPD
        {
            get { return _cs.KPD(); }
        }
        /// <summary>
        /// Часовой расход топлива,кг\с
        /// </summary>      
        public double RashodTopl
        {
            get { return _cs.RashodTopl(); }
        }



      



        #endregion --- Получить расчетные показатели

    }
}
