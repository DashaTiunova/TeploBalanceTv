using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecuperatorLibrary
{
    public class MathLib
    {
        #region Исходные данные
                
        /// <summary>
        /// Температура воздуха на выходе из рекуператора, °С
        /// </summary>
        private double temp_Air_Output;
        /// <summary>
        /// Температура воздуха на выходе из рекуператора, °С
        /// </summary>
        public double Temp_Air_Output 
        {
            get { return temp_Air_Output; }
            set { temp_Air_Output = value; }
        }
                
        /// <summary>
        /// Температура воздуха на входе в рекуператор, °С
        /// </summary>
        private double temp_Air_Input;
        /// <summary>
        /// Температура воздуха на входе в рекуператор, °С
        /// </summary>
        public double Temp_Air_Input 
        {
            get { return temp_Air_Input; }
            set { temp_Air_Input = value; }
        }
                
        /// <summary>
        /// Температура продуктов сгорания перед рекуператором, °С
        /// </summary>
        private double temp_Product_Input;
        /// <summary>
        /// Температура продуктов сгорания перед рекуператором, °С
        /// </summary>
        public double Temp_Product_Input 
        {
            get { return temp_Product_Input; }
            set { temp_Product_Input = value; }
        }

        /// <summary>
        /// Расход воздуха, м3/с
        /// </summary>
        private double consump_Air;
        /// <summary>
        /// Расход воздуха, м3/с
        /// </summary>
        public double Consump_Air
        {
            get { return consump_Air; }
            set { consump_Air = value; }
        }

        /// <summary>
        /// Расход продуктов сгорания, м3/с
        /// </summary>
        private double consump_Product;
        /// <summary>
        /// Расход продуктов сгорания, м3/с
        /// </summary>
        public double Consump_Product
        {
            get { return consump_Product; }
            set { consump_Product = value; }
        }

        /// <summary>
        /// Количество CO2, %
        /// </summary>
        private double percent_CO2;
        /// <summary>
        /// Количество CO2, %
        /// </summary>
        public double Percent_CO2
        {
            get { return percent_CO2; }
            set { percent_CO2 = value; }
        }

        /// <summary>
        /// Количество H2O, %
        /// </summary>
        private double percent_H2O;
        /// <summary>
        /// Количество H2O, %
        /// </summary>
        public double Percent_H2O
        {
            get { return percent_H2O; }
            set { percent_H2O = value; }
        }

        /// <summary>
        /// Справочные данные - радиус секции
        /// </summary>
        private double radius_Section;
        /// <summary>
        /// Справочные данные - радиус секции
        /// </summary>
        public double Radius_Section
        {
            get { return radius_Section; }
            set { radius_Section = value; }
        }

        #endregion Исходные данные

        #region Блок нормативно-справочной информации (НСИ)

        /// <summary>
        /// Поправка на длину канала для Крек,
        /// </summary>
        public static double Popravka_Dlina_K = 1;

        /// <summary>
        /// Коэфициент излучения АЧТ, Вт/(м2*К4)
        /// </summary>
        public static double Coef_Izluch = 5.7;

        /// <summary>
        /// Поправка для Крек
        /// </summary>
        public static double Popravka_K = 1d + 1.8 * External_Diameter_Pipe * 1000d / 925d;

        /// <summary>
        /// Коэффициент теплопроводности 1, Вт/(м3*оС)
        /// </summary>
        public static double Coef_Conductivity_1 = 0.0393;

        /// <summary>
        /// Коэффициент теплопроводности 2, Вт/(м3*оС)
        /// </summary>
        public static double Coef_Conductivity_2 = 0.0885;

        /// <summary>
        /// Коэффициент кинематической вязкости 1, м2/с
        /// </summary>
        public static double Coef_Kinemat_Vyazkosti_1 = 34.9;

        /// <summary>
        /// Коэффициент кинематической вязкости 2, м2/с
        /// </summary>
        public static double Coef_Kinemat_Vyazkosti_2 = 124.9;

        /// <summary>
        /// Число Прандтля 1
        /// </summary>
        public static double Prandtel_Number_1 = 0.68;

        /// <summary>
        /// Число Прандтля 2
        /// </summary>
        public static double Prandtel_Number_2 = 0.603;

        /// <summary>
        /// Внешний диаметр трубы, м
        /// </summary>
        public static double External_Diameter_Pipe = 0.076;

        /// <summary>
        /// Внутренний диаметр трубы, м
        /// </summary>
        public static double Internal_Diameter_Pipe = 0.068;

        /// <summary>
        /// Проходное сечение для воздуха, м2
        /// </summary>
        public static double Prohodn_Sechenie_Vozd = 0.62;

        /// <summary>
        /// Проходное сечение для продуктов сгорания, м2
        /// </summary>
        public static double Prohodn_Sechenie_Product = 3.7;

        /// <summary>
        /// Ср/Нр
        /// </summary>
        private double cp_Hp;
        /// <summary>
        /// Ср/Нр
        /// </summary>
        public double Cp_Hp()
        {
            cp_Hp = 0.12 * (percent_H2O+ percent_CO2)* 0.5;
            return cp_Hp;
        }

        /// <summary>
        /// Поправочный коэффициент для расчёта поверхности нагрева
        /// </summary>
        public static double Popravka_Coef_Surface = 0.99;

        /// <summary>
        /// Поправочный коэффициент на число труб
        /// </summary>
        public static double Popravka_Coef_Num_Pipes = 1;

        /// <summary>
        /// Поправочный коэффициент для расчёта коэффициента теплопередачи
        /// </summary>
        public static double Popravka_Coef = 1;

        /// <summary>
        /// Интегральная степень черноты 
        /// </summary>
        public static double Integral_Black = 0.162;

        /// <summary>
        /// Значение доли излучения АЧТ 1 α"г
        /// </summary>
        public static double Part_Emittion_1 = 0.659;

        /// <summary>
        /// Значение доли излучения АЧТ 2 α"ст
        /// </summary>
        public static double Part_Emittion_2 = 0.734;

        #endregion Блок нормативно-справочной информации (НСИ)

        #region Исходные данные для воздуха

        /// <summary>
        /// Эмпирический коэффициент A
        /// </summary>
        public static double Empir_Coef_A1 = 0.023;

        /// <summary>
        /// Эмпирический коэффициент n
        /// </summary>
        public static double Empir_Coef_n1 = 0.8;

        /// <summary>
        /// Эмпирический коэффициент m
        /// </summary>
        public static double Empir_Coef_m1 = 0.4;

        #endregion Исходные данные для воздуха

        #region Исходные данные для продуктов сгорания

        /// <summary>
        /// Эмпирический коэффициент A
        /// </summary>
        public static double Empir_Coef_A2 = 0.2;

        /// <summary>
        /// Эмпирический коэффициент n
        /// </summary>
        public static double Empir_Coef_n2 = 0.64;

        /// <summary>
        /// Эмпирический коэффициент m
        /// </summary>
        public static double Empir_Coef_m2 = 0.35;

        #endregion Исходные данные для продуктов сгорания

        #region Расчетные показатели для воздуха и продуктов сгорания

        /// <summary>
        /// Теплоемкость воздуха, Дж/(м3*К)
        /// </summary>
        private double heat_Capacity_Air;
        /// <summary>
        /// Теплоемкость воздуха, Дж/(м3*К)
        /// </summary>
        public double Heat_Capacity_Air()
        {
            heat_Capacity_Air = temp_Air_Output * 0.1251 + 1309d;
            return heat_Capacity_Air;
        }
                
        /// <summary>
        /// Теплоемкость дыма, Дж/(м3*К)
        /// </summary>
        private double heat_Capacity_Smoke;
        /// <summary>
        /// Теплоемкость дыма, Дж/(м3*К)
        /// </summary>
        public double Heat_Capacity_Smoke()
        {
            heat_Capacity_Smoke = temp_Product_Input * 0.1251 + 1309d;
            return heat_Capacity_Smoke;
        }

        /// <summary>
        /// Энтальпия воздуха при начальной температуре, кДж/м3
        /// </summary>
        private double entalp_Air_Start_Temp;
        /// <summary>
        /// Энтальпия воздуха при начальной температуре, кДж/м3
        /// </summary>
        public double Entalp_Air_Start_Temp()
        {
            entalp_Air_Start_Temp = temp_Air_Input * heat_Capacity_Air;
            return entalp_Air_Start_Temp;
        }

        /// <summary>
        /// Энтальпия воздуха при конечной температуре, кДж/м3
        /// </summary>
        private double entalp_Air_End_Temp;
        /// <summary>
        /// Энтальпия воздуха при конечной температуре, кДж/м3
        /// </summary>
        public double Entalp_Air_End_Temp()
        {
            entalp_Air_End_Temp = temp_Air_Output * heat_Capacity_Air;
            return entalp_Air_End_Temp;
        }

        /// <summary>
        /// Энтальпия дыма при начальной температуре, кДж/м3
        /// </summary>
        private double entalp_Smoke_Start_Temp;
        /// <summary>
        /// Энтальпия дыма при начальной температуре, кДж/м3
        /// </summary>
        public double Entalp_Smoke_Start_Temp()
        {
            entalp_Smoke_Start_Temp = temp_Product_Input * heat_Capacity_Smoke;
            return entalp_Smoke_Start_Temp;
        }

        /// <summary>
        /// Средняя температура воздуха, °С
        /// </summary>
        private double average_Temp_Air;
        /// <summary>
        /// Средняя температура воздуха, °С
        /// </summary>
        public double Average_Temp_Air()
        {
            average_Temp_Air = (temp_Air_Input + temp_Air_Output) * 0.5;
            return average_Temp_Air;
        }

        /// <summary>
        /// Средняя температура дыма, °С
        /// </summary>
        private double average_Temp_Smoke;
        /// <summary>
        /// Средняя температура дыма, °С
        /// </summary>
        public double Average_Temp_Smoke()
        {
            average_Temp_Smoke = (temp_Product_Input + temp_Product_Output) * 0.5;
            return average_Temp_Smoke;
        }

        /// <summary>
        /// Средняя температура стенки рекуператора, °С
        /// </summary>
        private double average_Temp_Wall;
        /// <summary>
        /// Средняя температура стенки рекуператора, °С
        /// </summary>
        public double Average_Temp_Wall()
        {
            average_Temp_Wall = 0.5 * (0.5 * (temp_Product_Input + temp_Product_Output) + 0.5 * (temp_Air_Output + temp_Air_Output));
            return average_Temp_Wall;
        }

        /// <summary>
        /// Отношение Тст/Тв
        /// </summary>
        private double otnosh_Temp;
        /// <summary>
        /// Отношение Тст/Тв
        /// </summary>
        public double Otnosh_Temp()
        {
            otnosh_Temp = (average_Temp_Wall + 273d) / (average_Temp_Air + 273d);
            return otnosh_Temp;
        }

        /// <summary>
        /// Фактическая скорость воздуха, м/с
        /// </summary>
        private double fact_Speed_Air;
        /// <summary>
        /// Фактическая скорость воздуха, м/с
        /// </summary>
        public double Fact_Speed_Air()
        {
            fact_Speed_Air = consump_Air / Prohodn_Sechenie_Vozd;
            return fact_Speed_Air;
        }

        /// <summary>
        /// Фактическая скорость продуктов сгорания, м/с
        /// </summary>
        private double fact_Speed_Product;
        /// <summary>
        /// Фактическая скорость продуктов сгорания, м/с
        /// </summary>
        public double Fact_Speed_Product()
        {
            fact_Speed_Product = consump_Product / Prohodn_Sechenie_Product;
            return fact_Speed_Product;
        }

        /// <summary>
        /// Действительная скорость воздуха, м/с
        /// </summary>
        private double real_Speed_Air;
        /// <summary>
        /// Действительная скорость воздуха, м/с
        /// </summary>
        public double Real_Speed_Air()
        {
            real_Speed_Air = fact_Speed_Air * (1d + 200d / 273d);
            return real_Speed_Air;
        }

        /// <summary>
        /// Действительная скорость продуктов сгорания, м/с
        /// </summary>
        private double real_Speed_Product;
        /// <summary>
        /// Действительная скорость продуктов сгорания, м/с
        /// </summary>
        public double Real_Speed_Product()
        {
            real_Speed_Product = fact_Speed_Product * (1d + average_Temp_Smoke / 273d);
            return real_Speed_Product;
        }
        #endregion Расчетные показатели для воздуха и продуктов сгорания

        #region Расчётные показатели для поверхности нагрева

        /// <summary>
        /// Количество тепла, переданного воздуху, кВт
        /// </summary>
        private double heat_Air;
        /// <summary>
        /// Количество тепла, переданного воздуху, кВт
        /// </summary>
        public double Heat_Air()
        {
            heat_Air = consump_Air * (entalp_Air_End_Temp - entalp_Air_Start_Temp) / 1000d;
            return heat_Air;
        }

        /// <summary>
        /// Количество тепла,вносимое в теплообменный аппарат продуктами сгорания, кВт
        /// </summary>
        private double heat_Input_Product;
        /// <summary>
        /// Количество тепла,вносимое в теплообменный аппарат продуктами сгорания, кВт
        /// </summary>
        public double Heat_Input_Product()
        {
            heat_Input_Product = (consump_Product * entalp_Smoke_Start_Temp) / 1000d;
            return heat_Input_Product;
        }

        /// <summary>
        /// Количество тепла,уносимое продуктами сгорания, кВт
        /// </summary>
        private double heat_Output_Product;
        /// <summary>
        /// Количество тепла,уносимое продуктами сгорания, кВт
        /// </summary>
        public double Heat_Output_Product()
        {
            heat_Output_Product = 0.95 * heat_Input_Product - heat_Air;
            return heat_Output_Product;
        }

        /// <summary>
        /// Энтальпия продуктов сгорания, кДж/м3
        /// </summary>
        private double entalp_Product;
        /// <summary>
        /// Энтальпия продуктов сгорания, кДж/м3
        /// </summary>
        public double Entalp_Product()
        {
            entalp_Product = heat_Output_Product / consump_Product;
            return entalp_Product;
        }

        /// <summary>
        /// Температура продуктов сгорания после рекуператора, °С
        /// </summary>
        private double temp_Product_Output;
        /// <summary>
        /// Температура продуктов сгорания после рекуператора, °С
        /// </summary>
        public double Temp_Product_Output()
        {
            temp_Product_Output = 1000d * entalp_Product / heat_Capacity_Smoke;
            return temp_Product_Output;
        }

        /// <summary>
        /// Cреднелогарифмическая разность температур
        /// </summary>
        private double average_Log_Temp;
        /// <summary>
        /// Cреднелогарифмическая разность температур
        /// </summary>
        public double Average_Log_Temp()
        {
            double temp_value1 = (temp_Product_Input - temp_Air_Output);
            double temp_value2 = (temp_Product_Output - temp_Air_Input);
            average_Log_Temp = (temp_value1 - temp_value2) / (2.31 * Math.Log10(temp_value1/temp_value2));
            return average_Log_Temp;
        }

        /// <summary>
        /// Параметр 1 для поверхности нагрева
        /// </summary>
        private double heat_Parameter1;
        /// <summary>
        /// Параметр 1 для поверхности нагрева
        /// </summary>
        public double Heat_Parameter1()
        {
            heat_Parameter1 = (temp_Product_Input - temp_Product_Output) / (temp_Air_Output - temp_Air_Input);
            return heat_Parameter1;
        }

        /// <summary>
        /// Параметр 2 для поверхности нагрева
        /// </summary>
        private double heat_Parameter2;
        /// <summary>
        /// Параметр 2 для поверхности нагрева
        /// </summary>
        public double Heat_Parameter2()
        {
            heat_Parameter2 = (temp_Air_Output - temp_Air_Input) / (temp_Product_Input - temp_Air_Input);
            return heat_Parameter2;
        }
        #endregion Расчётные показатели для поверхности нагрева

        #region Расчёт коэффициента теплопередачи и поверхности нагрева

        /// <summary>
        /// Число Рейнольдса 1
        /// </summary>
        private double reynolds_Number_1;
        /// <summary>
        /// Число Рейнольдса 1
        /// </summary>
        public double Reynolds_Number_1()
        {
            reynolds_Number_1 = real_Speed_Air * Internal_Diameter_Pipe / (Coef_Kinemat_Vyazkosti_1 * Math.Pow(10d, -6));
            return reynolds_Number_1;
        }

        /// <summary>
        /// Поправочный коэффициент для теплопередачи
        /// </summary>
        private double popravka_Coef_Heat;
        /// <summary>
        /// Поправочный коэффициент для теплопередачи
        /// </summary>
        public double Popravka_Coef_Heat()
        {
            if (otnosh_Temp < 1 & otnosh_Temp > 0.5)
            {
                popravka_Coef_Heat = 1.27 - 0.27 * otnosh_Temp;
                return popravka_Coef_Heat;
            }
            else if (otnosh_Temp < 3.5 & otnosh_Temp > 1)
            {
                popravka_Coef_Heat = Math.Pow(otnosh_Temp, -0.55);
                return popravka_Coef_Heat;
            }
            else
            {
                throw new InvalidOperationException("Поправочный коэффициент для теплопередачи некорректно расчитывается");
            }
        }

        /// <summary>
        /// Поправочный коэффициент для теплопередачи (если изогнута труба)
        /// </summary>
        private double popravka_Coef_Heat_Bend;
        /// <summary>
        /// Поправочный коэффициент для теплопередачи (если изогнута труба)
        /// </summary>
        public double Popravka_Coef_Heat_Bend()
        {
            popravka_Coef_Heat_Bend = 1 + 1.8 * External_Diameter_Pipe * 1000 / (radius_Section / 2);
            return popravka_Coef_Heat_Bend;
        }

        /// <summary>
        /// Суммарный поправочный коэффициент 1
        /// </summary>
        private double sum_Popravka_Coef_1;
        /// <summary>
        /// Суммарный поправочный коэффициент 1
        /// </summary>
        public double Sum_Popravka_Coef_1()
        {
            sum_Popravka_Coef_1 = popravka_Coef_Heat * popravka_Coef_Heat_Bend * Popravka_Dlina_K;
            return sum_Popravka_Coef_1;
        }

        /// <summary>
        /// Число Нуссельта 1
        /// </summary>
        private double nusselt_Number_1;
        /// <summary>
        /// Число Нуссельта 1
        /// </summary>
        public double Nusselt_Number_1()
        {
            nusselt_Number_1 = Empir_Coef_A1 * Math.Pow(reynolds_Number_1, Empir_Coef_n1) * Math.Pow(Prandtel_Number_1, Empir_Coef_m1) * sum_Popravka_Coef_1;
            return nusselt_Number_1;
        }

        /// <summary>
        /// Коэффициент теплоотдачи конвекцией на пути движения воздуха, Вт/(м^2*оС)
        /// </summary>
        private double coef_Heat_Convention_Air_Way;
        /// <summary>
        /// Коэффициент теплоотдачи конвекцией на пути движения воздуха, Вт/(м^2*оС)
        /// </summary>
        public double Coef_Heat_Convention_Air_Way()
        {
            coef_Heat_Convention_Air_Way = nusselt_Number_1 * Coef_Conductivity_1 / Internal_Diameter_Pipe;
            return coef_Heat_Convention_Air_Way;
        }

        /// <summary>
        /// Коэффициент теплоотдачи конвекцией в пересчете на поверхность наружной трубы, Вт/(м^2*оС)
        /// </summary>
        private double coef_Heat_Convention_Surface_External;
        /// <summary>
        /// Коэффициент теплоотдачи конвекцией в пересчете на поверхность наружной трубы, Вт/(м^2*оС)
        /// </summary>
        public double Coef_Heat_Convention_Surface_External()
        {
            coef_Heat_Convention_Surface_External = coef_Heat_Convention_Air_Way * Internal_Diameter_Pipe / External_Diameter_Pipe;
            return coef_Heat_Convention_Surface_External;
        }

        /// <summary>
        /// Число Рейнольдса
        /// </summary>
        private double reynolds_Number_2;
        /// <summary>
        /// Число Рейнольдса
        /// </summary>
        public double Reynolds_Number_2()
        {
            reynolds_Number_2 = real_Speed_Product * External_Diameter_Pipe / Coef_Kinemat_Vyazkosti_2 * Math.Pow(10d, 6);
            return reynolds_Number_2;
        }

        /// <summary>
        /// Суммарный поправочный коэффициент 2
        /// </summary>
        private double sum_Popravka_Coef_2;
        /// <summary>
        /// Суммарный поправочный коэффициент 2
        /// </summary>
        public double Sum_Popravka_Coef_2()
        {
            sum_Popravka_Coef_2 = Popravka_Coef_Num_Pipes * Popravka_Coef;
            return sum_Popravka_Coef_2;
        }

        /// <summary>
        /// Число Нуссельта 2
        /// </summary>
        private double nusselt_Number_2;
        /// <summary>
        /// Число Нуссельта 2
        /// </summary>
        public double Nusselt_Number_2()
        {
            nusselt_Number_2 = Empir_Coef_A2 * Math.Pow(reynolds_Number_2, Empir_Coef_n2) * Math.Pow(Prandtel_Number_2, Empir_Coef_m2) * sum_Popravka_Coef_2;
            return nusselt_Number_2;
        }

        /// <summary>
        /// Коэффициент конвективной теплоотдачи
        /// </summary>
        private double coef_Convention_Heat;
        /// <summary>
        /// Коэффициент конвективной теплоотдачи
        /// </summary>
        public double Coef_Convention_Heat()
        {
            coef_Convention_Heat = nusselt_Number_2 * Coef_Conductivity_2 / External_Diameter_Pipe;
            return coef_Convention_Heat;
        }

        /// <summary>
        /// Эффективная длина луча
        /// </summary>
        private double eff_Ray_Length;
        /// <summary>
        /// Эффективная длина луча
        /// </summary>
        public double Eff_Ray_Length()
        {
            eff_Ray_Length = 1.2 * 3.5 * External_Diameter_Pipe;
            return eff_Ray_Length;
        }

        /// <summary>
        /// Коэффициент для газовой части печной среды kг
        /// </summary>
        private double coef_Gas_Environment;
        /// <summary>
        /// Коэффициент для газовой части печной среды kг
        /// </summary>
        public double Coef_Gas_Environment()
        {
            coef_Gas_Environment = (0.78 + 0.016 * percent_H2O) / (Math.Sqrt(0.01 * (percent_CO2 + percent_H2O) * eff_Ray_Length) - 0.01) * (1d - 0.37 * average_Temp_Smoke / 1000d) * 0.01 * (percent_CO2 + percent_H2O);
            return coef_Gas_Environment;
        }

        /// <summary>
        /// Связующая величина 
        /// </summary>
        private double binding_Value;
        /// <summary>
        /// Связующая величина 
        /// </summary>
        public double Binding_Value()
        {
            binding_Value = (0.03 * (2d - 1.22) * (0.0016 * (average_Temp_Smoke + 273d) - 0.5) * cp_Hp + coef_Gas_Environment) * eff_Ray_Length;
            return binding_Value;
        }

        /// <summary>
        /// Значение ɛ"г 
        /// </summary>
        private double temporary_Value_Ray;
        /// <summary>
        /// Значение ɛ"г 
        /// </summary>
        public double Temporary_Value_Ray()
        {
            temporary_Value_Ray = Integral_Black / Part_Emittion_1;
            return temporary_Value_Ray;
        }

        /// <summary>
        /// Коэффициент лучистой теплоотдачи, Вт/(м^2*оС)
        /// </summary>
        private double coef_Ray_Heat;
        /// <summary>
        /// Коэффициент лучистой теплоотдачи, Вт/(м^2*оС)
        /// </summary>
        public double Coef_Ray_Heat()
        {
            coef_Ray_Heat = ((Coef_Izluch * Part_Emittion_2) / ((1d / temporary_Value_Ray) + (1d / 0.8) - 1d)) * (Part_Emittion_1 / Part_Emittion_2 * ((Math.Pow(((average_Temp_Smoke + 273d) / 100d), 4)) - (Math.Pow(((average_Temp_Wall + 273d) / 100d), 4)))) / (average_Temp_Smoke - average_Temp_Wall);
            return coef_Ray_Heat;
        }

        /// <summary>
        /// Суммарный коэффициент теплоотдачи от пс к стенке, Вт/(м^2*оС)
        /// </summary>
        private double sum_Coef_Heat_Wall;
        /// <summary>
        /// Суммарный коэффициент теплоотдачи от пс к стенке, Вт/(м^2*оС)
        /// </summary>
        public double Sum_Coef_Heat_Wall()
        {
            sum_Coef_Heat_Wall = coef_Convention_Heat + coef_Ray_Heat;
            return sum_Coef_Heat_Wall;
        }

        /// <summary>
        /// Коэффициент теплопередачи, Вт/(м^2*оС)
        /// </summary>
        private double coef_Heat;
        /// <summary>
        /// Коэффициент теплопередачи, Вт/(м^2*оС)
        /// </summary>
        public double Coef_Heat()
        {
            coef_Heat = 1d / ((1d / sum_Coef_Heat_Wall) + (1d / coef_Heat_Convention_Surface_External));
            return coef_Heat;
        }

        /// <summary>
        /// Коэффициент теплопередачи с учетом загрязнения труб, Вт/(м^2*оС)
        /// </summary>
        private double coef_Heat_Contamination;
        /// <summary>
        /// Коэффициент теплопередачи с учетом загрязнения труб, Вт/(м^2*оС)
        /// </summary>
        public double Coef_Heat_Contamination()
        {
            coef_Heat_Contamination = coef_Heat / 1.1;
            return coef_Heat_Contamination;
        }

        /// <summary>
        /// Поверхность нагрева
        /// </summary>
        private double surface_Heat;
        /// <summary>
        /// Поверхность нагрева
        /// </summary>
        public double Surface_Heat()
        {
            surface_Heat = heat_Air / average_Log_Temp * coef_Heat_Contamination * Popravka_Coef_Surface;
            return surface_Heat;
        }
        #endregion Расчёт коэффициента теплопередачи и поверхности нагрева

        #region Расчёт максимальной температуры стенки

        /// <summary>
        /// Плотность теплового потока от продуктов сгорания к воздуху, Вт/м2
        /// </summary>
        private double density_Heat_Flow;
        /// <summary>
        /// Плотность теплового потока от продуктов сгорания к воздуху, Вт/м2
        /// </summary>
        public double Density_Heat_Flow()
        {
            density_Heat_Flow = coef_Heat_Contamination * (temp_Product_Input - temp_Product_Output);
            return density_Heat_Flow;
        }

        /// <summary>
        /// Максимальная температура стенки, °С
        /// </summary>
        private double max_Temp_Wall;
        /// <summary>
        /// Максимальная температура стенки, °С
        /// </summary>
        public double Max_Temp_Wall()
        {
            max_Temp_Wall = temp_Product_Input - density_Heat_Flow / sum_Coef_Heat_Wall * 1.3;
            return max_Temp_Wall;
        }

        #endregion Расчёт максимальной температуры стенки
    }
}