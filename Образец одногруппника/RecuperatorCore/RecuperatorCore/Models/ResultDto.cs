namespace RecuperatorCore.Models
{
    public class ResultDto
    {
        public double Temp_Air_Output { get; set; }
        public double Temp_Air_Input { get; set; }
        public double Temp_Product_Input { get; set; }
        public double Consump_Air { get; set; }
        public double Consump_Product { get; set; }
        public double Percent_CO2 { get; set; }
        public double Percent_H2O { get; set; }
        public double Radius_Section { get; set; }

        public double Surface_Heat { get; set; }
        public double Max_Temp_Wall { get; set; }
        public double Heat_Capacity_Air { get; set; }
        public double Heat_Capacity_Smoke { get; set; }
        public double Entalp_Air_Start_Temp { get; set; }
        public double Entalp_Air_End_Temp { get; set; }
        public double Entalp_Smoke_Start_Temp { get; set; }
        public double Average_Temp_Air { get; set; }
        public double  Average_Temp_Smoke { get; set; }
        public double Average_Temp_Wall { get; set; }
        public double Otnosh_Temp { get; set; }
        public double Fact_Speed_Air { get; set; }
        public double Fact_Speed_Product { get; set; }
        public double Real_Speed_Air { get; set; }
        public double Real_Speed_Product { get; set; }
        public double Heat_Air { get; set; }
        public double Heat_Input_Product { get; set; }
        public double Heat_Output_Product { get; set; }
        public double Entalp_Product { get; set; }
        public double Temp_Product_Output { get; set; }
        public double Average_Log_Temp { get; set; }
        public double Heat_Parameter1 { get; set; }
        public double Heat_Parameter2 { get; set; }
        public double Reynolds_Number_1 { get; set; }
        public double Popravka_Coef_Heat { get; set; }
        public double Popravka_Coef_Heat_Bend { get; set; }
        public double Sum_Popravka_Coef_1 { get; set; }
        public double Nusselt_Number_1 { get; set; }
        public double Coef_Heat_Convention_Air_Way { get; set; }
        public double Coef_Heat_Convention_Surface_External { get; set; }
        public double Reynolds_Number_2 { get; set; }
        public double Sum_Popravka_Coef_2 { get; set; }
        public double Nusselt_Number_2 { get; set; }
        public double Coef_Convention_Heat { get; set; }
        public double Eff_Ray_Length { get; set; }
        public double Coef_Gas_Environment { get; set; }
        public double Binding_Value { get; set; }
        public double Temporary_Value_Ray { get; set; }
        public double Coef_Ray_Heat { get; set; }
        public double Sum_Coef_Heat_Wall { get; set; }
        public double Coef_Heat { get; set; }
        public double Coef_Heat_Contamination { get; set; }
        public double Density_Heat_Flow { get; set; }
    }
}
