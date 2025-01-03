using NUnit.Framework;
using TeploBalanceKotelMathLib;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System;

namespace TeploBalanceKotelTest
{
    public class UnitTests_TverdToplivo
    {
        private string fileName = "ТепловойРасчетКотлов.xls";
        Excel.Application objExcel = null;
        Excel.Workbook WorkBook = null;

        private object oMissing = System.Reflection.Missing.Value;

        /// <summary>
        /// Метод тестирования математической библиотеки
        /// </summary>
        [Test]
        public void CalculationTest_TverdToplivo()
        {
            TverdToplivo _ml = new TverdToplivo();

            #region 1. Присвоить исходные данные 

            _ml.TempPitWat = 30d;
            _ml.TempHeatWat = 160d;
            _ml.Pressure = 2d;
            _ml.ParVyh = 2d;
            _ml.RashWat = 0.7d;
            _ml.TempRabT = 10d;
            _ml.SodH = 3.5d;
            _ml.SodWP = 8.5d;
            _ml.SodC = 62.6d;
            _ml.SodO = 8.5d;
            _ml.SodS = 0.4d;
            _ml.Alpha = 2d;
            _ml.TempVozd = 100d;
            _ml.TempOut = 180d;
            _ml.QChem= 2d;
            _ml.QMech = 1.5d;
            _ml.QCold = 1d;
            _ml.QWarm = 0.1d;

            #endregion 1. Присвоить исходные данные

            try
            {
                #region 2. Передать исходные данные в Excel-файл, записать в соответствующие ячейки

                objExcel = new Excel.Application();
                WorkBook = objExcel.Workbooks.Open(
                            Directory.GetCurrentDirectory() + "\\" + fileName);
                Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Sheets["Твердое топливо"];

                // Cells[СТРОКА,СТОЛБЕЦ]
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[33, 2]).Value2 = _ml.TempPitWat;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[36, 2]).Value2 = _ml.TempHeatWat;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[39, 2]).Value2 = _ml.Pressure;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[31, 2]).Value2 = _ml.ParVyh;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[32, 2]).Value2 = _ml.RashWat;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[11, 2]).Value2 = _ml.TempRabT;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[2, 2]).Value2 = _ml.SodH;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[3, 2]).Value2 = _ml.SodWP;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[4, 2]).Value2 = _ml.SodC;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[5, 2]).Value2 = _ml.SodO;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[6, 2]).Value2 = _ml.SodS;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[24, 7]).Value2 = _ml.Alpha;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[23, 7]).Value2 = _ml.TempVozd;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[22, 7]).Value2 = _ml.TempOut;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[23, 4]).Value2 = _ml.QChem;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[24, 4]).Value2 = _ml.QMech;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[25, 4]).Value2 = _ml.QCold;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[26, 4]).Value2 = _ml.QWarm;

                // Отобразить в журнале тестирования исходные данные
                Console.WriteLine("--- Исходные данные");
                Console.WriteLine("Температура питательной воды, °C - TempPitWat: {0}", _ml.TempPitWat.ToString());
                Console.WriteLine("Температура перегретого пара, °C - TempHeatWat: {0}", _ml.TempHeatWat.ToString());
                Console.WriteLine("Давление внутри барабана, атм - Pressure: {0}", _ml.Pressure.ToString());
                Console.WriteLine("Выход пара, кг/с - ParVyh: {0}", _ml.ParVyh.ToString());
                Console.WriteLine("Расход воды на продувку котла, кг/с - RashWat: {0}", _ml.RashWat.ToString());
                Console.WriteLine("Температура рабочего топлива, °С - TempRabT: {0}", _ml.TempRabT.ToString());
                Console.WriteLine("Содержание водорода, % - SodH: {0}", _ml.SodH.ToString());
                Console.WriteLine("Содержание водяных паров, % - SodWP: {0}", _ml.SodWP.ToString());
                Console.WriteLine("Содержание углерода, % - SodC: {0}", _ml.SodC.ToString());
                Console.WriteLine("Содержание кислорода, % - SodO: {0}", _ml.SodO.ToString());
                Console.WriteLine("Содержание серы, % - SodS: {0}", _ml.SodS.ToString());
                Console.WriteLine("Избыток воздуха - Alpha: {0}", _ml.Alpha.ToString());
                Console.WriteLine("Потери тепла от химической неполноты сгорания топлива, % - QChem: {0}", _ml.QChem.ToString());
                Console.WriteLine("Потери тепла от механической неполноты сгорания топлива, % - QMech: {0}", _ml.QMech.ToString());
                Console.WriteLine("Потери тепла от наружного охлаждения, % - QCold: {0}", _ml.QCold.ToString());
                Console.WriteLine("Потери тепла от тепла с физ.шлаком нигде не используется, % - QWarm: {0}", _ml.QWarm.ToString());
                
                #endregion 2. Передать исходные данные в Excel-файл, записать в соответствующие ячейки

                #region 3. Прочитать из ячейки Excel-файла значение расчетных величин

                double EntPitWat = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[35, 2]).Value.ToString());

                double EntHeatWat = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[38, 2]).Value.ToString());

                double EntBoilWat = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[41, 2]).Value.ToString());

                double WarmQk = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[30, 2]).Value.ToString());

                double WarmFuel = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[9, 2]).Value.ToString());

                double WarmBurnLow = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[16, 2]).Value.ToString());

                double LambdaAlpha = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[13, 2]).Value.ToString());

                double N2 = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[35, 5]).Value.ToString());

                double O2 = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[36, 5]).Value.ToString());

                double CO2 = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[32, 5]).Value.ToString());

                double SO2 = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[33, 5]).Value.ToString());

                double H2O = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[34, 5]).Value.ToString());

                double WarmBurnHigh = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[18, 2]).Value.ToString());

                double WarmHave = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[8, 2]).Value.ToString());
                
                double BurnN2 = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[34, 10]).Value.ToString());

                double BurnO2 = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[35, 10]).Value.ToString());

                double BurnCO2 = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[31, 10]).Value.ToString());

                double BurnSO2 = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[32, 10]).Value.ToString());

                double BurnH2O = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[33, 10]).Value.ToString());

                double VAlpha = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[12, 2]).Value.ToString());

                double EntOutGas = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[21, 7]).Value.ToString());

                double LossGas = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[22, 2]).Value.ToString());

                double LossChem = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[23, 2]).Value.ToString());

                double LossMech = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[24, 2]).Value.ToString());

                double LossOutCold = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[25, 2]).Value.ToString());

                double LossOutWarm = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[26, 2]).Value.ToString());

                double LossFullWarm = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[21, 2]).Value.ToString());

                double KPD = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[44, 2]).Value.ToString());

                double RashodTopl = double.Parse(((Excel.Range)WorkBook.Sheets["Твердое топливо"].Cells[48, 2]).Value.ToString());

                #endregion 3. Прочитать из ячейки Excel-файла значение расчетных величин

                #region  4. Сравнить значения из Excel и из библиотеки с заданной точностью

                // Отобразить в журнале тестирования
                Console.WriteLine("");
                Console.WriteLine("--- Результаты расчета");

                // Проверка совпадения с округлением до 3 знаков и точностью 0.001
                Assert.That(Math.Round(_ml.EntPitWat(), 3), Is.EqualTo(EntPitWat).Within(0.001));
                Console.WriteLine("Энтальпия питательной воды, Дж/кг, метод EntPitWat() : expected =" +
                            EntPitWat + "; actual=" + Math.Round(_ml.EntPitWat(), 3));

                Assert.That(Math.Round(_ml.EntHeatWat(), 3), Is.EqualTo(EntHeatWat).Within(0.001));
                Console.WriteLine("Энтальпия перегретого пара, Дж/кг, метод EntHeatWat() : expected =" +
                            EntHeatWat + "; actual=" + Math.Round(_ml.EntHeatWat(), 3));

                Assert.That(Math.Round(_ml.EntBoilWat(), 3), Is.EqualTo(EntBoilWat).Within(0.001));
                Console.WriteLine("Энтальпия кипятка : expected =" +
                            EntBoilWat + "; actual=" + Math.Round(_ml.EntBoilWat(), 3));

                Assert.That(Math.Round(_ml.WarmQk(), 3), Is.EqualTo(WarmQk).Within(0.001));
                Console.WriteLine("Теплота,затраченная на разложения карбонатов Q_k,кДж : expected =" +
                            WarmQk + "; actual=" + Math.Round(_ml.WarmQk(), 3));

                Assert.That(Math.Round(_ml.WarmFuel(), 3), Is.EqualTo(WarmFuel).Within(0.001));
                Console.WriteLine("Физическое тепло топлива : expected =" +
                            WarmFuel + "; actual=" + Math.Round(_ml.WarmFuel(), 3));

                Assert.That(Math.Round(_ml.WarmBurnLow(), 3), Is.EqualTo(WarmBurnLow).Within(0.001));
                Console.WriteLine("Низшая теплотворная способность (теплота сгорания) топлива : expected =" +
                           WarmBurnLow + "; actual=" + Math.Round(_ml.WarmBurnLow(), 3));

                Assert.That(Math.Round(_ml.LambdaAlpha(), 3), Is.EqualTo(LambdaAlpha).Within(0.001));
                Console.WriteLine("Удельная теплота парообразования : expected =" +
                           LambdaAlpha + "; actual=" + Math.Round(_ml.LambdaAlpha(), 3));

                Assert.That(Math.Round(_ml.N2(), 3), Is.EqualTo(N2).Within(0.001));
                Console.WriteLine("Теплоемкость газов  азота : expected =" +
                          N2 + "; actual=" + Math.Round(_ml.N2(), 3));

                Assert.That(Math.Round(_ml.O2(), 3), Is.EqualTo(O2).Within(0.001));
                Console.WriteLine("Теплоемкость газов  кислорода : expected =" +
                          O2 + "; actual=" + Math.Round(_ml.O2(), 3));

                Assert.That(Math.Round(_ml.CO2(), 3), Is.EqualTo(CO2).Within(0.001));
                Console.WriteLine("Теплоемкость газов  углекислого газа co2 : expected =" +
                          CO2 + "; actual=" + Math.Round(_ml.CO2(), 3));

                Assert.That(Math.Round(_ml.SO2(), 3), Is.EqualTo(SO2).Within(0.001));
                Console.WriteLine("Теплоемкость газов  сернистого газа so2 : expected =" +
                          SO2 + "; actual=" + Math.Round(_ml.SO2(), 3));

                Assert.That(Math.Round(_ml.H2O(), 3), Is.EqualTo(H2O).Within(0.001));
                Console.WriteLine("Теплоемкость газов  воды : expected =" +
                          H2O + "; actual=" + Math.Round(_ml.H2O(), 3));

                Assert.That(Math.Round(_ml.WarmBurnHigh(), 3), Is.EqualTo(WarmBurnHigh).Within(0.001));
                Console.WriteLine("Высшая теплотворная способность (теплота сгорания) топлива : expected =" +
                          WarmBurnHigh + "; actual=" + Math.Round(_ml.WarmBurnHigh(), 3));

                Assert.That(Math.Round(_ml.WarmHave(), 3), Is.EqualTo(WarmHave).Within(0.001));
                Console.WriteLine("Располагаемое тепло,КДж/кг : expected =" +
                          WarmHave + "; actual=" + Math.Round(_ml.WarmHave(), 3));

                Assert.That(Math.Round(_ml.BurnN2(), 3), Is.EqualTo(BurnN2).Within(0.001));
                Console.WriteLine("Cредний состав продуктов сгорания  азота : expected =" +
                          BurnN2 + "; actual=" + Math.Round(_ml.BurnN2(), 3));

                Assert.That(Math.Round(_ml.BurnO2(), 3), Is.EqualTo(BurnO2).Within(0.001));
                Console.WriteLine("Cредний состав продуктов сгорания  кислорода : expected =" +
                          BurnO2 + "; actual=" + Math.Round(_ml.BurnO2(), 3));

                Assert.That(Math.Round(_ml.BurnCO2(), 3), Is.EqualTo(BurnCO2).Within(0.001));
                Console.WriteLine("Cредний состав продуктов сгорания  углекислого газа co2 : expected =" +
                          BurnCO2 + "; actual=" + Math.Round(_ml.BurnCO2(), 3));

                Assert.That(Math.Round(_ml.BurnSO2(), 3), Is.EqualTo(BurnSO2).Within(0.001));
                Console.WriteLine("Cредний состав продуктов сгорания  сернистого газа so2 : expected =" +
                         BurnSO2 + "; actual=" + Math.Round(_ml.BurnSO2(), 3));

                Assert.That(Math.Round(_ml.BurnH2O(), 3), Is.EqualTo(BurnH2O).Within(0.001));
                Console.WriteLine("Cредний состав продуктов сгорания  воды : expected =" +
                          BurnH2O + "; actual=" + Math.Round(_ml.BurnH2O(), 3));


                Assert.That(Math.Round(_ml.VAlpha(), 3), Is.EqualTo(VAlpha).Within(0.001));
                Console.WriteLine("Необходимый объем воздуха : expected =" +
                          VAlpha + "; actual=" + Math.Round(_ml.VAlpha(), 3));

                Assert.That(Math.Round(_ml.EntOutGas(), 3), Is.EqualTo(EntOutGas).Within(0.001));
                Console.WriteLine("Энтальпия уходящих газов, КДж/кг : expected =" +
                          EntOutGas + "; actual=" + Math.Round(_ml.EntOutGas(), 3));

                Assert.That(Math.Round(_ml.LossGas(), 3), Is.EqualTo(LossGas).Within(0.001));
                Console.WriteLine("Потеря с уходящими газами, КДж/кг : expected =" +
                          LossGas + "; actual=" + Math.Round(_ml.LossGas(), 3));

                Assert.That(Math.Round(_ml.LossChem(), 3), Is.EqualTo(LossChem).Within(0.001));
                Console.WriteLine("Потеря от химической неполноты сгорания, КДж/кг : expected =" +
                          LossChem + "; actual=" + Math.Round(_ml.LossChem(), 3));

                Assert.That(Math.Round(_ml.LossMech(), 3), Is.EqualTo(LossMech).Within(0.001));
                Console.WriteLine("Потеря от механической неполноты сгорания, КДж/кг : expected =" +
                          LossMech + "; actual=" + Math.Round(_ml.LossMech(), 3));

                Assert.That(Math.Round(_ml.LossOutCold(), 3), Is.EqualTo(LossOutCold).Within(0.001));
                Console.WriteLine("Потеря от наружного охлаждения, КДж/кг : expected =" +
                          LossOutCold + "; actual=" + Math.Round(_ml.LossOutCold(), 3));

                Assert.That(Math.Round(_ml.LossOutWarm(), 3), Is.EqualTo(LossOutWarm).Within(0.001));
                Console.WriteLine("Потеря от тепла с физ.шлаком.нигде не используется, КДж/кг : expected =" +
                          LossOutWarm + "; actual=" + Math.Round(_ml.LossOutWarm(), 3));

                Assert.That(Math.Round(_ml.LossFullWarm(), 3), Is.EqualTo(LossFullWarm).Within(0.001));
                Console.WriteLine("Расходная часть теплового баланса, КДж/кг : expected =" +
                          LossFullWarm + "; actual=" + Math.Round(_ml.LossFullWarm(), 3));

                Assert.That(Math.Round(_ml.KPD(), 3), Is.EqualTo(KPD).Within(0.001));
                Console.WriteLine("КПД,% : expected =" +
                          KPD + "; actual=" + Math.Round(_ml.KPD(), 3));


                Assert.That(Math.Round(_ml.RashodTopl(), 3), Is.EqualTo(RashodTopl).Within(0.001));
                Console.WriteLine("ИТОГ Часовой расход топлива, кг/с : expected =" +
                          RashodTopl + "; actual=" + Math.Round(_ml.RashodTopl(), 3));





                // Отобразить в журнале тестирования
                Console.WriteLine("");
                Console.WriteLine("--- Результаты расчета");
                Console.WriteLine("Энтальпия питательной воды, Дж, метод EntPitWat(): expected = " +
                            EntPitWat + "; actual=" + Math.Round(_ml.EntPitWat(), 2));
                Console.WriteLine("Энтальпия перегретого пара, Дж, метод EntHeatWat(): expected = " +
                            EntHeatWat + "; actual=" + Math.Round(_ml.EntHeatWat(), 2));
                Console.WriteLine("Энтальпия кипятка, Дж, метод EntBoilWat(): expected = " +
                           EntBoilWat + "; actual=" + Math.Round(_ml.EntBoilWat(), 2));
                Console.WriteLine("Теплота,затраченная на разложения карбонатов Q_k, Дж, метод WarmQk(): expected = " +
                           WarmQk + "; actual=" + Math.Round(_ml.WarmQk(), 2));
                Console.WriteLine("Физическое тепло топлива, метод WarmFuel(): expected = " +
                          WarmFuel + "; actual=" + Math.Round(_ml.WarmFuel(), 2));
                Console.WriteLine("Низшая теплотворная способность (теплота сгорания) топлива, метод WarmBurnLow(): expected = " +
                          WarmBurnLow + "; actual=" + Math.Round(_ml.WarmBurnLow(), 2));

                Console.WriteLine("Удельная теплота парообразования, метод LambdaAlpha(): expected = " +
                         LambdaAlpha + "; actual=" + Math.Round(_ml.LambdaAlpha(), 2));
                Console.WriteLine("Теплоемкость газов  азота, метод N2(): expected = " +
                        N2 + "; actual=" + Math.Round(_ml.N2(), 2));

                Console.WriteLine("Теплоемкость газов  кислорода, метод O2(): expected = " +
                        O2 + "; actual=" + Math.Round(_ml.O2(), 2));
                Console.WriteLine("Теплоемкость   углекислого газа, метод CO2(): expected = " +
                        CO2 + "; actual=" + Math.Round(_ml.CO2(), 2));
                Console.WriteLine("Теплоемкость сернистого газа, метод SO2(): expected = " +
                        SO2 + "; actual=" + Math.Round(_ml.SO2(), 2));
                Console.WriteLine("Теплоемкость газов воды, метод H2O(): expected = " +
                        H2O + "; actual=" + Math.Round(_ml.H2O(), 2));
                Console.WriteLine("Высшая теплотворная способность (теплота сгорания) топлива: expected = " +
                        WarmBurnHigh + "; actual=" + Math.Round(_ml.WarmBurnHigh(), 2));
                Console.WriteLine("Располагаемое тепло,КДж/кг: expected = " +
                       WarmHave + "; actual=" + Math.Round(_ml.WarmHave(), 2));
                Console.WriteLine("Cредний состав продуктов сгорания газов  азота, метод BurnN2(): expected = " +
                       BurnN2 + "; actual=" + Math.Round(_ml.BurnN2(), 2));

                Console.WriteLine("Cредний состав продуктов сгорания  газов кислорода, метод BurnO2(): expected = " +
                        BurnO2 + "; actual=" + Math.Round(_ml.BurnO2(), 2));
                Console.WriteLine("Cредний состав продуктов сгорания  углекислого газа, метод BurnCO2(): expected = " +
                        BurnCO2 + "; actual=" + Math.Round(_ml.BurnCO2(), 2));
                Console.WriteLine("Cредний состав продуктов сгорания сернистого газа, метод BurnSO2(): expected = " +
                        BurnSO2 + "; actual=" + Math.Round(_ml.BurnSO2(), 2));
                Console.WriteLine("Cредний состав продуктов сгорания газов  воды, метод BurnH2O(): expected = " +
                        BurnH2O + "; actual=" + Math.Round(_ml.BurnH2O(), 2));

                Console.WriteLine("Необходимый объем воздуха, метод VAlpha(): expected = " +
                       VAlpha + "; actual=" + Math.Round(_ml.VAlpha(), 2));

                Console.WriteLine("Энтальпия уходящих газов, метод EntOutGas(): expected = " +
                       EntOutGas + "; actual=" + Math.Round(_ml.EntOutGas(), 2));

                Console.WriteLine("Потеря с уходящими газами, метод LossGas(): expected = " +
                       LossGas + "; actual=" + Math.Round(_ml.LossGas(), 2));

                Console.WriteLine("Потеря от химической неполноты сгорания, метод LossChem(): expected = " +
                       LossChem + "; actual=" + Math.Round(_ml.LossChem(), 2));

                Console.WriteLine("Потеря от механической неполноты сгорания, метод LossMech(): expected = " +
                       LossMech + "; actual=" + Math.Round(_ml.LossMech(), 2));

                Console.WriteLine("Потеря от наружного охлаждения, метод LossOutCold(): expected = " +
                       LossOutCold + "; actual=" + Math.Round(_ml.LossOutCold(), 2));

                Console.WriteLine("Потеря от тепла с физ.шлаком.нигде не используется, метод LossOutWarm(): expected = " +
                       LossOutWarm + "; actual=" + Math.Round(_ml.LossOutWarm(), 2));

                Console.WriteLine("Расходная часть теплового баланса, метод LossFullWarm(): expected = " +
                       LossFullWarm + "; actual=" + Math.Round(_ml.LossFullWarm(), 2));

                Console.WriteLine("КПД, метод KPD(): expected = " +
                       KPD + "; actual=" + Math.Round(_ml.KPD(), 2));

                Console.WriteLine("ИТОГ Часовой расход топлива, кг/с, метод RashodTopl(): expected = " +
                       RashodTopl + "; actual=" + Math.Round(_ml.RashodTopl(), 2));







                #endregion  4. Сравнить значения из Excel и из библиотеки с заданной точностью

                WorkBook.Close(false, null, null);
                objExcel.Quit();
            }
            catch
            {
                if (WorkBook != null) WorkBook.Close(false, null, null);
                if (objExcel != null) objExcel.Quit();
            }
            finally
            {
                //WorkBook.Close(false, null, null);
                //objExcel.Quit();
            }
        }


        [SetUp]
        public void Setup()
        {
        }

    }
}