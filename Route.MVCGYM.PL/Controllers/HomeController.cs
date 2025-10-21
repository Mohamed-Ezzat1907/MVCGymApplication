using Microsoft.AspNetCore.Mvc;
using Route.GYM.BLL.Services.Analytics;

namespace Route.MVCGYM.PL.Controllers
{
    public class HomeController : Controller
    {
        #region Fields

        private readonly ILogger<HomeController> _logger;
        private readonly IAnalyticsService _analyticsService;

        #endregion

        #region Constructor

        public HomeController(ILogger<HomeController> logger, IAnalyticsService analyticsService)
        {
            _logger = logger;
            _analyticsService = analyticsService;
        } 

        #endregion

        public IActionResult Index()
        {
            var analyticData = _analyticsService.GetAnalyticsData();

            return View(analyticData);
        }

     

    }
}
