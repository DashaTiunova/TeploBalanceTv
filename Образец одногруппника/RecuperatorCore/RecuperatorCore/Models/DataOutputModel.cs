using RecuperatorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecuperatorCore.Models
{
    public class DataOutputModel
    {
        private MathLib _cs = new MathLib();
        private DataInputModel _dataInput = new DataInputModel();

        public DataOutputModel() { }

        public DataOutputModel(DataInputModel DataInput)
        {
            _dataInput = DataInput;

            #region --- Передать исходные данные в экземпляр библиотеки

            _cs.Temp_Air_Output = _dataInput.Temp_Air_Output;
            _cs.Temp_Air_Input = _dataInput.Temp_Air_Input;
            _cs.Temp_Product_Input = _dataInput.Temp_Product_Input;
            _cs.Consump_Air = _dataInput.Consump_Air;
            _cs.Consump_Product = _dataInput.Consump_Product;
            _cs.Percent_CO2 = _dataInput.Percent_CO2;
            _cs.Percent_H2O = _dataInput.Percent_H2O;
            _cs.Radius_Section = _dataInput.Radius_Section;

            #endregion --- Передать исходные данные в экземпляр библиотеки

            #region Инициализация расчётных величин
            //_cs.Heat_Capacity_Air();
            //_cs.Heat_Capacity_Smoke();
            //_cs.Entalp_Air_Start_Temp();
            //_cs.Entalp_Air_End_Temp();
            //_cs.Entalp_Smoke_Start_Temp();
            //_cs.Heat_Air();
            //_cs.Heat_Input_Product();
            //_cs.Heat_Output_Product();
            //_cs.Entalp_Product();
            //_cs.Temp_Product_Output();
            //_cs.Average_Temp_Air();
            //_cs.Average_Temp_Smoke();
            //_cs.Average_Temp_Wall();
            //_cs.Otnosh_Temp();
            //_cs.Fact_Speed_Air();
            //_cs.Fact_Speed_Product();
            //_cs.Real_Speed_Air();
            //_cs.Real_Speed_Product();
            //_cs.Cp_Hp();
            //_cs.Average_Log_Temp();
            //_cs.Heat_Parameter1();
            //_cs.Heat_Parameter2();
            //_cs.Reynolds_Number_1();
            //_cs.Popravka_Coef_Heat();
            //_cs.Popravka_Coef_Heat_Bend();
            //_cs.Sum_Popravka_Coef_1();
            //_cs.Nusselt_Number_1();
            //_cs.Coef_Heat_Convention_Air_Way();
            //_cs.Coef_Heat_Convention_Surface_External();
            //_cs.Reynolds_Number_2();
            //_cs.Sum_Popravka_Coef_2();
            //_cs.Nusselt_Number_2();
            //_cs.Coef_Convention_Heat();
            //_cs.Eff_Ray_Length();
            //_cs.Coef_Gas_Environment();
            //_cs.Binding_Value();
            //_cs.Temporary_Value_Ray();
            //_cs.Coef_Ray_Heat();
            //_cs.Sum_Coef_Heat_Wall();
            //_cs.Coef_Heat();
            //_cs.Coef_Heat_Contamination();
            //_cs.Density_Heat_Flow();
            #endregion
        }

        #region --- Получить расчетные показатели

        /// <summary>
        /// Теплоемкость воздуха, Дж/(м3*К)
        /// </summary>
        public double Heat_Capacity_Air
        {
            get { return _cs.Heat_Capacity_Air(); }
        }

        /// <summary>
        /// Теплоемкость дыма, Дж/(м3*К)
        /// </summary>
        public double Heat_Capacity_Smoke
        {
            get { return _cs.Heat_Capacity_Smoke(); }
        }

        /// <summary>
        /// Энтальпия воздуха при начальной температуре, кДж/м3
        /// </summary>
        public double Entalp_Air_Start_Temp
        {
            get { return _cs.Entalp_Air_Start_Temp(); }
        }

        /// <summary>
        /// Энтальпия воздуха при конечной температуре, кДж/м3
        /// </summary>
        public double Entalp_Air_End_Temp
        {
            get { return _cs.Entalp_Air_End_Temp(); }
        }

        /// <summary>
        /// Энтальпия дыма при начальной температуре, кДж/м3
        /// </summary>
        public double Entalp_Smoke_Start_Temp
        {
            get { return _cs.Entalp_Smoke_Start_Temp(); }
        }

        /// <summary>
        /// Средняя температура воздуха, °С
        /// </summary>
        public double Average_Temp_Air
        {
            get { return _cs.Average_Temp_Air(); }
        }

        /// <summary>
        /// Средняя температура дыма, °С
        /// </summary>
        public double Average_Temp_Smoke
        {
            get { return _cs.Average_Temp_Smoke(); }
        }

        /// <summary>
        /// Средняя температура стенки рекуператора, °С
        /// </summary>
        public double Average_Temp_Wall
        {
            get { return _cs.Average_Temp_Wall(); }
        }

        /// <summary>
        /// Отношение Тст/Тв
        /// </summary>
        public double Otnosh_Temp
        {
            get { return _cs.Otnosh_Temp(); }
        }

        /// <summary>
        /// Фактическая скорость воздуха, м/с
        /// </summary>
        public double Fact_Speed_Air
        {
            get { return _cs.Fact_Speed_Air(); }
        }

        /// <summary>
        /// Фактическая скорость продуктов сгорания, м/с
        /// </summary>
        public double Fact_Speed_Product
        {
            get { return _cs.Fact_Speed_Product();}
        }

        /// <summary>
        /// Действительная скорость воздуха, м/с
        /// </summary>
        public double Real_Speed_Air
        {
            get { return _cs.Real_Speed_Air(); }
        }

        /// <summary>
        /// Действительная скорость продуктов сгорания, м/с
        /// </summary>
        public double Real_Speed_Product
        {
            get { return _cs.Real_Speed_Product();}
        }

        /// <summary>
        /// Количество тепла, переданного воздуху, кВт
        /// </summary>
        public double Heat_Air
        {
            get { return _cs.Heat_Air(); }
        }

        /// <summary>
        /// Количество тепла,вносимое в теплообменный аппарат продуктами сгорания, кВт
        /// </summary>
        public double Heat_Input_Product
        {
            get { return _cs.Heat_Input_Product(); }
        }

        /// <summary>
        /// Количество тепла,уносимое продуктами сгорания, кВт
        /// </summary>
        public double Heat_Output_Product
        {
            get { return _cs.Heat_Output_Product();}
        }

        /// <summary>
        /// Энтальпия продуктов сгорания, кДж/м3
        /// </summary>
        public double Entalp_Product
        {
            get { return _cs.Entalp_Product(); }
        }

        /// <summary>
        /// Температура продуктов сгорания после рекуператора, °С
        /// </summary>
        public double Temp_Product_Output
        {
            get { return _cs.Temp_Product_Output(); }
        }

        /// <summary>
        /// Cреднелогарифмическая разность температур
        /// </summary>
        public double Average_Log_Temp
        {
            get { return _cs.Average_Log_Temp(); }
        }

        /// <summary>
        /// Параметр 1 для поверхности нагрева
        /// </summary>
        public double Heat_Parameter1
        {
            get { return _cs.Heat_Parameter1();}
        }

        /// <summary>
        /// Параметр 2 для поверхности нагрева
        /// </summary>
        public double Heat_Parameter2
        {
            get{ return _cs.Heat_Parameter2();}
        }

        /// <summary>
        /// Число Рейнольдса 1
        /// </summary>
        public double Reynolds_Number_1
        {
            get { return _cs.Reynolds_Number_1(); }
        }

        /// <summary>
        /// Поправочный коэффициент для теплопередачи
        /// </summary>
        public double Popravka_Coef_Heat
        {
            get { return _cs.Popravka_Coef_Heat(); }
        }

        /// <summary>
        /// Поправочный коэффициент для теплопередачи (если изогнута труба)
        /// </summary>
        public double Popravka_Coef_Heat_Bend
        {
            get { return _cs.Popravka_Coef_Heat_Bend(); }
        }

        /// <summary>
        /// Суммарный поправочный коэффициент 1
        /// </summary>
        public double Sum_Popravka_Coef_1
        {
            get { return _cs.Sum_Popravka_Coef_1(); }
        }

        /// <summary>
        /// Число Нуссельта 1
        /// </summary>
        public double Nusselt_Number_1
        {
            get { return _cs.Nusselt_Number_1(); }
        }

        /// <summary>
        /// Коэффициент теплоотдачи конвекцией на пути движения воздуха, Вт/(м^2*оС)
        /// </summary>
        public double Coef_Heat_Convention_Air_Way
        {
            get { return _cs.Coef_Heat_Convention_Air_Way(); }
        }

        /// <summary>
        /// Коэффициент теплоотдачи конвекцией в пересчете на поверхность наружной трубы, Вт/(м^2*оС)
        /// </summary>
        public double Coef_Heat_Convention_Surface_External
        {
            get { return _cs.Coef_Heat_Convention_Surface_External(); }
        }

        /// <summary>
        /// Число Рейнольдса
        /// </summary>
        public double Reynolds_Number_2
        {
            get { return _cs.Reynolds_Number_2(); }
        }

        /// <summary>
        /// Суммарный поправочный коэффициент 2
        /// </summary>
        public double Sum_Popravka_Coef_2
        {
            get { return _cs.Sum_Popravka_Coef_2(); }
        }

        /// <summary>
        /// Число Нуссельта 2
        /// </summary>
        public double Nusselt_Number_2
        {
            get { return _cs.Nusselt_Number_2(); }
        }

        /// <summary>
        /// Коэффициент конвективной теплоотдачи
        /// </summary>
        public double Coef_Convention_Heat
        {
            get { return _cs.Coef_Convention_Heat(); }
        }

        /// <summary>
        /// Эффективная длина луча
        /// </summary>
        public double Eff_Ray_Length
        {
            get { return _cs.Eff_Ray_Length(); }
        }

        /// <summary>
        /// Коэффициент для газовой части печной среды kг
        /// </summary>
        public double Coef_Gas_Environment
        {
            get { return _cs.Coef_Gas_Environment();}
        }

        /// <summary>
        /// Связующая величина 
        /// </summary>
        public double Binding_Value
        {
            get { return _cs.Binding_Value(); }
        }

        /// <summary>
        /// Значение ɛ"г 
        /// </summary>
        public double Temporary_Value_Ray
        {
            get { return _cs.Temporary_Value_Ray(); }
        }

        /// <summary>
        /// Коэффициент лучистой теплоотдачи, Вт/(м^2*оС)
        /// </summary>
        public double Coef_Ray_Heat
        {
            get { return _cs.Coef_Ray_Heat();}
        }

        /// <summary>
        /// Суммарный коэффициент теплоотдачи от пс к стенке, Вт/(м^2*оС)
        /// </summary>
        public double Sum_Coef_Heat_Wall
        {
            get { return _cs.Sum_Coef_Heat_Wall(); }
        }

        /// <summary>
        /// Коэффициент теплопередачи, Вт/(м^2*оС)
        /// </summary>
        public double Coef_Heat
        {
            get { return _cs.Coef_Heat();}  
        }

        /// <summary>
        /// Коэффициент теплопередачи с учетом загрязнения труб, Вт/(м^2*оС)
        /// </summary>
        public double Coef_Heat_Contamination
        {
            get { return _cs.Coef_Heat_Contamination(); }
        }

        /// <summary>
        /// Плотность теплового потока от продуктов сгорания к воздуху, Вт/м2
        /// </summary>
        public double Density_Heat_Flow
        {
            get { return _cs.Density_Heat_Flow(); }
        }
        /// <summary>
        /// Поверхность нагрева
        /// </summary>          
        public double Surface_Heat
        {
            get { return _cs.Surface_Heat(); }
        }

        /// <summary>
        /// Максимальная температура стенки, °С
        /// </summary>         
        public double Max_Temp_Wall
        {
            get { return _cs.Max_Temp_Wall(); }
        }


        #endregion --- Получить расчетные показатели

    }
}
