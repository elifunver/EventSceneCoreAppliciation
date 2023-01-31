using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using EventSceneCoreAppliciation.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventSceneCoreAppliciation.Controllers
{
    public class SeansController : Controller
    {
        SeansManager seansm = new SeansManager(new EfSeansRepository());
        EtkinlikManager etkinlikm = new EtkinlikManager(new EfEtkinlikRepository());
        SalonManager salonm = new SalonManager(new EfSalonRepository());
        public IActionResult Index()
        {
            var seanslar = seansm.seansListele();
            return View(seanslar);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            SeansEtkinlikSalonModel model = new SeansEtkinlikSalonModel();
            model.etkinlikModel = etkinlikm.etkinlikListele();
            model.salonModel = salonm.salonListele();
            model.seansModel = new Seans();
            return View(model);
        }

        [HttpPost]
        public IActionResult Ekle(Seans seans)
        {
            SeansValidator seansValidator = new SeansValidator();
            var result = seansValidator.Validate(seans);

            if (result.IsValid)
            {
                seansm.seansEkle(seans);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                SeansEtkinlikSalonModel model = new SeansEtkinlikSalonModel();
                model.etkinlikModel = etkinlikm.etkinlikListele();
                model.salonModel = salonm.salonListele();
                model.seansModel = seans;
                return View(model);
            }
        }

        public IActionResult Sil(int id)
        {
            Seans seans = seansm.seansGetById(id);
            seans.silindi = true;
            seansm.seansGuncelle(seans);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            SeansEtkinlikSalonModel model = new SeansEtkinlikSalonModel();
            model.etkinlikModel = etkinlikm.etkinlikListele();
            model.salonModel = salonm.salonListele();
            model.seansModel = seansm.seansGetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Guncelle(Seans seans)
        {
            SeansValidator seansValidator = new SeansValidator();
            var result = seansValidator.Validate(seans);

            if (result.IsValid)
            {
                seansm.seansGuncelle(seans);
                return RedirectToAction("Index");
            }
            else
            {
                SeansEtkinlikSalonModel model = new SeansEtkinlikSalonModel();
                model.etkinlikModel = etkinlikm.etkinlikListele();
                model.salonModel = salonm.salonListele();
                model.seansModel = seans;

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }
    }
}