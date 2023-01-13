using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using EventSceneCoreAppliciation.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventSceneCoreAppliciation.Controllers
{
    public class EtkinlikController : Controller
    {
        EtkinlikManager etkinlikm = new EtkinlikManager(new EfEtkinlikRepository());
        TurManager turm=new TurManager(new EfTurRepository());

        public IActionResult Index()
        {
            var etkinlikler = etkinlikm.etkinlikListele();
            return View(etkinlikler);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
           var turList= turm.turListele();  
         
            return View(turList);
        }

        [HttpPost]
        public IActionResult Ekle(Etkinlik etkinlik)
        {
            EtkinlikValidator etkinlikValidator = new EtkinlikValidator();
            var result = etkinlikValidator.Validate(etkinlik);

            if (result.IsValid)
            {
                etkinlikm.etkinlikEkle(etkinlik);
                return RedirectToAction("Index");
            }

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                var turList = turm.turListele();

                return View(turList);
            }
        }

        public IActionResult sil(int id)
        {
            Etkinlik etkinlik = etkinlikm.etkinlikGetById(id);
            etkinlik.silindi = true;
            etkinlikm.etkinlikGuncelle(etkinlik);
            return RedirectToAction("Index");
        }

        public IActionResult guncelle(int id)
        {
            Etkinlik etkinlik = etkinlikm.etkinlikGetById(id);
            return View(etkinlik);
        }

        [HttpPost]
        public IActionResult guncelle(Etkinlik etkinlik)
        {
            EtkinlikValidator etkinlikValidator = new EtkinlikValidator();
            var result = etkinlikValidator.Validate(etkinlik);

            if (result.IsValid)
            {
                etkinlikm.etkinlikGuncelle(etkinlik);
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