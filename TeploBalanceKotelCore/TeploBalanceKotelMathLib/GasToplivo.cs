using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeploBalanceKotelMathLib
{    
    public class GasToplivo
    {
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


        #region Расчетные данные

        #region Тепло, полезно затраченное на выработку пара

        /// <summary>
        /// Энтальпия питательной воды, Дж/кг
        /// </summary>
        private double _entPitWat;
        /// <summary>
        /// Энтальпия питательной воды, Дж/кг
        /// </summary>
        public double EntPitWat()
        {
            // теплоемкость питательной воды
            double _entWat = 2.0 * Math.Pow(10, -7) * _tempPitWat * _tempPitWat + Math.Pow(10, -4) * _tempPitWat + 1.495;
            // энтальпия питательной воды
            _entPitWat = _tempPitWat * _entWat; // энтальпия воды*темп.пит.воды
            return _entPitWat;
        }

        /// <summary>
        /// Энтальпия нагретого пара, Дж
        /// </summary>
        private double _entHeatWat;
        /// <summary>
        /// Энтальпия нагретого пара, Дж
        /// </summary>
        public double EntHeatWat()
        {
            double _entPrWat = 2d * Math.Pow(10, -7) * Math.Pow(_tempHeatWat,2) + Math.Pow(10, -4) * _tempHeatWat + 1.495;//энтальпия прегретой воды
            _entHeatWat = _tempHeatWat * _entPrWat;
            return _entHeatWat;
        }

        /// <summary>
        /// Энтальпия кипящей воды,Дж
        /// </summary>
        private double _entBoilWat;
        public double EntBoilWat()
        {
            double _tempBoil = -1.5606 * Math.Pow(_pressure, 2)+22.167*_pressure+80.335;//температура кипящей воды
            double _entBoil = 2 * Math.Pow(10, -7) *Math.Pow( _tempBoil,2) + Math.Pow(10, -4) * _tempBoil + 1.495;//энтальпия кипятка
           
             _entBoilWat = _tempBoil * _entBoil;
            
            return _entBoilWat;
        }

        /// <summary>
        /// Тепло, полезно затраченное на выработку пара, кВт
        /// </summary>
        private double _warmQk;
        /// <summary>
        /// Тепло, полезно затраченное на выработку пара, кВт
        /// </summary>
        public double WarmQk()
        {
            _warmQk = _parVyh * (_entHeatWat - _entPitWat) + _parVyh * _rashWat * (_entBoilWat - _entPitWat);
            return _warmQk;
        }

        #endregion Тепло, полезно затраченное на выработку пара

        #region Приходная часть теплового баланса

        /// <summary>
        /// Физическое тепло подогретого топлива, кДж/м3
        /// </summary>
        private double _warmFuel;
        /// <summary>
        /// Физическое тепло подогретого топлива, кДж/м3
        /// </summary>
        public double WarmFuel()
        {
            double _tCH4 = 6 * Math.Pow(10, -7) * Math.Pow(_tempRabT, 2) + 9 * Math.Pow(10, -4) * _tempRabT + 1.5462;
            double _tC2H6 = -4 * Math.Pow(10, -7) * Math.Pow(_tempRabT, 2) + 0.0029 * _tempRabT + 2.2095;
            double _tC3H8 = -1 * Math.Pow(10, -6) * Math.Pow(_tempRabT, 2) + 0.0048 * _tempRabT + 3.047;
            double _tCO2 = -6 * Math.Pow(10, -7) * Math.Pow(_tempRabT, 2) + Math.Pow(10, -3) * _tempRabT + 1.6015;
            double _tN2 = Math.Pow(10, -7) * Math.Pow(_tempRabT, 2) - 4 * Math.Pow(10, -6) * _tempRabT + 1.2956;
            double _tH2 = -3 * Math.Pow(10, -7) * Math.Pow(_tempRabT, 2) + 2 * Math.Pow(10, -4) * _tempRabT + 1.2803;

            double _teploemk = 0.01 * (_tCH4 * _sodCH4 + _tC2H6 * _sodC2H6 + _tC3H8 * _sodC3H8 + _tCO2 * _sodCO2 + _tH2 * _sodH2);//теплоемкость рабочего топлива
            _warmFuel = _teploemk * _tempRabT;

            return _warmFuel;
        }

        /// <summary>
        /// Низшая теплотворная способность (теплота сгорания) топлива, кДж/м3
        /// </summary>
        private double _warmBurnLow;
        /// <summary>
        /// Низшая теплотворная способность (теплота сгорания) топлива, кДж/м3
        /// </summary>
        public double WarmBurnLow()
        {
            _warmBurnLow = 127.7 * _sodCO + 108d * _sodH2 + 358d * _sodCH4 + 636d * _sodC2H6 + 913d * _sodC3H8 + 1185d * _sodC4H10 + 1465d * _sodC5H12 + 234d * _sodH2S;
            return _warmBurnLow;
        }

        /// <summary>
        /// Удельная теплота парообразования, кДж/кг
        /// </summary>
        private double _lambdaAlpha;
        /// <summary>
        /// Удельная теплота парообразования, кДж/кг
        /// </summary>
        public double LambdaAlpha()
        {
            _lambdaAlpha = 11.25 * _alpha + 0.0535;
            return _lambdaAlpha;
        }
        /// <summary>
        /// Высшая теплотворная способность (теплота сгорания) топлива, кДж/кг
        /// </summary>
        private double _warmBurnHigh;
        public double WarmBurnHigh()
        {
            double _lambdaAlpha = 11.25 * _alpha + 0.0535;
            double _n2 = Math.Pow(10, -7) * Math.Pow(_tempOut, 2) + 4d * Math.Pow(10, -6) * _tempOut + 1.2956;
            double _o2 = 2d * Math.Pow(10, -7) * Math.Pow(_tempOut, 2) + Math.Pow(10, -4) * _tempOut + 1.3064;
            _warmBurnHigh = (_lambdaAlpha * _tempVozd * (_n2 * 79d + _o2 * 21d)) / 100d;
            return _warmBurnHigh;
        }

        /// <summary>
        /// Теплоемкость азота, кДж/(м3*К) 
        /// </summary>
        private double _n2;
        /// <summary>
        /// Теплоемкость азота, кДж/(м3*К) 
        /// </summary>
        public double N2()
        {
            _n2 = Math.Pow(10,-7) * Math.Pow(_tempOut, 2) + 4d * Math.Pow(10, -6) * _tempOut + 1.2956;
            return _n2;
        }

        /// <summary>
        /// Теплоемкость кислорода, кДж/(м3*К) 
        /// </summary>
        private double _o2;
        /// <summary>
        /// Теплоемкость кислорода, кДж/(м3*К) 
        /// </summary>
        public double O2()
        {
            _o2 = 2d * Math.Pow(10, -7) * Math.Pow(_tempOut, 2) + Math.Pow(10, -4) * _tempOut + 1.3064;
            return _o2;
        }

        /// <summary>
        /// Теплоемкость углекислого газа CO2, кДж/(м3*К)
        /// </summary>
        private double _co2;
        /// <summary>
        /// Теплоемкость углекислого газа CO2, кДж/(м3*К)
        /// </summary>
        public double CO2()
        {
            _co2 = -6d * Math.Pow(10, -7) * Math.Pow(_tempOut, 2) + 0.001 * _tempOut + 1.6015;
            return _co2;
        }

        /// <summary>
        /// Теплоемкость сернистого газа SO2, кДж/(м3*К)
        /// </summary>
        private double _so2;
        /// <summary>
        /// Теплоемкость сернистого газа SO2, кДж/(м3*К)
        /// </summary>
        public double SO2()
        {
            _so2 = -3d * Math.Pow(10, -7) * Math.Pow(_tempOut, 2) + 8 * Math.Pow(10, -4) * _tempOut + 1.733;
            return _so2;
        }

        /// <summary>
        /// Теплоемкость паров воды, кДж/(м3*К)
        /// </summary>
        private double _h2o;
        /// <summary>
        /// Теплоемкость паров воды, кДж/(м3*К)
        /// </summary>
        public double H2O()
        {
            _h2o = 2d * Math.Pow(10, -7) * Math.Pow(_tempOut, 2) + Math.Pow(10, -4) * _tempOut + 1.495;
            return _h2o;
        }

        /// <summary>
        /// Располагаемое тепло Q_p, кДж/кг
        /// </summary>
        private double _warmHave;
        /// <summary>
        /// Располагаемое тепло Q_p, кДж/кг
        /// </summary>
        public double WarmHave()
        {
            _warmHave = _warmBurnLow + _warmFuel + _warmBurnHigh;
            return _warmHave;
        }

        #endregion Приходная часть теплового баланса

        #region Расходная часть теплового баланса

        /// <summary>
        /// Средний состав продуктов сгорания - углекислого газа CO2, %
        /// </summary>
        private double _burnco2;
        /// <summary>
        /// Средний состав продуктов сгорания - углекислого газа CO2, %
        /// </summary>
        public double BurnCO2()
        {
            _burnco2 = 3.5883 * Math.Pow(_alpha, 2) -15.263 * _alpha + 21.193;
            return _burnco2;
        }

        /// <summary>
        /// Средний состав продуктов сгорания - сернистого газа SO2, %
        /// </summary>
        private double _burnso2;
        /// <summary>
        /// Средний состав продуктов сгорания - сернистого газа SO2, %
        /// </summary>
        public double BurnSO2()
        {
            _burnso2 = 0;
            return _burnso2;
        }

        /// <summary>
        /// Средний состав продуктов сгорания - паров воды H2O, %
        /// </summary>
        private double _burnh2o;
        /// <summary>
        /// Средний состав продуктов сгорания - паров воды H2O, %
        /// </summary>
        public double BurnH2O()
        {
            _burnh2o = 7.0558 * Math.Pow(_alpha, 2) - 30.012 * _alpha + 41.672;
            return _burnh2o;
        }

        /// <summary>
        /// Средний состав продуктов сгорания - азота N2, %
        /// </summary>
        private double _burnn2;
        /// <summary>
        /// Средний состав продуктов сгорания - азота N2, %
        /// </summary>
        public double BurnN2()
        {
            _burnn2 = -2.7391 * Math.Pow(_alpha, 2) + 11.645 * _alpha + 62.847;
            return _burnn2;
        }

        /// <summary>
        /// Средний состав продуктов сгорания - кислорода O2, %
        /// </summary>
        private double _burno2;
        /// <summary>
        /// Средний состав продуктов сгорания - кислорода O2, %
        /// </summary>
        public double BurnO2()
        {
            _burno2 = -7.9157 * Math.Pow(_alpha, 2) + 33.671 * _alpha - 25.75;
            return _burno2;
        }

        /// <summary>
        /// Необходимый объем воздуха, м3/м3
        /// </summary>
        private double _valpha;
        /// <summary>
        /// Необходимый объем воздуха, м3/м3
        /// </summary>
        public double VAlpha()
        {
            _valpha = 9.8 * _alpha + 0.61;
            return _valpha;
        }

        /// <summary>
        /// Энтальпия уходящих газов, кДж/кг
        /// </summary>
        private double _entOutGas;
        /// <summary>
        /// Энтальпия уходящих газов, кДж/кг
        /// </summary>
        public double EntOutGas()
        {
            double sum = _co2 * _burnco2 + _so2 * _burnso2 + _h2o * _burnh2o + _burnn2 * _n2 + _burno2 * _o2;
            _entOutGas = (_tempOut * sum) / 100d;
            return _entOutGas;
        }

        /// <summary>
        /// Потери тепла с уходящими газами, кДж/кг
        /// </summary>
        private double _lossGas;
        /// <summary>
        /// Потери тепла с уходящими газами, кДж/кг
        /// </summary>
        public double LossGas()
        {
            _lossGas = _entOutGas * _valpha;
            return _lossGas;
        }

        /// <summary>
        /// Потери тепла от химической неполноты сгорания, кДж/кг
        /// </summary>
        private double _lossChem;
        /// <summary>
        /// Потери тепла от химической неполноты сгорания, кДж/кг
        /// </summary>
        public double LossChem()
        {
            _lossChem = (_qChem * _warmHave) / 100d;
            return _lossChem;
        }

        /// <summary>
        /// Потери тепла от механической неполноты сгорания, кДж/кг
        /// </summary>
        private double _lossMech;
        /// <summary>
        /// Потери тепла от механической неполноты сгорания, кДж/кг
        /// </summary>
        public double LossMech()
        {
            _lossMech =(_qMech * _warmHave) / 100d;
            return _lossMech;
        }

        /// <summary>
        /// Потери тепла от наружного охлаждения, кДж/кг
        /// </summary>
        private double _lossOutCold;
        /// <summary>
        /// Потери тепла от наружного охлаждения, кДж/кг
        /// </summary>
        public double LossOutCold()
        {
            _lossOutCold = (_qCold * _warmHave) / 100d;
            return _lossOutCold;
        }

        /// <summary>
        /// Потери тепла с физическим шлаком, кДж/кг
        /// </summary>
        private double _lossOutWarm;
        /// <summary>
        /// Потери тепла с физическим шлаком, кДж/кг
        /// </summary>
        public double LossOutWarm()
        {
            _lossOutWarm = (_qWarm * _warmHave) / 100d;
            return _lossOutWarm;
        }

        /// <summary>
        /// Расходная часть теплового баланса, кДж/кг
        /// </summary>
        private double _lossFullWarm;
        /// <summary>
        /// Расходная часть теплового баланса, кДж/кг
        /// </summary>
        public double LossFullWarm()
        {
            _lossFullWarm = _lossGas + _lossChem + _lossMech + _lossOutCold + _warmQk;
            return _lossFullWarm;
        }

        #endregion Расходная часть теплового баланса

        /// <summary>
        /// КПД котла, %
        /// </summary>
        private double _kpd;
        /// <summary>
        /// КПД котла, %
        /// </summary>
        public double KPD()
        {
            double _lossZar = (_lossFullWarm * 100d) / _warmHave;
            _kpd = 100d - _lossZar;
            return _kpd;
        }

        #region Расход топлива

        /// <summary>
        /// Расход топлива, кг/с
        /// </summary>
        private double _rashodTopl;
        /// <summary>
        /// Расход топлива, кг/с
        /// </summary>
        public double RashodTopl()
        {            
            _rashodTopl = (_warmQk * 100d)/(_kpd * _warmHave);
            return _rashodTopl;
        }

        #endregion Расход топлива

        #endregion Расчетные данные
    }
}