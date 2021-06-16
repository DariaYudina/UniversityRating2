using BLL;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityRating.Models;

namespace UniversityRating.Controllers
{
    public class IndicatorController : Controller
    {

        private readonly IIndicatorLogic indicatorLogic;

        public IndicatorController(IIndicatorLogic indicatorLogic)
        {
            this.indicatorLogic = indicatorLogic;
        }

        // GET: IndicatorController
        public ActionResult Index()
        {
            return View("Home", "Index");
        }

        public ActionResult Indicators(int universityId)
        {
            var indicators = indicatorLogic.GetAllIndicators(universityId);
            List<IndicatorVM> indicatorsVM = indicators.Select(o =>
            new IndicatorVM
            {
                IndicatorId = o.IndicatorId,
                UniversityId = o.UniversityId,
                IndicatorName = o.IndicatorName,
                Value = o.Value,
                UnitOfMeasure = o.UnitOfMeasure,
                UniversityName = o.UniversityName
            }).ToList();
            return View(indicatorsVM);
    }

        // GET: IndicatorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IndicatorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndicatorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IndicatorVM indicator)
        {
            try
            {
                indicatorLogic.CreateIndicatorForUniversity(MapToIndicator(indicator));
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: IndicatorController/CreateAbstract
        public ActionResult CreateAbstract()
        {
            return View();
        }

        // POST: IndicatorController/CreateAbstract
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAbstract(IndicatorVM indicator)
        {
            try
            {
                indicatorLogic.CreateIndicator(MapToIndicator(indicator));
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: IndicatorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IndicatorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IndicatorVM indicator)
        {
            try
            {
                var updated = MapToIndicator(indicator);
                updated.IndicatorId = id;
                indicatorLogic.UpdateIndicator(updated);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: IndicatorController/EditAbstract/5
        public ActionResult EditAbstract(int id)
        {
            return View();
        }

        // POST: IndicatorController/EditAbstract/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAbstract(int id, IndicatorVM indicator)
        {
            try
            {
                var updated = MapToIndicator(indicator);
                updated.IndicatorId = id;
                indicatorLogic.UpdateIndicator(updated);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: IndicatorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IndicatorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Indicator MapToIndicator(IndicatorVM indicator)
		{
            return new Indicator
            {
                IndicatorId = indicator.IndicatorId,
                UniversityId = indicator.UniversityId,
                Value = indicator.Value,
                UnitOfMeasure = indicator.UnitOfMeasure,
                Year = indicator.Year,
                IndicatorName = indicator.IndicatorName
            };
		}
    }
}
