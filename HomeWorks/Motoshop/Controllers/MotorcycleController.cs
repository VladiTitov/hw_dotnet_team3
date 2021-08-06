using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motoshop.Attributes;
using Motoshop.BL;
using Motoshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Motoshop.Controllers
{
    public class MotorcycleController : Controller
    {
        readonly ITransportRepository<Moto> _motoRepository;

        public MotorcycleController()
        {
            _motoRepository = new StaticCollectionTransportRepository<Moto>();
        }
        
        // GET: MotorcycleController
        public ActionResult Index()
        {
            var motorcycles = _motoRepository.Get();
            return View(motorcycles);
        }

        // GET: MotorcycleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MotorcycleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MotorcycleController/Create

        [HttpPost]
        [ActionName("Create")]
        [AcceptVerbs]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Moto moto)
        {
            try
            {
                if (moto != null)
                {
                    Type type = moto.GetType();
                    foreach (PropertyInfo pi in type.GetProperties())
                    {
                        foreach (Attribute attribute in pi.GetCustomAttributes())
                        {
                            GuidAttribute guid = attribute as GuidAttribute;
                            if (guid != null)
                            {
                                guid.Validate(moto);
                            }
                        }
                    }
                    foreach (PropertyInfo pi in type.GetProperties())
                    {
                        foreach (Attribute attribute in pi.GetCustomAttributes())
                        {
                            MinYearAttribute minYearAttribute = attribute as MinYearAttribute;
                            if (minYearAttribute != null)
                            {
                                minYearAttribute.Validate(moto);
                            }
                        }
                    }
                    _motoRepository.Create(moto);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MotorcycleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MotorcycleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: MotorcycleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MotorcycleController/Delete/5
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
    }
}
