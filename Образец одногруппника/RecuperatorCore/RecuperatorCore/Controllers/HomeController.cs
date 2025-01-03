using AutoMapper;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RecuperatorCore.Models;
using RecuperatorCore.Services;
using RecuperatorLibrary;
using RecuperatorLibrary.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using iTextSharp.text.pdf;
using PdfWriter = iText.Kernel.Pdf.PdfWriter;
using PdfDocument = iText.Kernel.Pdf.PdfDocument;
using iText.Layout.Font;
using iText.Html2pdf.Resolver.Font;
using iText.Html2pdf;

namespace RecuperatorCore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RecuperatorContext _context;
        private readonly IMapper _mapper;
        private readonly RecuperatorService _service;

        public HomeController(ILogger<HomeController> logger, RecuperatorContext context, IMapper mapper, RecuperatorService service)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _service = service;
        }
        public ActionResult Index()
        {
            return RedirectToAction("DataInput");
        }

        #region Отображение страницы с входными данными
        public IActionResult DataInput()
        {
            VariantUser loaded_variant = null;
            if (TempData["LoadedVariant"] != null)
            {
                loaded_variant = JsonConvert.DeserializeObject<VariantUser>(TempData["LoadedVariant"].ToString()); // Десериализация объекта
            }
            var viewModel = new VariantViewmodel
            {
                UserId = _service.GetUserId(User.Identity.Name),
                Variants = _service.GetVariants(_service.GetUserId(User.Identity.Name))
            };
            
            MathLib _cs = new MathLib();
            VariantUser variant = new VariantUser();
            if (loaded_variant != null && loaded_variant.Id != 0)
            {
                variant = loaded_variant;
            }
            #region --- Задать исходные данные для первого найденного варианта
            if (variant.Id != 0)
            {
                _cs.Temp_Air_Output = variant.Temp_Air_Output;
                _cs.Temp_Air_Input = variant.Temp_Air_Input;
                _cs.Temp_Product_Input = variant.Temp_Product_Input;
                _cs.Consump_Air = variant.Consump_Air;
                _cs.Consump_Product = variant.Consump_Product;
                _cs.Percent_CO2 = variant.Percent_CO2;
                _cs.Percent_H2O = variant.Percent_H2O;
                _cs.Radius_Section = variant.Radius_Section;
            }
            else
            {
                _cs.Temp_Air_Output = 300d;
                _cs.Temp_Air_Input = 20d;
                _cs.Temp_Product_Input = 800d;
                _cs.Consump_Air = 7.5;
                _cs.Consump_Product = 9.9;
                _cs.Percent_CO2 = 12.47;
                _cs.Percent_H2O = 11.89;
                _cs.Radius_Section = 1850d;
            }
            #endregion --- Задать исходные данные для первого найденного варианта

            ViewBag.DataInput = _cs;

            return View(viewModel);
        }
        #endregion

        #region Получение результата расчёта
        [HttpPost]
        public IActionResult DataInput(DataInputModel DataInput)
        {
            DataOutputModel _result = new DataOutputModel(DataInput);

            #region --- Присвоение значений
            ViewBag.Temp_Air_Output = DataInput.Temp_Air_Output;
            ViewBag.Temp_Air_Input = DataInput.Temp_Air_Input;
            ViewBag.Temp_Product_Input = DataInput.Temp_Product_Input;
            ViewBag.Consump_Air = DataInput.Consump_Air;
            ViewBag.Consump_Product = DataInput.Consump_Product;
            ViewBag.Percent_CO2 = DataInput.Percent_CO2;
            ViewBag.Percent_H2O = DataInput.Percent_H2O;
            ViewBag.Radius_Section = DataInput.Radius_Section;

            ViewBag.Heat_Capacity_Air = _result.Heat_Capacity_Air;
            ViewBag.Heat_Capacity_Smoke = _result.Heat_Capacity_Smoke;
            ViewBag.Entalp_Air_Start_Temp = _result.Entalp_Air_Start_Temp;
            ViewBag.Entalp_Air_End_Temp = _result.Entalp_Air_End_Temp;
            ViewBag.Entalp_Smoke_Start_Temp = _result.Entalp_Smoke_Start_Temp;
            ViewBag.Average_Temp_Air = _result.Average_Temp_Air;
            ViewBag.Average_Temp_Smoke = _result.Average_Temp_Smoke;
            ViewBag.Average_Temp_Wall = _result.Average_Temp_Wall;
            ViewBag.Otnosh_Temp = _result.Otnosh_Temp;
            ViewBag.Fact_Speed_Air = _result.Fact_Speed_Air;
            ViewBag.Fact_Speed_Product = _result.Fact_Speed_Product;
            ViewBag.Real_Speed_Air = _result.Real_Speed_Air;
            ViewBag.Real_Speed_Product = _result.Real_Speed_Product;
            ViewBag.Heat_Air = _result.Heat_Air;
            ViewBag.Heat_Input_Product = _result.Heat_Input_Product;
            ViewBag.Heat_Output_Product = _result.Heat_Output_Product;
            ViewBag.Entalp_Product = _result.Entalp_Product;
            ViewBag.Temp_Product_Output = _result.Temp_Product_Output;
            ViewBag.Average_Log_Temp = _result.Average_Log_Temp;
            ViewBag.Heat_Parameter1 = _result.Heat_Parameter1;
            ViewBag.Heat_Parameter2 = _result.Heat_Parameter2;
            ViewBag.Reynolds_Number_1 = _result.Reynolds_Number_1;
            try
            {
                ViewBag.Popravka_Coef_Heat = _result.Popravka_Coef_Heat;
            }
            catch (InvalidOperationException)
            {
                TempData["InvalidOperationMessage"] = "Проблема с расчётом поправочного коэффициент для теплопередачи! Проверьте значения температур.";
                return RedirectToAction("DataInput");
            }
            ViewBag.Popravka_Coef_Heat_Bend = _result.Popravka_Coef_Heat_Bend;
            ViewBag.Sum_Popravka_Coef_1 = _result.Sum_Popravka_Coef_1;
            ViewBag.Nusselt_Number_1 = _result.Nusselt_Number_1;
            ViewBag.Coef_Heat_Convention_Air_Way = _result.Coef_Heat_Convention_Air_Way;
            ViewBag.Coef_Heat_Convention_Surface_External = _result.Coef_Heat_Convention_Surface_External;
            ViewBag.Reynolds_Number_2 = _result.Reynolds_Number_2;
            ViewBag.Sum_Popravka_Coef_2 = _result.Sum_Popravka_Coef_2;
            ViewBag.Nusselt_Number_2 = _result.Nusselt_Number_2;
            ViewBag.Coef_Convention_Heat = _result.Coef_Convention_Heat;
            ViewBag.Eff_Ray_Length = _result.Eff_Ray_Length;
            ViewBag.Coef_Gas_Environment = _result.Coef_Gas_Environment;
            ViewBag.Binding_Value = _result.Binding_Value;
            ViewBag.Temporary_Value_Ray = _result.Temporary_Value_Ray;
            ViewBag.Coef_Ray_Heat = _result.Coef_Ray_Heat;
            ViewBag.Sum_Coef_Heat_Wall = _result.Sum_Coef_Heat_Wall;
            ViewBag.Coef_Heat = _result.Coef_Heat;
            ViewBag.Coef_Heat_Contamination = _result.Coef_Heat_Contamination;
            ViewBag.Density_Heat_Flow = _result.Density_Heat_Flow;
            ViewBag.Surface_Heat = _result.Surface_Heat;
            ViewBag.Max_Temp_Wall = _result.Max_Temp_Wall;

            var lists = new List<double>()
            {
                 _result.Heat_Capacity_Air,
                _result.Heat_Capacity_Smoke,
                _result.Entalp_Air_Start_Temp,
                _result.Entalp_Air_End_Temp,
                _result.Entalp_Smoke_Start_Temp,
                _result.Average_Temp_Air,
                _result.Average_Temp_Smoke,
                _result.Average_Temp_Wall,
                _result.Otnosh_Temp,
                _result.Fact_Speed_Air,
                _result.Fact_Speed_Product,
                _result.Real_Speed_Air,
                _result.Real_Speed_Product,
                _result.Heat_Air,
                _result.Heat_Input_Product,
                _result.Heat_Output_Product,
                _result.Entalp_Product,
                _result.Temp_Product_Output,
                _result.Average_Log_Temp,
                _result.Heat_Parameter1,
                _result.Heat_Parameter2,
                _result.Reynolds_Number_1,
                _result.Popravka_Coef_Heat,
                _result.Popravka_Coef_Heat_Bend,
                _result.Sum_Popravka_Coef_1,
                _result.Nusselt_Number_1,
                _result.Coef_Heat_Convention_Air_Way,
                _result.Coef_Heat_Convention_Surface_External,
                _result.Reynolds_Number_2,
                _result.Sum_Popravka_Coef_2,
                _result.Nusselt_Number_2,
                _result.Coef_Convention_Heat,
                _result.Eff_Ray_Length,
                _result.Coef_Gas_Environment,
                _result.Binding_Value,
                _result.Temporary_Value_Ray,
                _result.Coef_Ray_Heat,
                _result.Sum_Coef_Heat_Wall,
                _result.Coef_Heat,
                _result.Coef_Heat_Contamination,
                _result.Density_Heat_Flow,
                _result.Surface_Heat,
                _result.Max_Temp_Wall
            };

            #endregion

            ViewBag.lists = Newtonsoft.Json.JsonConvert.SerializeObject(lists);
            return View("Result");
        }
        #endregion

        #region Сохранение варианта
        [HttpPost]
        public IActionResult SaveVariant(VariantAddDtoModel model)
        {
            var temp_variant = new VariantAddDto
            {
                Name = model.Name,
                Desc = model.Desc,
                UserId = _context.Users.FirstOrDefault(x => x.Login == User.Identity.Name).Id,
            };
            var variant = _mapper.Map<Variant>(temp_variant);
            _context.Variants.Add(variant);
            _context.SaveChanges();
            var temp_variantUser = new VariantUserAddDto
            {
                VariantId = _service.GetVariantId(temp_variant),
                UserId = model.UserId,
                Temp_Air_Output = model.Temp_Air_Output,
                Temp_Air_Input = model.Temp_Air_Input,
                Temp_Product_Input = model.Temp_Product_Input,
                Consump_Air = model.Consump_Air,
                Consump_Product = model.Consump_Product,
                Percent_CO2 = model.Percent_CO2,
                Percent_H2O = model.Percent_H2O,
                Radius_Section = model.Radius_Section,
            };
            var variantUser = _mapper.Map<VariantUser>(temp_variantUser);
            _context.VariantUsers.Add(variantUser);
            _context.SaveChanges();
            return RedirectToAction("DataInput");
        }
        #endregion

        #region Загрузка варианта
        [HttpPost]
        public IActionResult LoadVariant(VariantLoadDto model)
        {
            var variant = _service.GetVariantUser(model);
            TempData["LoadedVariant"] = JsonConvert.SerializeObject(variant);
            return RedirectToAction("DataInput");
        }
        #endregion

        #region Удаление варианта
        [HttpPost]
        public IActionResult DeleteVariant(VariantDeleteDto model)
        {
            if (_service.DeleteVariant(model))
            {
                TempData["Message"] = "Удаление успешно!";
                return RedirectToAction("DataInput");
            }
            return View();
        }
        #endregion

        #region Формирование PDF
        [HttpPost]
        public IActionResult SaveAsPdf(ResultDto model)
        {
            using (var memoryStream = new MemoryStream())
            {
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                // Используем шрифт с поддержкой кириллицы
                var boldFont = PdfFontFactory.CreateFont("c:/windows/fonts/timesbd.ttf", PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);
                var regularFont = PdfFontFactory.CreateFont("c:/windows/fonts/times.ttf", PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);

                // Заголовок документа с жирным шрифтом
                document.Add(new Paragraph("Расчет петлевого металлического рекуператора")
                    .SetFont(boldFont)
                    .SetFontSize(20)
                    .SetTextAlignment(TextAlignment.CENTER));

                // Дата формирования
                document.Add(new Paragraph($"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}")
                    .SetFont(regularFont)
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.RIGHT));

                // Заголовок документа с жирным шрифтом
                document.Add(new Paragraph("Исходные данные")
                    .SetFont(boldFont)
                    .SetFontSize(18)
                    .SetTextAlignment(TextAlignment.CENTER));

                // Создаем таблицу
                var initial_table = new Table(2).UseAllAvailableWidth();

                // Добавляем заголовки с жирным текстом
                initial_table.AddHeaderCell(new Cell().Add(new Paragraph("Параметр").SetFont(boldFont)));
                initial_table.AddHeaderCell(new Cell().Add(new Paragraph("Значение").SetFont(boldFont)));

                // Добавляем данные в таблицу с шрифтом regularFont
                initial_table.AddCell("Температура воздуха на выходе из рекуператора, °С").SetFont(regularFont);
                initial_table.AddCell(model.Temp_Air_Output.ToString("0.00") ?? "N/A").SetFont(regularFont);

                initial_table.AddCell("Температура воздуха на входе в рекуператор, °С").SetFont(regularFont);
                initial_table.AddCell(model.Temp_Air_Input.ToString("0.00") ?? "N/A").SetFont(regularFont);

                initial_table.AddCell("Температура продуктов сгорания перед рекуператором, °С").SetFont(regularFont);
                initial_table.AddCell(model.Temp_Product_Input.ToString("0.00") ?? "N/A").SetFont(regularFont);

                initial_table.AddCell("Расход воздуха, м³/с").SetFont(regularFont);
                initial_table.AddCell(model.Consump_Air.ToString("0.00") ?? "N/A").SetFont(regularFont);

                initial_table.AddCell("Расход продуктов сгорания, м³/с").SetFont(regularFont);
                initial_table.AddCell(model.Consump_Product.ToString("0.00") ?? "N/A").SetFont(regularFont);

                initial_table.AddCell("Количество CO2, %").SetFont(regularFont);
                initial_table.AddCell(model.Percent_CO2.ToString("0.00") ?? "N/A").SetFont(regularFont);

                initial_table.AddCell("Количество H2O, %").SetFont(regularFont);
                initial_table.AddCell(model.Percent_H2O.ToString("0.00") ?? "N/A").SetFont(regularFont);

                initial_table.AddCell("Справочные данные - радиус секции").SetFont(regularFont);
                initial_table.AddCell(model.Radius_Section.ToString("0.00") ?? "N/A").SetFont(regularFont);

                document.Add(initial_table);
                // Заголовок документа с жирным шрифтом
                document.Add(new Paragraph("Результаты расчёта")
                    .SetFont(boldFont)
                    .SetFontSize(18)
                    .SetTextAlignment(TextAlignment.CENTER));

                // Создаем таблицу
                var table = new Table(2).UseAllAvailableWidth();

                // Добавляем заголовки с жирным текстом
                table.AddHeaderCell(new Cell().Add(new Paragraph("Параметр").SetFont(boldFont)));
                table.AddHeaderCell(new Cell().Add(new Paragraph("Значение").SetFont(boldFont)));

                // Добавляем данные в таблицу с шрифтом regularFont
                table.AddCell("Поверхность нагрева, м2").SetFont(regularFont);
                table.AddCell(model.Surface_Heat.ToString("0.00") ?? "N/A");

                table.AddCell("Максимальная температура стенки, °С").SetFont(regularFont);
                table.AddCell(model.Max_Temp_Wall.ToString("0.00") ?? "N/A");

                table.AddCell("Теплоемкость воздуха, Дж/(м3*К)").SetFont(regularFont);
                table.AddCell(model.Heat_Capacity_Air.ToString("0.00") ?? "N/A");

                table.AddCell("Теплоемкость дыма, Дж/(м3*К)").SetFont(regularFont);
                table.AddCell(model.Heat_Capacity_Smoke.ToString("0.00") ?? "N/A");

                table.AddCell("Энтальпия воздуха при начальной температуре, кДж/м3").SetFont(regularFont);
                table.AddCell(model.Entalp_Air_Start_Temp.ToString("0.00") ?? "N/A");

                table.AddCell("Энтальпия воздуха при конечной температуре, кДж/м3").SetFont(regularFont);
                table.AddCell(model.Entalp_Air_End_Temp.ToString("0.00") ?? "N/A");

                table.AddCell("Энтальпия дыма при начальной температуре, кДж/м3").SetFont(regularFont);
                table.AddCell(model.Entalp_Smoke_Start_Temp.ToString("0.00") ?? "N/A");

                table.AddCell("Средняя температура воздуха, °С").SetFont(regularFont);
                table.AddCell(model.Average_Temp_Air.ToString("0.00") ?? "N/A");

                table.AddCell("Средняя температура дыма, °С").SetFont(regularFont);
                table.AddCell(model.Average_Temp_Smoke.ToString("0.00") ?? "N/A");

                table.AddCell("Средняя температура стенки рекуператора, °С").SetFont(regularFont);
                table.AddCell(model.Average_Temp_Wall.ToString("0.00") ?? "N/A");

                table.AddCell("Отношение Тст/Тв").SetFont(regularFont);
                table.AddCell(model.Otnosh_Temp.ToString("0.00") ?? "N/A");

                table.AddCell("Фактическая скорость воздуха, м/с").SetFont(regularFont);
                table.AddCell(model.Fact_Speed_Air.ToString("0.00") ?? "N/A");

                table.AddCell("Фактическая скорость продуктов сгорания, м/с").SetFont(regularFont);
                table.AddCell(model.Fact_Speed_Product.ToString("0.00") ?? "N/A");

                table.AddCell("Действительная скорость воздуха, м/с").SetFont(regularFont);
                table.AddCell(model.Real_Speed_Air.ToString("0.00") ?? "N/A");

                table.AddCell("Действительная скорость продуктов сгорания, м/с").SetFont(regularFont);
                table.AddCell(model.Real_Speed_Product.ToString("0.00") ?? "N/A");

                table.AddCell("Количество тепла, переданного воздуху, кВт").SetFont(regularFont);
                table.AddCell(model.Heat_Air.ToString("0.00") ?? "N/A");

                table.AddCell("Количество тепла, вносимое в теплообменный аппарат продуктами сгорания, кВт").SetFont(regularFont);
                table.AddCell(model.Heat_Input_Product.ToString("0.00") ?? "N/A");

                table.AddCell("Количество тепла, уносимое продуктами сгорания, кВт").SetFont(regularFont);
                table.AddCell(model.Heat_Output_Product.ToString("0.00") ?? "N/A");

                table.AddCell("Энтальпия продуктов сгорания, кДж/м3").SetFont(regularFont);
                table.AddCell(model.Entalp_Product.ToString("0.00") ?? "N/A");

                table.AddCell("Температура продуктов сгорания после рекуператора, °С").SetFont(regularFont);
                table.AddCell(model.Temp_Product_Output.ToString("0.00") ?? "N/A");

                table.AddCell("Среднелогарифмическая разность температур").SetFont(regularFont);
                table.AddCell(model.Average_Log_Temp.ToString("0.00") ?? "N/A");

                table.AddCell("Параметр 1 для поверхности нагрева").SetFont(regularFont);
                table.AddCell(model.Heat_Parameter1.ToString("0.00") ?? "N/A");

                table.AddCell("Параметр 2 для поверхности нагрева").SetFont(regularFont);
                table.AddCell(model.Heat_Parameter2.ToString("0.00") ?? "N/A");

                table.AddCell("Число Рейнольдса 1").SetFont(regularFont);
                table.AddCell(model.Reynolds_Number_1.ToString("0.00") ?? "N/A");

                table.AddCell("Поправочный коэффициент для теплопередачи").SetFont(regularFont);
                table.AddCell(model.Popravka_Coef_Heat.ToString("0.00") ?? "N/A");

                table.AddCell("Поправочный коэффициент для теплопередачи (если изогнута труба)").SetFont(regularFont);
                table.AddCell(model.Popravka_Coef_Heat_Bend.ToString("0.00") ?? "N/A");

                table.AddCell("Суммарный поправочный коэффициент 1").SetFont(regularFont);
                table.AddCell(model.Sum_Popravka_Coef_1.ToString("0.00") ?? "N/A");

                table.AddCell("Число Нуссельта 1").SetFont(regularFont);
                table.AddCell(model.Nusselt_Number_1.ToString("0.00") ?? "N/A");

                table.AddCell("Коэффициент теплоотдачи конвекцией на пути движения воздуха, Вт/(м^2*оС)").SetFont(regularFont);
                table.AddCell(model.Coef_Heat_Convention_Air_Way.ToString("0.00") ?? "N/A");

                table.AddCell("Коэффициент теплоотдачи конвекцией в пересчете на поверхность наружной трубы, Вт/(м^2*оС)").SetFont(regularFont);
                table.AddCell(model.Coef_Heat_Convention_Surface_External.ToString("0.00") ?? "N/A");

                table.AddCell("Число Рейнольдса 2").SetFont(regularFont);
                table.AddCell(model.Reynolds_Number_2.ToString("0.00") ?? "N/A");

                table.AddCell("Суммарный поправочный коэффициент 2").SetFont(regularFont);
                table.AddCell(model.Sum_Popravka_Coef_2.ToString("0.00") ?? "N/A");

                table.AddCell("Число Нуссельта 2").SetFont(regularFont);
                table.AddCell(model.Nusselt_Number_2.ToString("0.00") ?? "N/A");

                table.AddCell("Коэффициент конвективной теплоотдачи").SetFont(regularFont);
                table.AddCell(model.Coef_Convention_Heat.ToString("0.00") ?? "N/A");

                table.AddCell("Эффективная длина луча").SetFont(regularFont);
                table.AddCell(model.Eff_Ray_Length.ToString("0.00") ?? "N/A");

                table.AddCell("Коэффициент для газовой части печной среды kг").SetFont(regularFont);
                table.AddCell(model.Coef_Gas_Environment.ToString("0.00") ?? "N/A");

                table.AddCell("Связующая величина").SetFont(regularFont);
                table.AddCell(model.Binding_Value.ToString("0.00") ?? "N/A");

                table.AddCell("Значение ɛ\"г").SetFont(regularFont);
                table.AddCell(model.Temporary_Value_Ray.ToString("0.00") ?? "N/A");

                table.AddCell("Коэффициент лучистой теплоотдачи, Вт/(м^2*оС)").SetFont(regularFont);
                table.AddCell(model.Coef_Ray_Heat.ToString("0.00") ?? "N/A");

                table.AddCell("Суммарный коэффициент теплоотдачи от пс к стенке, Вт/(м^2*оС)").SetFont(regularFont);
                table.AddCell(model.Sum_Coef_Heat_Wall.ToString("0.00") ?? "N/A");

                table.AddCell("Коэффициент теплопередачи, Вт/(м^2*оС)").SetFont(regularFont);
                table.AddCell(model.Coef_Heat.ToString("0.00") ?? "N/A");

                table.AddCell("Коэффициент теплопередачи с учетом загрязнения труб, Вт/(м^2*оС)").SetFont(regularFont);
                table.AddCell(model.Coef_Heat_Contamination.ToString("0.00") ?? "N/A");

                table.AddCell("Плотность теплового потока от продуктов сгорания к воздуху, Вт/м2").SetFont(regularFont);
                table.AddCell(model.Density_Heat_Flow.ToString("0.00") ?? "N/A");

                document.Add(table);
                document.Close();

                return File(memoryStream.ToArray(), "application/pdf", "CalculationResults.pdf");
            }
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
