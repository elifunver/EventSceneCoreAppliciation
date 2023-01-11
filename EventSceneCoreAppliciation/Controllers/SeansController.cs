using EventSceneCoreApplication.Models;
using EventSceneCoreApplication.Validaitons;
using BusinessLayer;
using BusinessLayer.Validaitons;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BusinessLayer.Concrete;

namespace EventSceneCoreApplication.Controllers
{
    public class SeansController : Controller
    {
        SeansManager seansManager = new SeansManager(new EfSeansRepository());
        EtkinlikManager etkinlikManager = new EtkinlikManager(new EfEtkinlikRepository());
        SalonManager salonManager = new SalonManager(new EfSalonRepository());
        public IActionResult Index()
        {
            var seanslar = seansManager.seansListele();
            return View(seanslar);
        }

        public IActionResult Sil(int id)
        {
            Seans seans = seansManager.seansGetById(id);
            seans.silindi = true;
            seansManager.seansGuncelle(seans);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            SeansEtkinlikModel seansEtkinlikModel = new SeansEtkinlikModel();
            seansEtkinlikModel.etkinlikModel = etkinlikManager.etkinlikListele();
            seansEtkinlikModel.salonModel = salonManager.salonListele();
            seansEtkinlikModel.seansModel = new Seans();
            return View(seansEtkinlikModel);
        }

        [HttpPost]
        public IActionResult Ekle(Seans seans)
        {
            SeansValidator etkinlikValidator = new SeansValidator();
            var result = etkinlikValidator.Validate(seans);
            if (result.IsValid)
            {
                seansManager.seansEkle(seans);
                return RedirectToAction("Index");
            }
            else
            {
                SeansEtkinlikModel seansEtkinlikModel = new SeansEtkinlikModel();
                seansEtkinlikModel.etkinlikModel = etkinlikManager.etkinlikListele();
                seansEtkinlikModel.salonModel = salonManager.salonListele();
                seansEtkinlikModel.seansModel = new Seans();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(seansEtkinlikModel);
            }
        }

        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            Seans seans = seansManager.seansGetById(id);

            SeansEtkinlikModel seansEtkinlikModel = new SeansEtkinlikModel();
            seansEtkinlikModel.etkinlikModel = etkinlikManager.etkinlikListele();
            seansEtkinlikModel.etkinlikOtobusModel = seans;
            seansEtkinlikModel.salonModel = salonManager.salonListele();
            return View(seansEtkinlikModel);
        }

        [HttpPost]
        public IActionResult Guncelle(Seans seans)
        {
            SeansValidator etkinlikValidator = new SeansValidator();
            var result = etkinlikValidator.Validate(seans);
            if (result.IsValid)
            {
                seansManager.seansGuncelle(seans);
                return RedirectToAction("Index");
            }
            else
            {
                SeansEtkinlikModel seansEtkinlikModel = new SeansEtkinlikModel();
                SeansEtkinlikModel.etkinlikModel = etkinlikManager.etkinlikListele();
                SeansEtkinlikModel.seansModel = seans;
                SeansEtkinlikModel.salonModel = salonManager.salonListele();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(seansEtkinlikModel);
            }
        }
    }
}