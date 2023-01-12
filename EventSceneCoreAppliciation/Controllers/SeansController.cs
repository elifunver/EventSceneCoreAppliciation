using BusinessLayer.Validaitons;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using EventSceneCoreAppliciation.Models;

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
            SeansEtkinlikSalonModel seansEtkinlikSalonModel = new SeansEtkinlikSalonModel();
            seansEtkinlikSalonModel.etkinlikModel = etkinlikManager.etkinlikListele();
            seansEtkinlikSalonModel.salonModel = salonManager.salonListele();
            seansEtkinlikSalonModel.seansModel = new Seans();
            return View(seansEtkinlikSalonModel);
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
                SeansEtkinlikSalonModel seansEtkinlikSalonModel = new SeansEtkinlikSalonModel();
                seansEtkinlikSalonModel.etkinlikModel = etkinlikManager.etkinlikListele();
                seansEtkinlikSalonModel.salonModel = salonManager.salonListele();
                seansEtkinlikSalonModel.seansModel = new Seans();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(seansEtkinlikSalonModel);
            }
        }

        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            Seans seans = seansManager.seansGetById(id);
            SeansEtkinlikSalonModel seansEtkinlikSalonModel = new SeansEtkinlikSalonModel();
            seansEtkinlikSalonModel.etkinlikModel = etkinlikManager.etkinlikListele();
            seansEtkinlikSalonModel.seansModel = seans;
            seansEtkinlikSalonModel.salonModel = salonManager.salonListele();
            return View(seansEtkinlikSalonModel);
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
                SeansEtkinlikSalonModel seansEtkinlikSalonModel = new SeansEtkinlikSalonModel();
                seansEtkinlikSalonModel.etkinlikModel = etkinlikManager.etkinlikListele();
                seansEtkinlikSalonModel.seansModel = seans;
                seansEtkinlikSalonModel.salonModel = salonManager.salonListele();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(seansEtkinlikSalonModel);
            }
        }
    }
}