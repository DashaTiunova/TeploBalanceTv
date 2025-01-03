using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TeploBalanceKotelCore.Data;
using TeploBalanceKotelCore.Models;
using TeploBalanceKotelCore.Services;
using TeploBalanceKotelMathLib;

namespace TeploBalanceKotelCore.Controllers
{
   [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataContext_TverdToplivo _context;
        private User _user;
        private VarTverdToplivo _varTverdToplivo;
        private DataInputVariant_TverdToplivo _datainputvariant_tverdtoplivo;
        private TverdToplivoService _service;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, DataContext_TverdToplivo context, TverdToplivoService service, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return RedirectToAction("DataInputTverd");
        }
        #region Отображение страницы с входными данными
        public IActionResult DataInputTverd()
        {
            DataInputVariant_TverdToplivo loaded_variant = null;
            if (TempData["LoadedVariant"] != null)
            {
                loaded_variant = JsonConvert.DeserializeObject<DataInputVariant_TverdToplivo>(TempData["LoadedVariant"].ToString()); // Десериализация объекта
            }
            var viewModel = new VariantTverdModel
            {
                UserId = _service.GetUserId(User.Identity.Name),
                TverdVariants = _service.GetVariants(_service.GetUserId(User.Identity.Name))
            };

            TverdToplivo _cs = new TverdToplivo();
            DataInputVariant_TverdToplivo variant = new DataInputVariant_TverdToplivo();
            if (loaded_variant != null && loaded_variant.OwnerID_User != 0)
            {
                variant = loaded_variant;
            }
            #region --- Задать исходные данные для первого найденного варианта
            if (variant.OwnerID_User != 0)
            {
                _cs.TempPitWat = variant.TempPitWat;
                _cs.TempHeatWat = variant.TempHeatWat;
                _cs.Pressure = variant.Pressure;
                _cs.ParVyh = variant.ParVyh;
                _cs.RashWat = variant.RashWat;
                _cs.TempRabT = variant.TempRabT;
                _cs.SodH = variant.SodH;
                _cs.SodWP = variant.SodWP;
                _cs.SodC = variant.SodC;
                _cs.SodO = variant.SodO;
                _cs.SodS = variant.SodS;
                _cs.Alpha = variant.Alpha;
                _cs.TempVozd = variant.TempVozd;
                _cs.TempOut = variant.TempOut;
                _cs.QChem = variant.QChem;
                _cs.QMech = variant.QMech;
                _cs.QCold = variant.QCold;
                _cs.QWarm = variant.QWarm;

            }
            else
            {
                _cs.TempPitWat = 30d;
                _cs.TempHeatWat = 160d;
                _cs.Pressure = 2d;
                _cs.ParVyh = 2d;
                _cs.RashWat = 0.7d;
                _cs.TempRabT = 10d;
                _cs.SodH = 3.5d;
                _cs.SodWP = 8.5d;
                _cs.SodC = 62.6d;
                _cs.SodO = 8.5d;
                _cs.SodS = 0.4d;
                _cs.Alpha = 2d;
                _cs.TempVozd = 100d;
                _cs.TempOut = 180d;
                _cs.QChem = 2d;
                _cs.QMech = 1.5d;
                _cs.QCold = 1d;
                _cs.QWarm = 0.1d;
            }
            #endregion --- Задать исходные данные для первого найденного варианта

            ViewBag.DataInput = _cs;

            return RedirectToAction("DataInputTverd");
        }
        #endregion Отображение страницы с входными данными

