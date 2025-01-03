using NUnit.Framework;
using TeploBalanceKotelMathLib;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System;

namespace TeploBalanceKotelTest
{
    public class UnitTests_GasToplivo
    {
        private string fileName = "ТепловойРасчетКотлов.xls";
        Excel.Application objExcel = null;
        Excel.Workbook WorkBook = null;

        private object oMissing = System.Reflection.Missing.Value;

        /// <summary>
        /// Метод тестирования математической библиотеки
        /// </summary>
        [Test]
        public void CalculationTest_GasToplivo()
        {
            GasToplivo _ml = new GasToplivo();

            #region 1. Присвоить исходные данные 

            _ml.TempPitWat = 30d;
            _ml.TempHeatWat = 200d;
            _ml.Pressure = 2d;
            _ml.ParVyh = 2d;
            _ml.RashWat = 0.7d;
            _ml.TempRabT = 30d;
            _ml.SodCH4 = 94.23d;
            _ml.SodC2H6 = 3d;
            _ml.SodC3H8 = 0.89d;
            _ml.SodC4H10 = 0.39d;
            _ml.SodC5H12 = 0.17d;
            _ml.SodC6H14 = 0.13d;
            _ml.SodCO = 0d;
            _ml.SodCO2 = 0.29d;
            _ml.SodN2 = 0.9d;
            _ml.SodO2 = 0d;
            _ml.SodH2S = 0d;
            _ml.SodH2 = 0d;
            _ml.Alpha = 1.12d;
            _ml.TempVozd = 30d;
            _ml.TempOut = 160d;
            _ml.QChem = 2d;
            _ml.QMech = 1.5d;
            _ml.QCold = 1d;
            

            #endregion 1. Присвоить исходные данные

            try
            {
                #region 2. Передать исходные данные в Excel-файл, записать в соответствующие ячейки

                objExcel = new Excel.Application();
                WorkBook = objExcel.Workbooks.Open(
                            Directory.GetCurrentDirectory() + "\\" + fileName);
                Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Sheets["Газообразное топливо"];

                // Cells[СТРОКА,СТОЛБЕЦ]
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[38, 2]).Value2 = _ml.TempPitWat;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[41, 2]).Value2 = _ml.TempHeatWat;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[44, 2]).Value2 = _ml.Pressure;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[36, 2]).Value2 = _ml.ParVyh;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[37, 2]).Value2 = _ml.RashWat;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[18, 2]).Value2 = _ml.TempRabT;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[3, 2]).Value2 = _ml.SodCH4;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[4, 2]).Value2 = _ml.SodC2H6;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[5, 2]).Value2 = _ml.SodC3H8;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[6, 2]).Value2 = _ml.SodC4H10;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[7, 2]).Value2 = _ml.SodC5H12;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[8, 2]).Value2 = _ml.SodC6H14;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[9, 2]).Value2 = _ml.SodCO;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[10, 2]).Value2 = _ml.SodCO2;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[11, 2]).Value2 = _ml.SodN2;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[12, 2]).Value2 = _ml.SodO2;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[13, 2]).Value2 = _ml.SodH2S;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[14, 2]).Value2 = _ml.SodH2;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[31, 7]).Value2 = _ml.Alpha;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[30, 7]).Value2 = _ml.TempVozd;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[29, 7]).Value2 = _ml.TempOut;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[30, 4]).Value2 = _ml.QChem;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[31, 4]).Value2 = _ml.QMech;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[32, 4]).Value2 = _ml.QCold;

                // Отобразить в журнале тестирования исходные данные
                Console.WriteLine("--- Исходные данные");
                Console.WriteLine("Температура питательной воды, °C - TempPitWat: {0}", _ml.TempPitWat.ToString());
                Console.WriteLine("Температура перегретого пара, °C - TempHeatWat: {0}", _ml.TempHeatWat.ToString());
                Console.WriteLine("Давление внутри барабана, атм - Pressure: {0}", _ml.Pressure.ToString());
                Console.WriteLine("Выход пара, кг/с - ParVyh: {0}", _ml.ParVyh.ToString());
                Console.WriteLine("Расход воды на продувку котла, кг/с - RashWat: {0}", _ml.RashWat.ToString());
                Console.WriteLine("Температура рабочего топлива, °С - TempRabT: {0}", _ml.TempRabT.ToString());
                Console.WriteLine("Содержание CH4, % - SodСH4: {0}", _ml.SodCH4.ToString());
                Console.WriteLine("Содержание C2H6, % - SodC2H6: {0}", _ml.SodC2H6.ToString());
                Console.WriteLine("Содержание C3H8, % - SodC3H8: {0}", _ml.SodC3H8.ToString());
                Console.WriteLine("Содержание C4H10, % - SodC4H10: {0}", _ml.SodC4H10.ToString());
                Console.WriteLine("Содержание C5H12, % - SodC5H12: {0}", _ml.SodC5H12.ToString());
                Console.WriteLine("Содержание C6H14, % - SodC6H14: {0}", _ml.SodC6H14.ToString());
                Console.WriteLine("Содержание CO, % - SodCO: {0}", _ml.SodCO.ToString());
                Console.WriteLine("Содержание CO2, % - SodCO2: {0}", _ml.SodCO2.ToString());
                Console.WriteLine("Содержание N2, % - SodN2: {0}", _ml.SodN2.ToString());
                Console.WriteLine("Содержание O2, % - SodO2: {0}", _ml.SodO2.ToString());
                Console.WriteLine("Содержание H2S, % - SodH2S: {0}", _ml.SodH2S.ToString());
                Console.WriteLine("Содержание H2, % - SodH2: {0}", _ml.SodH2.ToString());
                Console.WriteLine("Коэффициент избытка воздуха - Alpha: {0}", _ml.Alpha.ToString());
                Console.WriteLine("Температура воздуха, °C -TempVozd: {0}", _ml.TempVozd.ToString());
                Console.WriteLine("Температура уходящих газов, °C - TempOut: {0}", _ml.TempOut.ToString());
                Console.WriteLine("Потери тепла от химической неполноты сгорания топлива, % - QChem: {0}", _ml.QChem.ToString());
                Console.WriteLine("Потери тепла от механической неполноты сгорания топлива, % - QMech: {0}", _ml.QMech.ToString());
                Console.WriteLine("Потери тепла от наружного охлаждения, % - QCold: {0}", _ml.QCold.ToString());

                #endregion 2. Передать исходные данные в Excel-файл, записать в соответствующие ячейки

                #region 3. Прочитать из ячейки Excel-файла значение расчетных величин

                double EntPitWat = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[40, 2]).Value.ToString());

                double EntHeatWat = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[43, 2]).Value.ToString());

                double EntBoilWat = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[46, 2]).Value.ToString());

                double WarmQk = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[35, 2]).Value.ToString());

                double WarmFuel = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[16, 2]).Value.ToString());

                double WarmBurnLow = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[22, 2]).Value.ToString());

                double LambdaAlpha = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[20, 2]).Value.ToString());

                double N2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[42, 5]).Value.ToString());

                double O2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[43, 5]).Value.ToString());

                double CO2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[39, 5]).Value.ToString());

                double SO2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[40, 5]).Value.ToString());

                double H2O = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[41, 5]).Value.ToString());

                double WarmBurnHigh = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[24, 2]).Value.ToString());

                double WarmHave = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[15, 2]).Value.ToString());
               
                double BurnN2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[42, 10]).Value.ToString());

                double BurnO2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[43, 10]).Value.ToString());

                double BurnCO2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[39, 10]).Value.ToString());

                double BurnSO2 = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[40, 10]).Value.ToString());

                double BurnH2O = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[41, 10]).Value.ToString());

                double VAlpha = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[19, 2]).Value.ToString());

                double EntOutGas = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[28, 7]).Value.ToString());

                double LossGas = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[29, 2]).Value.ToString());

                double LossChem = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[30, 2]).Value.ToString());

                double LossMech = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[31, 2]).Value.ToString());

                double LossOutCold = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[32, 2]).Value.ToString());

                double LossFullWarm = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[28, 2]).Value.ToString());

                double KPD = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[50, 2]).Value.ToString());

                double RashodTopl = double.Parse(((Excel.Range)WorkBook.Sheets["Газообразное топливо"].Cells[53, 2]).Value.ToString());

                #endregion 3. Прочитать из ячейки Excel-файла значение расчетных величин

                #region  4. Сравнить значения из Excel и из библиотеки с заданной точностью

                // Отобразить в журнале тестирования
                Console.WriteLine("");
                Console.WriteLine("--- Результаты расчета");

                // Проверка совпадения с округлением до 3 знаков и точностью 0.001 и отобразить в журнале тестирования
                Assert.That(Math.Round(_ml.EntPitWat(), 3), Is.EqualTo(EntPitWat).Within(0.001));
                Console.WriteLine("Энтальпия питательной воды, кДж/кг, метод EntPitWat() : expected =" +
                            EntPitWat + "; actual=" + Math.Round(_ml.EntPitWat(), 3));

                Assert.That(Math.Round(_ml.EntHeatWat(), 3), Is.EqualTo(EntHeatWat).Within(0.001));
                Console.WriteLine("Энтальпия перегретого пара, кДж/кг, метод EntHeatWat() : expected =" +
                            EntHeatWat + "; actual=" + Math.Round(_ml.EntHeatWat(), 3));

                Assert.That(Math.Round(_ml.EntBoilWat(), 3), Is.EqualTo(EntBoilWat).Within(0.001));
                Console.WriteLine("Энтальпия кипящей воды, кДж/кг, метод EntBoilWat() : expected =" +
                            EntBoilWat + "; actual=" + Math.Round(_ml.EntBoilWat(), 3));

                Assert.That(Math.Round(_ml.WarmQk(), 3), Is.EqualTo(WarmQk).Within(0.001));
                Console.WriteLine("Тепло, полезно затраченное на выработку пара, кВт, метод WarmQk() : expected =" +
                            WarmQk + "; actual=" + Math.Round(_ml.WarmQk(), 3));

                Assert.That(Math.Round(_ml.WarmFuel(), 3), Is.EqualTo(WarmFuel).Within(0.001));
                Console.WriteLine("Физическое тепло подогретого топлива, кДж/кг, метод WarmFuel() : expected =" +
                            WarmFuel + "; actual=" + Math.Round(_ml.WarmFuel(), 3));

                Assert.That(Math.Round(_ml.WarmBurnLow(), 3), Is.EqualTo(WarmBurnLow).Within(0.001));
                Console.WriteLine("Низшая теплотворная способность (теплота сгорания) топлива, кДж/кг, метод WarmBurnLow() : expected =" +
                           WarmBurnLow + "; actual=" + Math.Round(_ml.WarmBurnLow(), 3));

                Assert.That(Math.Round(_ml.LambdaAlpha(), 3), Is.EqualTo(LambdaAlpha).Within(0.001));
                Console.WriteLine("Удельная теплота парообразования, метод LambdaAlpha() : expected =" +
                           LambdaAlpha + "; actual=" + Math.Round(_ml.LambdaAlpha(), 3));

                Assert.That(Math.Round(_ml.N2(), 3), Is.EqualTo(N2).Within(0.001));
                Console.WriteLine("Теплоемкость азота : expected =" +
                          N2 + "; actual=" + Math.Round(_ml.N2(), 3));

                Assert.That(Math.Round(_ml.O2(), 3), Is.EqualTo(O2).Within(0.001));
                Console.WriteLine("Теплоемкость кислорода : expected =" +
                          O2 + "; actual=" + Math.Round(_ml.O2(), 3));

                Assert.That(Math.Round(_ml.CO2(), 3), Is.EqualTo(CO2).Within(0.001));
                Console.WriteLine("Теплоемкость углекислого газа CO2 : expected =" +
                          CO2 + "; actual=" + Math.Round(_ml.CO2(), 3));

                Assert.That(Math.Round(_ml.SO2(), 3), Is.EqualTo(SO2).Within(0.001));
                Console.WriteLine("Теплоемкость сернистого газа SO2 : expected =" +
                          SO2 + "; actual=" + Math.Round(_ml.SO2(), 3));

                Assert.That(Math.Round(_ml.H2O(), 3), Is.EqualTo(H2O).Within(0.001));
                Console.WriteLine("Теплоемкость паров воды : expected =" +
                          H2O + "; actual=" + Math.Round(_ml.H2O(), 3));

                Assert.That(Math.Round(_ml.WarmBurnHigh(), 3), Is.EqualTo(WarmBurnHigh).Within(0.001));
                Console.WriteLine("Высшая теплотворная способность (теплота сгорания) топлива : expected =" +
                          WarmBurnHigh + "; actual=" + Math.Round(_ml.WarmBurnHigh(), 3));

                Assert.That(Math.Round(_ml.WarmHave(), 3), Is.EqualTo(WarmHave).Within(0.001));
                Console.WriteLine("Располагаемое тепло, КДж/кг : expected =" +
                          WarmHave + "; actual=" + Math.Round(_ml.WarmHave(), 3));

                Assert.That(Math.Round(_ml.BurnN2(), 3), Is.EqualTo(BurnN2).Within(0.001));
                Console.WriteLine("Cредний состав продуктов сгорания - азота : expected =" +
                          BurnN2 + "; actual=" + Math.Round(_ml.BurnN2(), 3));

                Assert.That(Math.Round(_ml.BurnO2(), 3), Is.EqualTo(BurnO2).Within(0.001));
                Console.WriteLine("Cредний состав продуктов сгорания - кислорода : expected =" +
                          BurnO2 + "; actual=" + Math.Round(_ml.BurnO2(), 3));

                Assert.That(Math.Round(_ml.BurnCO2(), 3), Is.EqualTo(BurnCO2).Within(0.001));
                Console.WriteLine("Cредний состав продуктов сгорания - углекислого газа CO2 : expected =" +
                          BurnCO2 + "; actual=" + Math.Round(_ml.BurnCO2(), 3));

                Assert.That(Math.Round(_ml.BurnSO2(), 3), Is.EqualTo(BurnSO2).Within(0.001));
                Console.WriteLine("Cредний состав продуктов сгорания - сернистого газа SO2 : expected =" +
                         BurnSO2 + "; actual=" + Math.Round(_ml.BurnSO2(), 3));

                Assert.That(Math.Round(_ml.BurnH2O(), 3), Is.EqualTo(BurnH2O).Within(0.001));
                Console.WriteLine("Cредний состав продуктов сгорания - пары воды : expected =" +
                          BurnH2O + "; actual=" + Math.Round(_ml.BurnH2O(), 3));

                Assert.That(Math.Round(_ml.VAlpha(), 3), Is.EqualTo(VAlpha).Within(0.001));
                Console.WriteLine("Необходимый объем воздуха : expected =" +
                          VAlpha + "; actual=" + Math.Round(_ml.VAlpha(), 3));

                Assert.That(Math.Round(_ml.EntOutGas(), 3), Is.EqualTo(EntOutGas).Within(0.001));
                Console.WriteLine("Энтальпия уходящих газов, кДж/кг : expected =" +
                          EntOutGas + "; actual=" + Math.Round(_ml.EntOutGas(), 3));

                Assert.That(Math.Round(_ml.LossGas(), 3), Is.EqualTo(LossGas).Within(0.001));
                Console.WriteLine("Потеря с уходящими газами, кДж/кг : expected =" +
                          LossGas + "; actual=" + Math.Round(_ml.LossGas(), 3));

                Assert.That(Math.Round(_ml.LossChem(), 3), Is.EqualTo(LossChem).Within(0.001));
                Console.WriteLine("Потеря от химической неполноты сгорания, кДж/кг : expected =" +
                          LossChem + "; actual=" + Math.Round(_ml.LossChem(), 3));

                Assert.That(Math.Round(_ml.LossMech(), 3), Is.EqualTo(LossMech).Within(0.001));
                Console.WriteLine("Потеря от механической неполноты сгорания, кДж/кг : expected =" +
                          LossMech + "; actual=" + Math.Round(_ml.LossMech(), 3));

                Assert.That(Math.Round(_ml.LossOutCold(), 3), Is.EqualTo(LossOutCold).Within(0.001));
                Console.WriteLine("Потеря от наружного охлаждения, кДж/кг : expected =" +
                          LossOutCold + "; actual=" + Math.Round(_ml.LossOutCold(), 3));

                Assert.That(Math.Round(_ml.LossFullWarm(), 3), Is.EqualTo(LossFullWarm).Within(0.001));
                Console.WriteLine("Расходная часть теплового баланса, кДж/кг : expected =" +
                          LossFullWarm + "; actual=" + Math.Round(_ml.LossFullWarm(), 3));

                Assert.That(Math.Round(_ml.KPD(), 3), Is.EqualTo(KPD).Within(0.001));
                Console.WriteLine("КПД котла,% : expected =" +
                          KPD + "; actual=" + Math.Round(_ml.KPD(), 3));

                Assert.That(Math.Round(_ml.RashodTopl(), 3), Is.EqualTo(RashodTopl).Within(0.001));
                Console.WriteLine("ИТОГ Расход топлива, кг/с : expected =" +
                          RashodTopl + "; actual=" + Math.Round(_ml.RashodTopl(), 3));                            

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