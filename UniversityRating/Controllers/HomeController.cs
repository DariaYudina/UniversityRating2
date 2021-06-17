using BLL;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UniversityRating.Models;

namespace UniversityRating.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIndicatorLogic indicatorLogic;


        public HomeController(ILogger<HomeController> logger, IIndicatorLogic indicatorLogic)
        {
            _logger = logger;
            this.indicatorLogic = indicatorLogic;
        }

        public IActionResult Index(int universityId = 1)
        {
            var years = indicatorLogic.GetAllYearsByUniversityId(universityId);
            var universities = indicatorLogic.GetAllUniversities();
            var indicators = indicatorLogic.GetAllIndicatorsByUniversityAndYear(universityId, 2010);

            List<IndicatorVM> indicatorsVM = SelectIndicatorVW(indicators);
            ViewBag.Universities = new SelectList(universities, "Id", "UniversityName");
            ViewBag.Years = new SelectList(years);

            return View(indicatorsVM);
        }

        private static List<IndicatorVM> SelectIndicatorVW(List<Indicator> indicators)
        {
            return indicators.Select(o =>
            new IndicatorVM
            {
                IndicatorId = o.IndicatorId,
                UniversityId = o.UniversityId,
                IndicatorName = o.IndicatorName,
                Value = o.Value,
                UnitOfMeasure = o.UnitOfMeasure,
                UniversityName = o.UniversityName,
                Year = o.Year
            }).ToList();
        }

        [HttpGet]
        public IActionResult CalculateIndicator(int id, int unid)
        {
            var indicatorStatistic = indicatorLogic.GetIndicatorsByIdAndUniversity(unid,id);
            var indicatorStatisticVW = SelectIndicatorVW(indicatorStatistic);
            return View("ChartRatings", indicatorStatisticVW);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(List<IndicatorVM> indicators)
        {
            return View("ChartRatings", indicators);
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CalculateColumn()
        {
            var indicators = indicatorLogic.GetAllIndicatorsByUniversityAndYear(1, 2018);

            List<IndicatorVM> indicatorsVM = indicators.Select(o =>
            new IndicatorVM
            {
                IndicatorId = o.IndicatorId,
                UniversityId = o.UniversityId,
                IndicatorName = o.IndicatorName,
                Value = o.Value,
                UnitOfMeasure = o.UnitOfMeasure,
                UniversityName = o.UniversityName,
                Year = o.Year
            }).ToList();
            return View("ColumnChartRatings", indicatorsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateIndicator(List<IndicatorVM> indicators)
        {
            var x = 1;
            return null;
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

        public void Proc()
        {
            // "C: \Users\Daria_Yudina\AppData\Local\Programs\Python\Python38"
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\Daria_Yudina\AppData\Local\Programs\Python\Python38\python.exe";
            var script = @"C:\Users\Daria_Yudina\source\repos\UniversityRating\UniversityRating\lab3.py";
            //[0.1, 0.5, 0.3]
            //0.5,0.1, 0.3
            //0.2, 0.1,0.1
            //0.9,0.2
            // 0.5, 0.1
            //1.5
            //1
            //psi.Arguments = $"\"{script}\"\"{0.1}\"\"{0.5}\"\"{0.3}\"\"{0.5}\"\"{0.1}\"\"{0.3}\"\"{0.2}\"\"{0.1}\"\"{0.1}\"\"{0.9}\"\"{0.2}\"\"{0.5}\"\"{0.1}\"\"{1.5}\"\"{1}\"";
            //psi.Arguments = $"\"{script}\"\"{0.1}\"\"{0.5}\"\"{0.3}\"\"{0.5}\"\"{0.1}\"\"{0.3}\"\"{0.2}\"\"{0.1}\"\"{0.1}\"\"{0.9}\"\"{0.2}\"\"{0.5}\"\"{0.1}\"\"{1.5}\"\"{1}\"";
            psi.Arguments = $"\"{script}\"";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            var errors = "";
            var results = "";
            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }
            var x = 1;
        }
    }
}