        #region Получение результата расчёта
        [HttpPost]
        public IActionResult DataInputTverd(DataInputModelTverd DataInputTverd)
        {
            DataOutputModelTverd _rezult = new DataOutputModelTverd(DataInputTverd);

            ViewBag.EntPitWat = _rezult.EntPitWat;
            ViewBag.EntHeatWat = _rezult.EntHeatWat;
            ViewBag.EntBoilWat = _rezult.EntBoilWat;
            ViewBag.WarmQk = _rezult.WarmQk;
            ViewBag.WarmFuel = _rezult.WarmFuel;
            ViewBag.WarmBurnLow = _rezult.WarmBurnLow;
            ViewBag.LambdaAlpha = _rezult.LambdaAlpha;
            ViewBag.WarmBurnHigh = _rezult.WarmBurnHigh;
            ViewBag.N2 = _rezult.N2;
            ViewBag.O2 = _rezult.O2;
            ViewBag.CO2 = _rezult.CO2;
            ViewBag.SO2 = _rezult.SO2;
            ViewBag.H2O = _rezult.H2O;
            ViewBag.WarmHave = _rezult.WarmHave;
            ViewBag.BurnCO2 = _rezult.BurnCO2;
            ViewBag.BurnSO2 = _rezult.BurnSO2;
            ViewBag.BurnH2O = _rezult.BurnH2O;
            ViewBag.BurnN2 = _rezult.BurnN2;
            ViewBag.BurnO2 = _rezult.BurnO2;
            ViewBag.VAlpha = _rezult.VAlpha;
            ViewBag.EntOutGas = _rezult.EntOutGas;
            ViewBag.LossGas = _rezult.LossGas;
            ViewBag.LossChem = _rezult.LossChem;
            ViewBag.LossMech = _rezult.LossMech;
            ViewBag.LossOutCold = _rezult.LossOutCold;
            ViewBag.LossFullWarm = _rezult.LossFullWarm;
            ViewBag.KPD = _rezult.KPD;
            ViewBag.RashodTopl = _rezult.RashodTopl;

            var lists = new List<double>()
            {
                _rezult.EntPitWat,
                _rezult.EntHeatWat,
                _rezult.EntBoilWat,
                _rezult.WarmQk,
                _rezult.WarmFuel,
                _rezult.WarmBurnLow,
                _rezult.LambdaAlpha,
                _rezult.WarmBurnHigh,
                _rezult.N2,
                _rezult.O2,
                _rezult.CO2,
                _rezult.SO2,
                _rezult.H2O,
                _rezult.WarmHave,
                _rezult.BurnCO2,
                _rezult.BurnSO2,
                _rezult.H2O,
                _rezult.N2,
                _rezult.O2,
                _rezult.VAlpha,
                _rezult.EntOutGas,
                _rezult.LossGas,
                _rezult.LossChem,
                _rezult.LossMech,
                _rezult.LossOutCold,
                _rezult.LossFullWarm,
                _rezult.KPD,
                _rezult.RashodTopl


            };

            ViewBag.lists = Newtonsoft.Json.JsonConvert.SerializeObject(lists);

            return View("RezultTverd");
        }
        #endregion Получение результата расчёта
        #region Сохранение варианта
        [HttpPost]
        public IActionResult SaveVariantForTverd(TverdVariantAddDtoModel model)
        {
            var temp_variant = new VariantAddDto
            {
                Name = model.Name,
                Description = model.Description,
                UserId = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name).ID_User,
            };
            var variant = _mapper.Map<VarTverdToplivo>(temp_variant);
            _context.VarTverdToplivos.Add(variant);
            _context.SaveChanges();
            var temp_variantUser = new VariantUserTverdAddDtoModel
            {
                VariantId = _service.GetVariantId(temp_variant),
                UserId = model.UserId,
                ParVyh = model.ParVyh,
                RashWat = model.RashWat,
                TempPitWat = model.TempPitWat,
                TempHeatWat = model.TempHeatWat,
                Pressure = model.Pressure,
                TempRabT = model.TempRabT,
                SodH = model.SodH,
                SodO = model.SodO,
                SodC = model.SodC,
                SodS = model.SodS,
                SodWP = model.SodWP,
                Alpha = model.Alpha,
                TempVozd = model.TempVozd,
                TempOut = model.TempOut,
                QChem = model.QChem,
                QMech = model.QMech,
                QCold = model.QCold,
                QWarm = model.QWarm,
            };
            var variantUser = _mapper.Map<DataInputVariant_TverdToplivo>(temp_variantUser);
            _context.DataInputVariants_TverdToplivo.Add(variantUser);
            _context.SaveChanges();
            return RedirectToAction("DataInputTverd");
        }
        #endregion
        //Input для газа
        public IActionResult DataInput()
        {
            GasToplivo _cs = new GasToplivo();

            #region --- Задать исходные данные для первого найденного варианта

            _cs.TempPitWat = 30d;
            _cs.TempHeatWat = 200d;
            _cs.Pressure = 2d;
            _cs.ParVyh = 2d;
            _cs.RashWat = 0.7d;
            _cs.TempRabT = 30d;
            _cs.SodCH4 = 94.23d;
            _cs.SodC2H6 = 3d;
            _cs.SodC3H8 = 0.89d;
            _cs.SodC4H10 = 0.39d;
            _cs.SodC5H12 = 0.17d;
            _cs.SodC6H14 = 0.13d;
            _cs.SodCO = 0d;
            _cs.SodCO2 = 0.29d;
            _cs.SodN2 = 0.9d;
            _cs.SodO2 = 0d;
            _cs.SodH2S = 0d;
            _cs.SodH2 = 0d;
            _cs.Alpha = 1.12d;
            _cs.TempVozd = 30d;
            _cs.TempOut = 160d;
            _cs.QChem = 2d;
            _cs.QMech = 1.5d;
            _cs.QCold = 1d;

            #endregion --- Задать исходные данные для первого найденного варианта

            ViewBag.DataInput = _cs;

            return View();
        }

        //Input для жидкого
        public IActionResult DataInputZhidk()
        {
            ZhidkToplivo _cs = new ZhidkToplivo();

            #region --- Задать исходные данные для второго найденного варианта

            _cs.TempPitWat = 30d;
            _cs.TempHeatWat = 160d;
            _cs.Pressure = 2d;
            _cs.ParVyh = 2d;
            _cs.RashWat = 0.7d;
            _cs.TempRabT = 30d;
            _cs.SodH = 10d;
            _cs.SodWP = 3d;
            _cs.SodC = 85d;
            _cs.SodO = 0.9d;
            _cs.SodS = 0.4d;
            _cs.SodN = 0.4d;
            _cs.Alpha = 1.12d;
            _cs.TempVozd = 30d;
            _cs.TempOut = 160d;
            _cs.QChem = 2d;
            _cs.QMech = 1.5d;
            _cs.QCold = 1d;
            _cs.QWarm = 0.1d;

            #endregion --- Задать исходные данные для первого найденного варианта

            ViewBag.DataInputZhidk = _cs;

            return View();
        }

        //Input для твердого
        public IActionResult DataInputTverdZapas()
        {
            TverdToplivo _cs = new TverdToplivo();

            #region --- Задать исходные данные для второго найденного варианта

            _cs.TempPitWat = 30d;
            _cs.TempHeatWat = 160d;
            _cs.Pressure = 2d;
            _cs.ParVyh = 2d;
            _cs.RashWat = 0.7d;
            _cs.TempRabT = 10d;
            _cs.SodH = 3.5d;
            _cs.SodWP = 8.5d;
            _cs.SodC = 62.6d;
            _cs.SodO = 8.5d;
            _cs.SodS = 0.4d;
            _cs.Alpha = 2d;
            _cs.TempVozd = 100d;
            _cs.TempOut = 180d;
            _cs.QChem = 2d;
            _cs.QMech = 1.5d;
            _cs.QCold = 1d;
            _cs.QWarm = 0.1d;

            #endregion --- Задать исходные данные для первого найденного варианта

            ViewBag.DataInputTverd = _cs;

            return View();
        }
        //Output для газа
        [HttpPost]
        public IActionResult DataInput(DataInputModel DataInput)
        {
            DataOutputModel _rezult = new DataOutputModel(DataInput);

            ViewBag.EntPitWat = _rezult.EntPitWat;
            ViewBag.EntHeatWat = _rezult.EntHeatWat;
            ViewBag.EntBoilWat = _rezult.EntBoilWat;
            ViewBag.WarmQk = _rezult.WarmQk;
            ViewBag.WarmFuel = _rezult.WarmFuel;
            ViewBag.WarmBurnLow = _rezult.WarmBurnLow;
            ViewBag.LambdaAlpha = _rezult.LambdaAlpha;
            ViewBag.WarmBurnHigh = _rezult.WarmBurnHigh;
            ViewBag.N2 = _rezult.N2;
            ViewBag.O2 = _rezult.O2;
            ViewBag.CO2 = _rezult.CO2;
            ViewBag.SO2 = _rezult.SO2;
            ViewBag.H2O = _rezult.H2O;
            ViewBag.WarmHave = _rezult.WarmHave;
            ViewBag.BurnCO2 = _rezult.BurnCO2;
            ViewBag.BurnSO2 = _rezult.BurnSO2;
            ViewBag.BurnH2O = _rezult.BurnH2O;
            ViewBag.BurnN2 = _rezult.BurnN2;
            ViewBag.BurnO2 = _rezult.BurnO2;
            ViewBag.VAlpha = _rezult.VAlpha;
            ViewBag.EntOutGas = _rezult.EntOutGas;
            ViewBag.LossGas = _rezult.LossGas;
            ViewBag.LossChem = _rezult.LossChem;
            ViewBag.LossMech = _rezult.LossMech;
            ViewBag.LossOutCold = _rezult.LossOutCold;
            ViewBag.LossFullWarm = _rezult.LossFullWarm;
            ViewBag.KPD = _rezult.KPD;
            ViewBag.RashodTopl = _rezult.RashodTopl;

            var lists = new List<double>()
            {
                _rezult.EntPitWat,
                _rezult.EntHeatWat,
                _rezult.EntBoilWat,
                _rezult.WarmQk,
                _rezult.WarmFuel,
                _rezult.WarmBurnLow,
                _rezult.LambdaAlpha,
                _rezult.WarmBurnHigh,
                _rezult.N2,
                _rezult.O2,
                _rezult.CO2,
                _rezult.SO2,
                _rezult.H2O,
                _rezult.WarmHave,
                _rezult.BurnCO2,
                _rezult.BurnSO2,
                _rezult.BurnH2O,
                _rezult.BurnN2,
                _rezult.BurnO2,
                _rezult.VAlpha,
                _rezult.EntOutGas,
                _rezult.LossGas,
                _rezult.LossChem,
                _rezult.LossMech,
                _rezult.LossOutCold,
                _rezult.LossFullWarm,
                _rezult.KPD,
                _rezult.RashodTopl


            };

            ViewBag.lists = Newtonsoft.Json.JsonConvert.SerializeObject(lists);

            return View("Rezult");
        }

        //Output для жидкого
        [HttpPost]
        public IActionResult DataInputZhidk(DataInputModelZhidk DataInputZhidk)
        {
            DataOutputModelZhidk _rezult = new DataOutputModelZhidk (DataInputZhidk);

            ViewBag.EntPitWat = _rezult.EntPitWat;
            ViewBag.EntHeatWat = _rezult.EntHeatWat;
            ViewBag.EntBoilWat = _rezult.EntBoilWat;
            ViewBag.WarmQk = _rezult.WarmQk;
            ViewBag.WarmFuel = _rezult.WarmFuel;
            ViewBag.WarmBurnLow = _rezult.WarmBurnLow;
            ViewBag.LambdaAlpha = _rezult.LambdaAlpha;
            ViewBag.WarmBurnHigh = _rezult.WarmBurnHigh;
            ViewBag.N2 = _rezult.N2;
            ViewBag.O2 = _rezult.O2;
            ViewBag.CO2 = _rezult.CO2;
            ViewBag.SO2 = _rezult.SO2;
            ViewBag.H2O = _rezult.H2O;
            ViewBag.WarmHave = _rezult.WarmHave;
            ViewBag.BurnCO2 = _rezult.BurnCO2;
            ViewBag.BurnSO2 = _rezult.BurnSO2;
            ViewBag.BurnH2O = _rezult.BurnH2O;
            ViewBag.BurnN2 = _rezult.BurnN2;
            ViewBag.BurnO2 = _rezult.BurnO2;
            ViewBag.VAlpha = _rezult.VAlpha;
            ViewBag.EntOutGas = _rezult.EntOutGas;
            ViewBag.LossGas = _rezult.LossGas;
            ViewBag.LossChem = _rezult.LossChem;
            ViewBag.LossMech = _rezult.LossMech;
            ViewBag.LossOutCold = _rezult.LossOutCold;
            ViewBag.LossFullWarm = _rezult.LossFullWarm;
            ViewBag.KPD = _rezult.KPD;
            ViewBag.RashodTopl = _rezult.RashodTopl;

            var lists = new List<double>()
            {
                _rezult.EntPitWat,
                _rezult.EntHeatWat,
                _rezult.EntBoilWat,
                _rezult.WarmQk,
                _rezult.WarmFuel,
                _rezult.WarmBurnLow,
                _rezult.LambdaAlpha,
                _rezult.WarmBurnHigh,
                _rezult.N2,
                _rezult.O2,
                _rezult.CO2,
                _rezult.SO2,
                _rezult.H2O,
                _rezult.WarmHave,
                _rezult.BurnCO2,
                _rezult.BurnSO2,
                _rezult.H2O,
                _rezult.N2,
                _rezult.O2,
                _rezult.VAlpha,
                _rezult.EntOutGas,
                _rezult.LossGas,
                _rezult.LossChem,
                _rezult.LossMech,
                _rezult.LossOutCold,
                _rezult.LossFullWarm,
                _rezult.KPD,
                _rezult.RashodTopl


            };

            ViewBag.lists = Newtonsoft.Json.JsonConvert.SerializeObject(lists);

            return View("RezultZhidk");
        }


       
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
