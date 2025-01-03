using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeploBalanceKotelMathLib;

namespace TeploBalanceKotelCore.Models
{
    public class DataOutputModel
    {
        private GasToplivo _cs = new GasToplivo();
        private DataInputModel _dataInput = new DataInputModel();

        public DataOutputModel() { }

        public DataOutputModel(DataInputModel DataInput)
        {
            _dataInput = DataInput;

            #region --- Передать исходные данные в экземпляр библиотеки

            _cs.TempPitWat = _dataInput.TempPitWat;
            _cs.TempHeatWat = _dataInput.TempHeatWat;
            _cs.Pressure = _dataInput.Pressure;
            _cs.ParVyh = _dataInput.ParVyh;
            _cs.RashWat = _dataInput.RashWat;
            _cs.TempRabT = _dataInput.TempRabT;
            _cs.SodCH4 = _dataInput.SodCH4;
            _cs.SodC2H6 = _dataInput.SodC2H6;
            _cs.SodC3H8 = _dataInput.SodC3H8;
            _cs.SodC4H10 = _dataInput.SodC4H10;
            _cs.SodC5H12 = _dataInput.SodC5H12;
            _cs.SodC6H14 = _dataInput.SodC6H14;
            _cs.SodCO = _dataInput.SodCO;
            _cs.SodCO2 = _dataInput.SodCO2;
            _cs.SodN2 = _dataInput.SodN2;
            _cs.SodO2 = _dataInput.SodO2;
            _cs.SodH2S = _dataInput.SodH2S;
            _cs.SodH2 = _dataInput.SodH2;
            _cs.Alpha = _dataInput.Alpha;
            _cs.TempVozd = _dataInput.TempVozd;
            _cs.TempOut = _dataInput.TempOut;
            _cs.QChem = _dataInput.QChem;
            _cs.QMech = _dataInput.QMech;
            _cs.QCold = _dataInput.QCold;

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
