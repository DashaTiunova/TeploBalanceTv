using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeploBalanceKotelMathLib
{   
    public class ZhidkToplivo
    {
        #region Входные параметры 

        /// <summary>
        /// Выход пара, кг/с
        /// </summary>
        private double _parVyh;
        /// <summary>
        /// Выход пара, кг/с
        /// </summary>
        public double ParVyh
        { 
            get { return _parVyh; }
            set { _parVyh = value; }
        }

        /// <summary>
        /// Расход воды на продувку котла, кг/с
        /// </summary>
        private double _rashWat;
        /// <summary>
        /// Расход воды на продувку котла, кг/с
        /// </summary>
        public double RashWat
        {
            get { return _rashWat; }
            set { _rashWat = value; }
        }

        /// <summary>
        /// Температура питательной воды, °С
        /// </summary>
        private double _tempPitWat;
        /// <summary>
        /// Температура питательной воды, °С
        /// </summary>
        public double TempPitWat
        {
            get { return _tempPitWat; }
            set { _tempPitWat = value; }
        }

        /// <summary>
        /// Температура нагретого пара, °С
        /// </summary>
        private double _tempHeatWat;
        /// <summary>
        /// Температура нагретого пара, °С
        /// </summary>
        public double TempHeatWat
        {
            get { return _tempHeatWat; }
            set { _tempHeatWat = value; }
        }

        /// <summary>
        /// Давление внутри барабана, атм
        /// </summary>
        private double _pressure;
        /// <summary>
        /// Давление внутри барабана, атм
        /// </summary>
        public double Pressure
        {
            get { return _pressure; }
            set { _pressure = value; }
        }

        /// <summary>
        /// Температура рабочего топлива, °С
        /// </summary>
        private double _tempRabT;
        /// <summary>
        /// Температура рабочего топлива, °С
        /// </summary>
        public double TempRabT
        {
            get { return _tempRabT; }
            set { _tempRabT = value; }
        }

        /// <summary>
        /// Содержание водорода, рабочая масса, %
        /// </summary>
        private double _sodH;
        /// <summary>
        /// Содержание водорода, рабочая масса, %
        /// </summary>
        public double SodH
        {
            get { return _sodH; }
            set { _sodH = value; }
        }

        /// <summary>
        /// Содержание углерода, рабочая масса, %
        /// </summary>
        private double _sodC;
        /// <summary>
        /// Содержание углерода, рабочая масса, %
        /// </summary>
        public double SodC
        {
            get { return _sodC; }
            set { _sodC = value; }
        }

        /// <summary>
        /// Содержание кислорода, рабочая масса, %
        /// </summary>
        private double _sodO;
        /// <summary>
        /// Содержание кислорода, рабочая масса, %
        /// </summary>
        public double SodO
        {
            get { return _sodO; }
            set { _sodO = value; }
        }

        /// <summary>
        /// Содержание серы, рабочая масса, %
        /// </summary>
        private double _sodS;
        /// <summary>
        /// Содержание серы, рабочая масса, %
        /// </summary>
        public double SodS
        {
            get { return _sodS; }
            set { _sodS = value; }
        }

        /// <summary>
        /// Содержание водяных паров, рабочая масса, %
        /// </summary>
        private double _sodWP;
        /// <summary>
        /// Содержание водяных паров, рабочая масса, %
        /// </summary>
        public double SodWP
        {
            get { return _sodWP; }
            set { _sodWP = value; }
        }

        /// <summary>
        /// Содержание азота, рабочая масса, %
        /// </summary>
        private double _sodN;
        /// <summary>
        /// Содержание азота, рабочая масса, %
        /// </summary>
        public double SodN
        {
            get { return _sodN; }
            set { _sodN = value; }
        }

        /// <summary>
        /// Коэффициент избытка воздуха, ед.
        /// </summary>
        private double _alpha;
        /// <summary>
        /// Коэффициент избытка воздуха, ед.
        /// </summary>
        public double Alpha
        {
            get { return _alpha; }
            set { _alpha = value; }
        }

        /// <summary>
        /// Температура воздуха, °С
        /// </summary>
        private double _tempVozd;
        /// <summary>
        /// Температура воздуха, °С
        /// </summary>
        public double TempVozd
        {
            get { return _tempVozd; }
            set { _tempVozd = value; }
        }

        /// <summary>
        /// Температура уходящих газов, °С
        /// </summary>
        private double _tempOut;
        /// <summary>
        /// Температура уходящих газов, °С
        /// </summary>
        public double TempOut
        {
            get { return _tempOut; }
            set { _tempOut = value; }
        }

        /// <summary>
        /// Величина химической неполноты сгорания топлива, %
        /// </summary>
        private double _qChem;
        /// <summary>
        /// Величина химической неполноты сгорания топлива, %
        /// </summary>
        public double QChem
        {
            get { return _qChem; }
            set { _qChem = value; }
        }

        /// <summary>
        /// Величина механической неполноты сгорания топлива, %
        /// </summary>
        private double _qMech;
        /// <summary>
        /// Величина механической неполноты сгорания топлива, %
        /// </summary>
        public double QMech
        {
            get { return _qMech; }
            set { _qMech = value; }
        }

        /// <summary>
        /// Величина потерь тепла от наружного охлаждения, %
        /// </summary>
        private double _qCold;
        /// <summary>
        /// Величина потерь тепла от наружного охлаждения, %
        /// </summary>
        public double QCold
        {
            get { return _qCold; }
            set { _qCold = value; }
        }

        /// <summary>
        /// Величина потерь тепла с физическим теплом шлаков, %
        /// </summary>
        private double _qWarm;
        /// <summary>
        /// Величина потерь тепла с физическим теплом шлаков, %
        /// </summary>
        public double QWarm
        {
            get { return _qWarm; }
            set { _qWarm = value; }
        }

        #endregion Входные параметры 


        #region Расчетные данные

        #region Тепло, полезно затраченное на выработку пара

        /// <summary>
        /// Энтальпия питательной воды, кДж/кг
        /// </summary>
        private double _entPitWat;
        /// <summary>
        /// Энтальпия питательной воды, кДж/кг
        /// </summary>
        public double EntPitWat()
        {
            double _entWat = 2d * Math.Pow(10, -7) * Math.Pow(_tempPitWat,2) + Math.Pow(10, -4) * _tempPitWat + 1.495; //энтальпия воды
            _entPitWat= _tempPitWat * _entWat; //энтальпия воды*темп.пит.воды
            return _entPitWat;
        }

        /// <summary>
        /// Энтальпия нагретого пара, кДж/кг
        /// </summary>
        private double _entHeatWat;
        /// <summary>
        /// Энтальпия нагретого пара, кДж/кг
        /// </summary>
        public double EntHeatWat()
        {
            double _entPrWat = 2 * Math.Pow(10, -7) * Math.Pow(_tempHeatWat, 2) + Math.Pow(10, -4) * _tempHeatWat + 1.495;//энтальпия прегретой воды
            _entHeatWat = _tempHeatWat * _entPrWat;
            return _entHeatWat;
        }

        /// <summary>
        /// Энтальпия кипящей воды, кДж/кг
        /// </summary>
        private double _entBoilWat;
        /// <summary>
        /// Энтальпия кипящей воды, кДж/кг
        /// </summary>
        public double EntBoilWat()
        {
            double _tempBoil = -1.5606 * Math.Pow(_pressure, 2) + 22.167 * _pressure + 80.335; //температура кипящей воды
            double _entBoil = 2 * Math.Pow(10, -7) * Math.Pow(_tempBoil, 2) + Math.Pow(10, -4) * _tempBoil + 1.495;//энтальпия кипятка
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
            _warmQk = _parVyh * (_entHeatWat - _entPitWat) + _rashWat * _parVyh * (_entBoilWat - _entPitWat);
            return _warmQk;
        }

        #endregion Тепло, полезно затраченное на выработку пара

        #region Приходная часть теплового баланса

        /// <summary>
        /// Физическое тепло подогретого топлива, кДж/кг
        /// </summary>
        private double _warmFuel;
        /// <summary>
        /// Физическое тепло подогретого топлива, кДж/кг
        /// </summary>
        public double WarmFuel()
        {        
            double _teploemk = 1.3 + 0.0112 * _tempRabT; // теплоемкость рабочего топлива, кДж/(кг*К)
            _warmFuel = _teploemk * _tempRabT;
            return _warmFuel;
        }

        /// <summary>
        /// Низшая теплотворная способность (теплота сгорания) топлива, кДж/кг
        /// </summary>
        private double _warmBurnLow;
        /// <summary>
        /// Низшая теплотворная способность (теплота сгорания) топлива, кДж/кг
        /// </summary>
        public double WarmBurnLow()
        {
            _warmBurnLow = 339d * _sodC + 1030d * _sodH - 109d * (_sodO + _sodS) - 25.14 * (9 * _sodH + _sodWP);
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
            _lambdaAlpha = 7.6456 * _alpha - 0.0948;
            return _lambdaAlpha;
        }

        /// <summary>
        /// Высшая теплотворная способность (теплота сгорания) топлива, кДж/кг
        /// </summary>
        private double _warmBurnHigh;
        /// <summary>
        /// Высшая теплотворная способность (теплота сгорания) топлива, кДж/кг
        /// </summary>
        public double WarmBurnHigh()
        {
            double _lambdaAlpha = 7.6456 * _alpha - 0.0948;
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
            _o2 = 2d * Math.Pow(10, -7) * Math.Pow(_tempOut, 2) +  Math.Pow(10, -4) * _tempOut + 1.3064;
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
            _h2o = 2d * Math.Pow(10, -7) * Math.Pow(_tempOut, 2) +  Math.Pow(10, -4) * _tempOut + 1.495;
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
        /// Средний состав продуктов сгорания - углекислый газ CO2, %
        /// </summary>
        private double _burnco2;
        /// <summary>
        /// Средний состав продуктов сгорания - углекислый газ CO2, %
        /// </summary>
        public double BurnCO2()
        {
            _burnco2 = 6.3739 * Math.Pow(_alpha, 2) -27.008 *_alpha + 37.11;
            return _burnco2;
        }

        /// <summary>
        /// Средний состав продуктов сгорания - сернистый газ SO2, %
        /// </summary>
        private double _burnso2;
        /// <summary>
        /// Средний состав продуктов сгорания - сернистый газ SO2, %
        /// </summary>
        public double BurnSO2()
        {
            _burnso2 = 0.0501 * Math.Pow(_alpha, 2) - 0.1797 * _alpha + 0.189;
            return _burnso2;
        }

        /// <summary>
        /// Средний состав продуктов сгорания - пары воды H2O, %
        /// </summary>
        private double _burnh2o;
        /// <summary>
        /// Средний состав продуктов сгорания - пары воды H2O, %
        /// </summary>
        public double BurnH2O()
        {
            _burnh2o = 1.5821 * Math.Pow(_alpha, 2) - 9.5428 * _alpha + 19.718;
            return _burnh2o;
        }

        /// <summary>
        /// Средний состав продуктов сгорания - азот N2, %
        /// </summary>
        private double _burnn2;
        /// <summary>
        /// Средний состав продуктов сгорания - азот N2, %
        /// </summary>
        public double BurnN2()
        {
            _burnn2 = -1.1926 * Math.Pow(_alpha, 2) + 6.464 * _alpha + 66.372;
            return _burnn2;
        }

        /// <summary>
        /// Средний состав продуктов сгорания - кислород O2, %
        /// </summary>
        private double _burno2;
        /// <summary>
        /// Средний состав продуктов сгорания - кислород O2, %
        /// </summary>
        public double BurnO2()
        {
            _burno2 = -8.0356 * Math.Pow(_alpha, 2) + 34 * _alpha - 25.958;
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
            _valpha = 7.6 * _alpha + 0.67;
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
            _entOutGas = (_tempOut * sum)/100d;
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
            _lossChem = _qChem * _warmHave / 100d;
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
            _lossMech = _qMech * _warmHave / 100d;
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
            _lossOutCold = _qCold * _warmHave / 100d;
            return _lossOutCold;
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
            double _lossZar = (_lossFullWarm * 100d)/ _warmHave;
            _kpd = 100d - _lossZar;
            return _kpd;
        }        

        #region Расход топлива

        /// <summary>
        /// Расход топлива, м3/с
        /// </summary>
        private double _rashodTopl;
        /// <summary>
        /// Расход топлива, м3/с
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