using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using EventSceneCoreAppliciation.Models;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using System.Drawing.Printing;
using EventSceneCoreAppliciation.PagedList;
using DataAccessLayer.Concrete;
using XAct.Security;
using Microsoft.AspNetCore.Authorization;

namespace EventSceneCoreAppliciation.Controllers
{
    [Authorize(Roles ="yönetici")]
	public class TurController : Controller
    {
        TurManager turm = new TurManager(new EfTurRepository());
       
        public IActionResult Index()
        {
            var turlar = turm.turListele();
            return View(turlar);

        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Tur tur)
        {
            TurValidator turValidator = new TurValidator();
            var result = turValidator.Validate(tur);

            if (result.IsValid)
            {
                turm.turEkle(tur);
                return RedirectToAction("Index");
            }

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        public IActionResult sil(int id)
        {
            Tur tur = turm.turGetById(id);
            tur.silindi = true;
            turm.turGuncelle(tur);
            return RedirectToAction("Index");
        }

        public IActionResult guncelle(int id)
        {
            Tur tur = turm.turGetById(id);
            return View(tur);
        }

        [HttpPost]
        public IActionResult guncelle(Tur tur)
        {
            TurValidator turValidator = new TurValidator();
            var result = turValidator.Validate(tur);

            if (result.IsValid)
            {
                turm.turGuncelle(tur);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}