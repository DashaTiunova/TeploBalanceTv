using RecuperatorLibrary;
using Excel = Microsoft.Office.Interop.Excel;

namespace RecuperatorTest
{
    public class Tests
    {
        private string fileName = "Металлический петлевой рекуператор.xls";
        Excel.Application objExcel = null;
        Excel.Workbook WorkBook = null;

        private object oMissing = System.Reflection.Missing.Value;

        /// <summary>
        /// Метод тестирования математической библиотеки
        /// </summary>
        [Test]
        public void CalculationTest_MathLib()
        {
            MathLib _ml = new MathLib();

            #region 1. Присвоить исходные данные 

            _ml.Temp_Air_Output = 300d;
            _ml.Temp_Air_Input = 20d;
            _ml.Temp_Product_Input = 800d;
            _ml.Consump_Air = 7.5;
            _ml.Consump_Product = 9.9;
            _ml.Percent_CO2 = 12.47;
            _ml.Percent_H2O = 11.89;
            _ml.Radius_Section = 1850d;

            #endregion 1. Присвоить исходные данные

            try
            {
                #region 2. Передать исходные данные в Excel-файл, записать в соответствующие ячейки

                objExcel = new Excel.Application();
                WorkBook = objExcel.Workbooks.Open(
                            Directory.GetCurrentDirectory() + "\\" + fileName);
                Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Sheets["Исходные данные"];
                Excel.Worksheet WorkSheet1 = (Excel.Worksheet)WorkBook.Sheets["Справочные данные"];

                // Cells[СТРОКА,СТОЛБЕЦ]

                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[16, 9]).Value2 = _ml.Temp_Air_Output;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[17, 9]).Value2 = _ml.Temp_Air_Input;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[18, 9]).Value2 = _ml.Temp_Product_Input;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[20, 9]).Value2 = _ml.Consump_Air;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[27, 9]).Value2 = _ml.Consump_Product;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[28, 9]).Value2 = _ml.Percent_CO2;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[29, 9]).Value2 = _ml.Percent_H2O;
                ((Microsoft.Office.Interop.Excel.Range)WorkSheet1.Cells[64, 8]).Value2 = _ml.Radius_Section;

                // Отобразить в журнале тестирования
                Console.WriteLine("--- Исходные данные");
                Console.WriteLine("Температура воздуха на выходе из рекуператора, °С - Temp_Air_Output: {0}", _ml.Temp_Air_Output.ToString());
                Console.WriteLine("Температура воздуха на входе в рекуператор, °С - Temp_Air_Input: {0}", _ml.Temp_Air_Input.ToString());
                Console.WriteLine("Температура продуктов сгорания перед рекуператором, °С - Temp_Product_Input: {0}", _ml.Temp_Product_Input.ToString());
                Console.WriteLine("Расход воздуха, м3/с - Consump_Air: {0}", _ml.Consump_Air.ToString());
                Console.WriteLine("Расход продуктов сгорания, м3/с - Consump_Product: {0}", _ml.Consump_Product.ToString());
                Console.WriteLine("Количество CO2, % - Percent_CO2: {0}", _ml.Percent_CO2.ToString());
                Console.WriteLine("Количество H2O, % - Percent_H2O: {0}", _ml.Percent_H2O.ToString());
                Console.WriteLine("Справочные данные - радиус секции - Radius_Section: {0}", _ml.Radius_Section.ToString());

                #endregion 2. Передать исходные данные в Excel-файл, записать в соответствующие ячейки

                #region 3. Прочитать из ячейки Excel-файла значение расчетных величин

                double Heat_Capacity_Air = double.Parse(((Excel.Range)WorkBook.Sheets["Исходные данные"].Cells[21, 9]).Value.ToString());
                double Heat_Capacity_Smoke = double.Parse(((Excel.Range)WorkBook.Sheets["Исходные данные"].Cells[22, 9]).Value.ToString());
                double Entalp_Air_Start_Temp = double.Parse(((Excel.Range)WorkBook.Sheets["Исходные данные"].Cells[23, 9]).Value.ToString());
                double Entalp_Air_End_Temp = double.Parse(((Excel.Range)WorkBook.Sheets["Исходные данные"].Cells[24, 9]).Value.ToString());
                double Entalp_Smoke_Start_Temp = double.Parse(((Excel.Range)WorkBook.Sheets["Исходные данные"].Cells[25, 9]).Value.ToString());
                double Average_Temp_Air = double.Parse(((Excel.Range)WorkBook.Sheets["Исходные данные"].Cells[30, 9]).Value.ToString());
                double Average_Temp_Smoke = double.Parse(((Excel.Range)WorkBook.Sheets["Исходные данные"].Cells[31, 9]).Value.ToString());
                double Average_Temp_Wall = double.Parse(((Excel.Range)WorkBook.Sheets["Исходные данные"].Cells[32, 9]).Value.ToString());
                double Otnosh_Temp = double.Parse(((Excel.Range)WorkBook.Sheets["Исходные данные"].Cells[33, 9]).Value.ToString());
                double Fact_Speed_Air = double.Parse(((Excel.Range)WorkBook.Sheets["Исходные данные"].Cells[54, 9]).Value.ToString());
                double Fact_Speed_Product = double.Parse(((Excel.Range)WorkBook.Sheets["Исходные данные"].Cells[55, 9]).Value.ToString());
                double Real_Speed_Air = double.Parse(((Excel.Range)WorkBook.Sheets["Исходные данные"].Cells[56, 9]).Value.ToString());
                double Real_Speed_Product = double.Parse(((Excel.Range)WorkBook.Sheets["Исходные данные"].Cells[57, 9]).Value.ToString());
                double Cp_Hp = double.Parse(((Excel.Range)WorkBook.Sheets["Исходные данные"].Cells[58, 9]).Value.ToString());

                double Heat_Air = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[8, 4]).Value.ToString());
                double Heat_Input_Product = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[9, 4]).Value.ToString());
                double Heat_Output_Product = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[10, 4]).Value.ToString());
                double Entalp_Product = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[11, 4]).Value.ToString());
                double Temp_Product_Output = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[12, 4]).Value.ToString());
                double Average_Log_Temp = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[13, 4]).Value.ToString());
                double Heat_Parameter1 = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[14, 4]).Value.ToString());
                double Heat_Parameter2 = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[15, 4]).Value.ToString());

                double Reynolds_Number_1 = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[20, 4]).Value.ToString());
                double Popravka_Coef_Heat = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[21, 4]).Value.ToString());
                double Popravka_Coef_Heat_Bend = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[23, 4]).Value.ToString());
                double Sum_Popravka_Coef_1 = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[24, 4]).Value.ToString());
                double Nusselt_Number_1 = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[25, 4]).Value.ToString());
                double Coef_Heat_Convention_Air_Way = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[26, 4]).Value.ToString());
                double Coef_Heat_Convention_Surface_External = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[27, 4]).Value.ToString());
                double Reynolds_Number_2 = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[29, 4]).Value.ToString());
                double Sum_Popravka_Coef_2 = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[32, 4]).Value.ToString());
                double Nusselt_Number_2 = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[33, 4]).Value.ToString());
                double Coef_Convention_Heat = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[34, 4]).Value.ToString());
                double Eff_Ray_Length = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[36, 4]).Value.ToString());
                double Coef_Gas_Environment = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[37, 4]).Value.ToString());
                double Binding_Value = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[41, 4]).Value.ToString());
                double Temporary_Value_Ray = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[45, 4]).Value.ToString());
                double Coef_Ray_Heat = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[46, 4]).Value.ToString());
                double Sum_Coef_Heat_Wall = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[47, 4]).Value.ToString());
                double Coef_Heat = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[48, 4]).Value.ToString());
                double Coef_Heat_Contamination = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[49, 4]).Value.ToString());
                double Surface_Heat = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[50, 4]).Value.ToString());

                double Density_Heat_Flow = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[54, 4]).Value.ToString());
                double Max_Temp_Wall = double.Parse(((Excel.Range)WorkBook.Sheets["Методика расчета"].Cells[55, 4]).Value.ToString());

                #endregion 3. Прочитать из ячейки Excel-файла значение расчетных величин

                #region  4. Сравнить значения из Excel и из библиотеки с заданной точностью

                // Проверка совпадения с округлением до 3 знаков и точностью 0.001
                Assert.That(Math.Round(_ml.Heat_Capacity_Air(), 3), Is.EqualTo(Heat_Capacity_Air).Within(0.001));
                Assert.That(Math.Round(_ml.Heat_Capacity_Smoke(), 3), Is.EqualTo(Heat_Capacity_Smoke).Within(0.001));
                Assert.That(Math.Round(_ml.Entalp_Air_Start_Temp(), 3), Is.EqualTo(Entalp_Air_Start_Temp).Within(0.001));
                Assert.That(Math.Round(_ml.Entalp_Air_End_Temp(), 3), Is.EqualTo(Entalp_Air_End_Temp).Within(0.001));
                Assert.That(Math.Round(_ml.Entalp_Smoke_Start_Temp(), 3), Is.EqualTo(Entalp_Smoke_Start_Temp).Within(0.001));
                Assert.That(Math.Round(_ml.Heat_Air(), 3), Is.EqualTo(Heat_Air).Within(0.001));
                Assert.That(Math.Round(_ml.Heat_Input_Product(), 3), Is.EqualTo(Heat_Input_Product).Within(0.001));
                Assert.That(Math.Round(_ml.Heat_Output_Product(), 3), Is.EqualTo(Heat_Output_Product).Within(0.001));
                Assert.That(Math.Round(_ml.Entalp_Product(), 3), Is.EqualTo(Entalp_Product).Within(0.001));
                Assert.That(Math.Round(_ml.Temp_Product_Output(), 3), Is.EqualTo(Temp_Product_Output).Within(0.001));
                Assert.That(Math.Round(_ml.Average_Temp_Air(), 3), Is.EqualTo(Average_Temp_Air).Within(0.001));
                Assert.That(Math.Round(_ml.Average_Temp_Smoke(), 3), Is.EqualTo(Average_Temp_Smoke).Within(0.001));
                Assert.That(Math.Round(_ml.Average_Temp_Wall(), 3), Is.EqualTo(Average_Temp_Wall).Within(0.001));
                Assert.That(Math.Round(_ml.Otnosh_Temp(), 3), Is.EqualTo(Otnosh_Temp).Within(0.001));
                Assert.That(Math.Round(_ml.Fact_Speed_Air(), 3), Is.EqualTo(Fact_Speed_Air).Within(0.001));
                Assert.That(Math.Round(_ml.Fact_Speed_Product(), 3), Is.EqualTo(Fact_Speed_Product).Within(0.001));
                Assert.That(Math.Round(_ml.Real_Speed_Air(), 3), Is.EqualTo(Real_Speed_Air).Within(0.001));
                Assert.That(Math.Round(_ml.Real_Speed_Product(), 3), Is.EqualTo(Real_Speed_Product).Within(0.001));
                Assert.That(Math.Round(_ml.Cp_Hp(), 3), Is.EqualTo(Cp_Hp).Within(0.001));
                Assert.That(Math.Round(_ml.Average_Log_Temp(), 3), Is.EqualTo(Average_Log_Temp).Within(0.001));
                Assert.That(Math.Round(_ml.Heat_Parameter1(), 3), Is.EqualTo(Heat_Parameter1).Within(0.001));
                Assert.That(Math.Round(_ml.Heat_Parameter2(), 3), Is.EqualTo(Heat_Parameter2).Within(0.001));
                Assert.That(Math.Round(_ml.Reynolds_Number_1(), 3), Is.EqualTo(Reynolds_Number_1).Within(0.001));
                Assert.That(Math.Round(_ml.Popravka_Coef_Heat(), 3), Is.EqualTo(Popravka_Coef_Heat).Within(0.001));
                Assert.That(Math.Round(_ml.Popravka_Coef_Heat_Bend(), 3), Is.EqualTo(Popravka_Coef_Heat_Bend).Within(0.001));
                Assert.That(Math.Round(_ml.Sum_Popravka_Coef_1(), 3), Is.EqualTo(Sum_Popravka_Coef_1).Within(0.001));
                Assert.That(Math.Round(_ml.Nusselt_Number_1(), 3), Is.EqualTo(Nusselt_Number_1).Within(0.001));
                Assert.That(Math.Round(_ml.Coef_Heat_Convention_Air_Way(), 3), Is.EqualTo(Coef_Heat_Convention_Air_Way).Within(0.001));
                Assert.That(Math.Round(_ml.Coef_Heat_Convention_Surface_External(), 3), Is.EqualTo(Coef_Heat_Convention_Surface_External).Within(0.001));
                Assert.That(Math.Round(_ml.Reynolds_Number_2(), 3), Is.EqualTo(Reynolds_Number_2).Within(0.001));
                Assert.That(Math.Round(_ml.Sum_Popravka_Coef_2(), 3), Is.EqualTo(Sum_Popravka_Coef_2).Within(0.001));
                Assert.That(Math.Round(_ml.Nusselt_Number_2(), 3), Is.EqualTo(Nusselt_Number_2).Within(0.001));
                Assert.That(Math.Round(_ml.Coef_Convention_Heat(), 3), Is.EqualTo(Coef_Convention_Heat).Within(0.001));
                Assert.That(Math.Round(_ml.Eff_Ray_Length(), 3), Is.EqualTo(Eff_Ray_Length).Within(0.001));
                Assert.That(Math.Round(_ml.Coef_Gas_Environment(), 3), Is.EqualTo(Coef_Gas_Environment).Within(0.001));
                Assert.That(Math.Round(_ml.Binding_Value(), 3), Is.EqualTo(Binding_Value).Within(0.001));
                Assert.That(Math.Round(_ml.Temporary_Value_Ray(), 3), Is.EqualTo(Temporary_Value_Ray).Within(0.001));
                Assert.That(Math.Round(_ml.Coef_Ray_Heat(), 3), Is.EqualTo(Coef_Ray_Heat).Within(0.001));
                Assert.That(Math.Round(_ml.Sum_Coef_Heat_Wall(), 3), Is.EqualTo(Sum_Coef_Heat_Wall).Within(0.001));
                Assert.That(Math.Round(_ml.Coef_Heat(), 3), Is.EqualTo(Coef_Heat).Within(0.001));
                Assert.That(Math.Round(_ml.Coef_Heat_Contamination(), 3), Is.EqualTo(Coef_Heat_Contamination).Within(0.001));
                Assert.That(Math.Round(_ml.Surface_Heat(), 3), Is.EqualTo(Surface_Heat).Within(0.001));
                Assert.That(Math.Round(_ml.Density_Heat_Flow(), 3), Is.EqualTo(Density_Heat_Flow).Within(0.001));
                Assert.That(Math.Round(_ml.Max_Temp_Wall(), 3), Is.EqualTo(Max_Temp_Wall).Within(0.001));


                // Отобразить в журнале тестирования
                Console.WriteLine("");
                Console.WriteLine("--- Результаты расчета");

                Console.WriteLine("Теплоемкость воздуха, Дж/(м3*К): expected = " +
                            Heat_Capacity_Air + "; actual=" + Math.Round(_ml.Heat_Capacity_Air(), 2));
                Console.WriteLine("Теплоемкость дыма, Дж/(м3*К): expected = " +
                            Heat_Capacity_Smoke + "; actual=" + Math.Round(_ml.Heat_Capacity_Smoke(), 2));
                Console.WriteLine("Энтальпия воздуха при начальной температуре, кДж/м3: expected = " +
                            Entalp_Air_Start_Temp + "; actual=" + Math.Round(_ml.Entalp_Air_Start_Temp(), 2));
                Console.WriteLine("Энтальпия воздуха при конечной температуре, кДж/м3: expected = " +
                            Entalp_Air_End_Temp + "; actual=" + Math.Round(_ml.Entalp_Air_End_Temp(), 2));
                Console.WriteLine("Энтальпия дыма при начальной температуре, кДж/м3: expected = " +
                            Entalp_Smoke_Start_Temp + "; actual=" + Math.Round(_ml.Entalp_Smoke_Start_Temp(), 2));
                Console.WriteLine("Средняя температура воздуха, °С: expected = " +
                            Average_Temp_Air + "; actual=" + Math.Round(_ml.Average_Temp_Air(), 2));
                Console.WriteLine("Средняя температура дыма, °С: expected = " +
                            Average_Temp_Smoke + "; actual=" + Math.Round(_ml.Average_Temp_Smoke(), 2));
                Console.WriteLine("Средняя температура стенки рекуператора, °С: expected = " +
                            Average_Temp_Wall + "; actual=" + Math.Round(_ml.Average_Temp_Wall(), 2));
                Console.WriteLine("Отношение Тст/Тв: expected = " +
                            Otnosh_Temp + "; actual=" + Math.Round(_ml.Otnosh_Temp(), 2));
                Console.WriteLine("Фактическая скорость воздуха, м/с: expected = " +
                            Fact_Speed_Air + "; actual=" + Math.Round(_ml.Fact_Speed_Air(), 2));
                Console.WriteLine("Ср/Нр: expected = " +
                            Cp_Hp + "; actual=" + Math.Round(_ml.Cp_Hp(), 2));

                Console.WriteLine("Фактическая скорость продуктов сгорания, м/с: expected = " +
                            Fact_Speed_Product + "; actual=" + Math.Round(_ml.Fact_Speed_Product(), 2));
                Console.WriteLine("Действительная скорость воздуха, м/с: expected = " +
                            Real_Speed_Air + "; actual=" + Math.Round(_ml.Real_Speed_Air(), 2));
                Console.WriteLine("Действительная скорость продуктов сгорания, м/с: expected = " +
                            Real_Speed_Product + "; actual=" + Math.Round(_ml.Real_Speed_Product(), 2));

                Console.WriteLine("Количество тепла, переданного воздуху, кВт: expected = " +
                            Heat_Air + "; actual=" + Math.Round(_ml.Heat_Air(), 2));
                Console.WriteLine("Количество тепла,вносимое в теплообменный аппарат продуктами сгорания, кВт: expected = " +
                            Heat_Input_Product + "; actual=" + Math.Round(_ml.Heat_Input_Product(), 2));
                Console.WriteLine("Количество тепла,уносимое продуктами сгорания, кВт: expected = " +
                            Heat_Output_Product + "; actual=" + Math.Round(_ml.Heat_Output_Product(), 2));
                Console.WriteLine("Энтальпия продуктов сгорания, кДж/м3: expected = " +
                            Entalp_Product + "; actual=" + Math.Round(_ml.Entalp_Product(), 2));
                Console.WriteLine("Температура продуктов сгорания после рекуператора, °С: expected = " +
                            Temp_Product_Output + "; actual=" + Math.Round(_ml.Temp_Product_Output(), 2));
                Console.WriteLine("Cреднелогарифмическая разность температур: expected = " +
                            Average_Log_Temp + "; actual=" + Math.Round(_ml.Average_Log_Temp(), 2));
                Console.WriteLine("Параметр 1 для поверхности нагрева: expected = " +
                            Heat_Parameter1 + "; actual=" + Math.Round(_ml.Heat_Parameter1(), 2));
                Console.WriteLine("Параметр 2 для поверхности нагрева: expected = " +
                            Heat_Parameter2 + "; actual=" + Math.Round(_ml.Heat_Parameter2(), 2));

                Console.WriteLine("Число Рейнольдса 1: expected = " +
                            Reynolds_Number_1 + "; actual=" + Math.Round(_ml.Reynolds_Number_1(), 2));
                Console.WriteLine("Поправочный коэффициент для теплопередачи: expected = " +
                            Popravka_Coef_Heat + "; actual=" + Math.Round(_ml.Popravka_Coef_Heat(), 2));
                Console.WriteLine("Поправочный коэффициент для теплопередачи (если изогнута труба): expected = " +
                            Popravka_Coef_Heat_Bend + "; actual=" + Math.Round(_ml.Popravka_Coef_Heat_Bend(), 2));
                Console.WriteLine("Суммарный поправочный коэффициент 1: expected = " +
                            Sum_Popravka_Coef_1 + "; actual=" + Math.Round(_ml.Sum_Popravka_Coef_1(), 2));
                Console.WriteLine("Число Нуссельта 1: expected = " +
                            Nusselt_Number_1 + "; actual=" + Math.Round(_ml.Nusselt_Number_1(), 2));
                Console.WriteLine("Коэффициент теплоотдачи конвекцией на пути движения воздуха, Вт/(м^2*оС): expected = " +
                            Coef_Heat_Convention_Air_Way + "; actual=" + Math.Round(_ml.Coef_Heat_Convention_Air_Way(), 2));
                Console.WriteLine("Коэффициент теплоотдачи конвекцией в пересчете на поверхность наружной трубы, Вт/(м^2*оС): expected = " +
                            Coef_Heat_Convention_Surface_External + "; actual=" + Math.Round(_ml.Coef_Heat_Convention_Surface_External(), 2));
                Console.WriteLine("Число Рейнольдса 2: expected = " +
                            Reynolds_Number_2 + "; actual=" + Math.Round(_ml.Reynolds_Number_2(), 2));
                Console.WriteLine("Суммарный поправочный коэффициент 2: expected = " +
                            Sum_Popravka_Coef_2 + "; actual=" + Math.Round(_ml.Sum_Popravka_Coef_2(), 2));
                Console.WriteLine("Число Нуссельта 2: expected = " +
                            Nusselt_Number_2 + "; actual=" + Math.Round(_ml.Nusselt_Number_2(), 2));
                Console.WriteLine("Коэффициент конвективной теплоотдачи: expected = " +
                            Coef_Convention_Heat + "; actual=" + Math.Round(_ml.Coef_Convention_Heat(), 2));

                Console.WriteLine("Эффективная длина луча: expected = " +
                            Eff_Ray_Length + "; actual=" + Math.Round(_ml.Eff_Ray_Length(), 2));
                Console.WriteLine("Коэффициент для газовой части печной среды kг: expected = " +
                            Coef_Gas_Environment + "; actual=" + Math.Round(_ml.Coef_Gas_Environment(), 2));
                Console.WriteLine("Связующая величина : expected = " +
                            Binding_Value + "; actual=" + Math.Round(_ml.Binding_Value(), 2));
                Console.WriteLine("Значение ɛ\"г: expected = " +
                            Temporary_Value_Ray + "; actual=" + Math.Round(_ml.Temporary_Value_Ray(), 2));
                Console.WriteLine("Коэффициент лучистой теплоотдачи, Вт/(м^2*оС): expected = " +
                            Coef_Ray_Heat + "; actual=" + Math.Round(_ml.Coef_Ray_Heat(), 2));
                Console.WriteLine("Суммарный коэффициент теплоотдачи от пс к стенке, Вт/(м^2*оС): expected = " +
                            Sum_Coef_Heat_Wall + "; actual=" + Math.Round(_ml.Sum_Coef_Heat_Wall(), 2));
                Console.WriteLine("Коэффициент теплопередачи, Вт/(м^2*оС): expected = " +
                            Coef_Heat + "; actual=" + Math.Round(_ml.Coef_Heat(), 2));
                Console.WriteLine("Коэффициент теплопередачи с учетом загрязнения труб, Вт/(м^2*оС): expected = " +
                            Coef_Heat_Contamination + "; actual=" + Math.Round(_ml.Coef_Heat_Contamination(), 2));
                Console.WriteLine("Поверхность нагрева: expected = " +
                            Surface_Heat + "; actual=" + Math.Round(_ml.Surface_Heat(), 2));
                Console.WriteLine("Плотность теплового потока от продуктов сгорания к воздуху, Вт/м2: expected = " +
                            Density_Heat_Flow + "; actual=" + Math.Round(_ml.Density_Heat_Flow(), 2));
                Console.WriteLine("Максимальная температура стенки, °С: expected = " +
                            Max_Temp_Wall + "; actual=" + Math.Round(_ml.Max_Temp_Wall(), 2));


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