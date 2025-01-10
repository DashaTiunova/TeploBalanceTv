using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TeploBalanceKotelCore.Data;
using TeploBalanceKotelCore.Models;
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
        public HomeController(ILogger<HomeController> logger, DataContext_TverdToplivo context )
        {
            _logger = logger;
            _context = context;
        }

        public ActionResult Index()
        {
            return RedirectToAction("DataInputTverd"); ;
        }

       
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
        public async Task<IActionResult> DataInputTverd(VarTverdToplivo model)
        {
          
            

                if (User.Identity.IsAuthenticated)
                {
                    var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");
                    if (userIdClaim != null)
                    {
                        var userId = int.Parse(userIdClaim.Value); 

                        var varTverd = new VarTverdToplivo
                        {
                            OwnerID_User = userId,
                            DateVariant = DateTime.Now,
                            NameVariant_TverdToplivo = model.NameVariant_TverdToplivo,
                            Description = model.Description
                        };

                        // Добавляем в контекст
                        _context.VarTverdToplivos.Add(varTverd);
                        await _context.SaveChangesAsync();  

                    }
                }

            
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


        //Output для твердого
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
