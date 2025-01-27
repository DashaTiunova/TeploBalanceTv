
using NUnit.Framework;
using TeploBalanceKotelMathLib;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System;

namespace TeploBalanceKotelTest
{
    public class UnitTests_ZhidkToplivo
    {
        private string fileName = "��������������������.xls";
        Excel.Application objExcel = null;
        Excel.Workbook WorkBook = null;

        private object oMissing = System.Reflection.Missing.Value;

        /// <summary>
        /// ����� ������������ �������������� ����������
        /// </summary>
        [Test]
        public void CalculationTest_ZhidkToplivo()
        {
            ZhidkToplivo _ml = new ZhidkToplivo();

            #region 1. ��������� �������� ������ 

            _ml.TempPitWat = 30d;
            _ml.TempHeatWat = 160d;
            _ml.Pressure = 2d;
            _ml.ParVyh = 2d;
            _ml.RashWat = 0.7d;
            _ml.TempRabT = 30d;
            _ml.SodH = 10d;
            _ml.SodWP = 3d;
            _ml.SodC = 85d;
            _ml.SodO = 0.9d;
            _ml.SodS = 0.4d;
            _ml.SodN = 0.4d;
            _ml.Alpha = 1.12d;
            _ml.TempVozd = 30d;
            _ml.TempOut = 160d;
            _ml.QChem = 2d;
            _ml.QMech = 1.5d;
            _ml.QCold = 1d;
            _ml.QWarm = 0.1d;

            #endregion 1. ��������� �������� ������

            try
            {
                #region 2. �������� �������� ������ � Excel-����, �������� � ��������������� ������

                objExcel = new Excel.Application();
                WorkBook = objExcel.Workbooks.Open(
                            Directory.GetCurrentDirectory() + "\\" + fileName);
                Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Sheets["������ �������"];

                // Cells[������,�������]
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[34, 2]).Value2 = _ml.TempPitWat;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[37, 2]).Value2 = _ml.TempHeatWat;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[40, 2]).Value2 = _ml.Pressure;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[32, 2]).Value2 = _ml.ParVyh;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[33, 2]).Value2 = _ml.RashWat;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[12, 2]).Value2 = _ml.TempRabT;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[2, 2]).Value2 = _ml.SodH;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[3, 2]).Value2 = _ml.SodWP;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[4, 2]).Value2 = _ml.SodC;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[5, 2]).Value2 = _ml.SodO;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[6, 2]).Value2 = _ml.SodS;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[7, 2]).Value2 = _ml.SodN;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[26, 7]).Value2 = _ml.Alpha;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[25, 7]).Value2 = _ml.TempVozd;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[24, 7]).Value2 = _ml.TempOut;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[25, 4]).Value2 = _ml.QChem;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[26, 4]).Value2 = _ml.QMech;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[27, 4]).Value2 = _ml.QCold;

                // ���������� � ������� ������������ �������� ������
                Console.WriteLine("--- �������� ������");
                Console.WriteLine("����������� ����������� ����, �C - TempPitWat: {0}", _ml.TempPitWat.ToString());
                Console.WriteLine("����������� ����������� ����, �C - TempHeatWat: {0}", _ml.TempHeatWat.ToString());
                Console.WriteLine("�������� ������ ��������, ��� - Pressure: {0}", _ml.Pressure.ToString());
                Console.WriteLine("����� ����, ��/� - ParVyh: {0}", _ml.ParVyh.ToString());
                Console.WriteLine("������ ���� �� �������� �����, ��/� - RashWat: {0}", _ml.RashWat.ToString());
                Console.WriteLine("����������� �������� �������, �� - TempRabT: {0}", _ml.TempRabT.ToString());
                Console.WriteLine("���������� ��������, % - SodH: {0}", _ml.SodH.ToString());
                Console.WriteLine("���������� ������� �����, % - SodWP: {0}", _ml.SodWP.ToString());
                Console.WriteLine("���������� ��������, % - SodC: {0}", _ml.SodC.ToString());
                Console.WriteLine("���������� ���������, % - SodO: {0}", _ml.SodO.ToString());
                Console.WriteLine("���������� ����, % - SodS: {0}", _ml.SodS.ToString());
                Console.WriteLine("���������� �����, % - SodN: {0}", _ml.SodN.ToString());
                Console.WriteLine("����������� ������� ������� - Alpha: {0}", _ml.Alpha.ToString());
                Console.WriteLine("����������� �������, �C - Alpha: {0}", _ml.TempVozd.ToString());
                Console.WriteLine("����������� �������� �����, �C - Alpha: {0}", _ml.TempOut.ToString());
                Console.WriteLine("������ ����� �� ���������� ��������� �������� �������, % - QChem: {0}", _ml.QChem.ToString());
                Console.WriteLine("������ ����� �� ������������ ��������� �������� �������, % - QMech: {0}", _ml.QMech.ToString());
                Console.WriteLine("������ ����� �� ��������� ����������, % - QCold: {0}", _ml.QCold.ToString());

                #endregion 2. �������� �������� ������ � Excel-����, �������� � ��������������� ������

                #region 3. ��������� �� ������ Excel-����� �������� ��������� �������

                double EntPitWat = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[36, 2]).Value.ToString());

                double EntHeatWat = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[39, 2]).Value.ToString());

                double EntBoilWat = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[42, 2]).Value.ToString());

                double WarmQk = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[31, 2]).Value.ToString());

                double WarmFuel = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[18, 2]).Value.ToString());

                double WarmBurnLow = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[17, 2]).Value.ToString());

                double LambdaAlpha = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[14, 2]).Value.ToString());

                double N2 = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[36, 5]).Value.ToString());

                double O2 = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[37, 5]).Value.ToString());

                double CO2 = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[34, 5]).Value.ToString());

                double SO2 = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[35, 5]).Value.ToString());

                double H2O = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[38, 5]).Value.ToString());

                double WarmBurnHigh = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[19, 2]).Value.ToString());

                double WarmHave = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[9, 2]).Value.ToString());
               
                double BurnN2 = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[37, 10]).Value.ToString());

                double BurnO2 = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[38, 10]).Value.ToString());

                double BurnCO2 = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[34, 10]).Value.ToString());

                double BurnSO2 = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[35, 10]).Value.ToString());

                double BurnH2O = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[36, 10]).Value.ToString());

                double VAlpha = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[13, 2]).Value.ToString());

                double EntOutGas = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[23, 7]).Value.ToString());

                double LossGas = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[24, 2]).Value.ToString());

                double LossChem = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[25, 2]).Value.ToString());

                double LossMech = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[26, 2]).Value.ToString());

                double LossOutCold = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[27, 2]).Value.ToString());

                double LossFullWarm = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[23, 2]).Value.ToString());

                double KPD = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[45, 2]).Value.ToString());

                double RashodTopl = double.Parse(((Excel.Range)WorkBook.Sheets["������ �������"].Cells[49, 2]).Value.ToString());

                #endregion 3. ��������� �� ������ Excel-����� �������� ��������� �������

                #region  4. �������� �������� �� Excel � �� ���������� � �������� ���������

                // ���������� � ������� ������������
                Console.WriteLine("");
                Console.WriteLine("--- ���������� �������");

                // �������� ���������� � ����������� �� 3 ������ � ��������� 0.001 � ���������� � ������� ������������
                Assert.That(Math.Round(_ml.EntPitWat(), 3), Is.EqualTo(EntPitWat).Within(0.001));
                Console.WriteLine("��������� ����������� ����, ���/��, ����� EntPitWat() : expected =" +
                            EntPitWat + "; actual=" + Math.Round(_ml.EntPitWat(), 3));

                Assert.That(Math.Round(_ml.EntHeatWat(), 3), Is.EqualTo(EntHeatWat).Within(0.001));
                Console.WriteLine("��������� ����������� ����, ���/��, ����� EntHeatWat() : expected =" +
                            EntHeatWat + "; actual=" + Math.Round(_ml.EntHeatWat(), 3));

                Assert.That(Math.Round(_ml.EntBoilWat(), 3), Is.EqualTo(EntBoilWat).Within(0.001));
                Console.WriteLine("��������� ������� ����, ���/��, ����� EntBoilWat() : expected =" +
                            EntBoilWat + "; actual=" + Math.Round(_ml.EntBoilWat(), 3));

                Assert.That(Math.Round(_ml.WarmQk(), 3), Is.EqualTo(WarmQk).Within(0.001));
                Console.WriteLine("�����, ������� ����������� �� ��������� ����, ���, ����� WarmQk() : expected =" +
                            WarmQk + "; actual=" + Math.Round(_ml.WarmQk(), 3));

                Assert.That(Math.Round(_ml.WarmFuel(), 3), Is.EqualTo(WarmFuel).Within(0.001));
                Console.WriteLine("���������� ����� ����������� �������, ���/��, ����� WarmFuel() : expected =" +
                            WarmFuel + "; actual=" + Math.Round(_ml.WarmFuel(), 3));

                Assert.That(Math.Round(_ml.WarmBurnLow(), 3), Is.EqualTo(WarmBurnLow).Within(0.001));
                Console.WriteLine("������ ������������ ����������� (������� ��������) �������, ���/��, ����� WarmBurnLow() : expected =" +
                           WarmBurnLow + "; actual=" + Math.Round(_ml.WarmBurnLow(), 3));

                Assert.That(Math.Round(_ml.LambdaAlpha(), 3), Is.EqualTo(LambdaAlpha).Within(0.001));
                Console.WriteLine("�������� ������� ���������������, ����� LambdaAlpha() : expected =" +
                           LambdaAlpha + "; actual=" + Math.Round(_ml.LambdaAlpha(), 3));

                Assert.That(Math.Round(_ml.N2(), 3), Is.EqualTo(N2).Within(0.001));
                Console.WriteLine("������������ ����� : expected =" +
                          N2 + "; actual=" + Math.Round(_ml.N2(), 3));

                Assert.That(Math.Round(_ml.O2(), 3), Is.EqualTo(O2).Within(0.001));
                Console.WriteLine("������������ ��������� : expected =" +
                          O2 + "; actual=" + Math.Round(_ml.O2(), 3));

                Assert.That(Math.Round(_ml.CO2(), 3), Is.EqualTo(CO2).Within(0.001));
                Console.WriteLine("������������ ����������� ���� CO2 : expected =" +
                          CO2 + "; actual=" + Math.Round(_ml.CO2(), 3));

                Assert.That(Math.Round(_ml.SO2(), 3), Is.EqualTo(SO2).Within(0.001));
                Console.WriteLine("������������ ���������� ���� SO2 : expected =" +
                          SO2 + "; actual=" + Math.Round(_ml.SO2(), 3));

                Assert.That(Math.Round(_ml.H2O(), 3), Is.EqualTo(H2O).Within(0.001));
                Console.WriteLine("������������ ����� ���� : expected =" +
                          H2O + "; actual=" + Math.Round(_ml.H2O(), 3));

                Assert.That(Math.Round(_ml.WarmBurnHigh(), 3), Is.EqualTo(WarmBurnHigh).Within(0.001));
                Console.WriteLine("������ ������������ ����������� (������� ��������) ������� : expected =" +
                          WarmBurnHigh + "; actual=" + Math.Round(_ml.WarmBurnHigh(), 3));

                Assert.That(Math.Round(_ml.WarmHave(), 3), Is.EqualTo(WarmHave).Within(0.001));
                Console.WriteLine("������������� �����, ���/�� : expected =" +
                          WarmHave + "; actual=" + Math.Round(_ml.WarmHave(), 3));

                Assert.That(Math.Round(_ml.BurnN2(), 3), Is.EqualTo(BurnN2).Within(0.001));
                Console.WriteLine("C������ ������ ��������� �������� - ����� : expected =" +
                          BurnN2 + "; actual=" + Math.Round(_ml.BurnN2(), 3));

                Assert.That(Math.Round(_ml.BurnO2(), 3), Is.EqualTo(BurnO2).Within(0.001));
                Console.WriteLine("C������ ������ ��������� �������� - ��������� : expected =" +
                          BurnO2 + "; actual=" + Math.Round(_ml.BurnO2(), 3));

                Assert.That(Math.Round(_ml.BurnCO2(), 3), Is.EqualTo(BurnCO2).Within(0.001));
                Console.WriteLine("C������ ������ ��������� �������� - ����������� ���� CO2 : expected =" +
                          BurnCO2 + "; actual=" + Math.Round(_ml.BurnCO2(), 3));

                Assert.That(Math.Round(_ml.BurnSO2(), 3), Is.EqualTo(BurnSO2).Within(0.001));
                Console.WriteLine("C������ ������ ��������� �������� - ���������� ���� SO2 : expected =" +
                         BurnSO2 + "; actual=" + Math.Round(_ml.BurnSO2(), 3));

                Assert.That(Math.Round(_ml.BurnH2O(), 3), Is.EqualTo(BurnH2O).Within(0.001));
                Console.WriteLine("C������ ������ ��������� �������� - ���� ���� : expected =" +
                          BurnH2O + "; actual=" + Math.Round(_ml.BurnH2O(), 3));

                Assert.That(Math.Round(_ml.VAlpha(), 3), Is.EqualTo(VAlpha).Within(0.001));
                Console.WriteLine("����������� ����� ������� : expected =" +
                          VAlpha + "; actual=" + Math.Round(_ml.VAlpha(), 3));

                Assert.That(Math.Round(_ml.EntOutGas(), 3), Is.EqualTo(EntOutGas).Within(0.001));
                Console.WriteLine("��������� �������� �����, ���/�� : expected =" +
                          EntOutGas + "; actual=" + Math.Round(_ml.EntOutGas(), 3));

                Assert.That(Math.Round(_ml.LossGas(), 3), Is.EqualTo(LossGas).Within(0.001));
                Console.WriteLine("������ � ��������� ������, ���/�� : expected =" +
                          LossGas + "; actual=" + Math.Round(_ml.LossGas(), 3));

                Assert.That(Math.Round(_ml.LossChem(), 3), Is.EqualTo(LossChem).Within(0.001));
                Console.WriteLine("������ �� ���������� ��������� ��������, ���/�� : expected =" +
                          LossChem + "; actual=" + Math.Round(_ml.LossChem(), 3));

                Assert.That(Math.Round(_ml.LossMech(), 3), Is.EqualTo(LossMech).Within(0.001));
                Console.WriteLine("������ �� ������������ ��������� ��������, ���/�� : expected =" +
                          LossMech + "; actual=" + Math.Round(_ml.LossMech(), 3));

                Assert.That(Math.Round(_ml.LossOutCold(), 3), Is.EqualTo(LossOutCold).Within(0.001));
                Console.WriteLine("������ �� ��������� ����������, ���/�� : expected =" +
                          LossOutCold + "; actual=" + Math.Round(_ml.LossOutCold(), 3));

                Assert.That(Math.Round(_ml.LossFullWarm(), 3), Is.EqualTo(LossFullWarm).Within(0.001));
                Console.WriteLine("��������� ����� ��������� �������, ���/�� : expected =" +
                          LossFullWarm + "; actual=" + Math.Round(_ml.LossFullWarm(), 3));

                Assert.That(Math.Round(_ml.KPD(), 3), Is.EqualTo(KPD).Within(0.001));
                Console.WriteLine("��� �����,% : expected =" +
                          KPD + "; actual=" + Math.Round(_ml.KPD(), 3));

                Assert.That(Math.Round(_ml.RashodTopl(), 3), Is.EqualTo(RashodTopl).Within(0.001));
                Console.WriteLine("���� ������ �������, ��/� : expected =" +
                          RashodTopl + "; actual=" + Math.Round(_ml.RashodTopl(), 3));                            

                #endregion  4. �������� �������� �� Excel � �� ���������� � �������� ���������

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