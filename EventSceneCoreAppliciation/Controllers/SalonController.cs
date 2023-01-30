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

namespace EventSceneCoreAppliciation.Controllers
{
    public class SalonController : Controller
    {
        SalonManager salonm = new SalonManager(new EfSalonRepository());

        public IActionResult Index()
        {
            var salonlar = salonm.salonListele();
            return View(salonlar);

        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Salon salon)
        {
            SalonValidator salonValidator = new SalonValidator();
            var result = salonValidator.Validate(salon);

            if (result.IsValid)
            {
                salonm.salonEkle(salon);
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
            Salon salon = salonm.salonGetById(id);
            salon.silindi = true;
            salonm.salonGuncelle(salon);
            return RedirectToAction("Index");
        }

        public IActionResult guncelle(int id)
        {
            Salon salon = salonm.salonGetById(id);
            return View(salon);
        }

        [HttpPost]
        public IActionResult guncelle(Salon salon)
        {
            SalonValidator salonValidator = new SalonValidator();
            var result = salonValidator.Validate(salon);

            if (result.IsValid)
            {
                salonm.salonGuncelle(salon);
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