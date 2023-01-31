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
            EtkinlikTurModel model= new EtkinlikTurModel();
            model.turModel=turm.turListele();
            model.etkinlikModel=new Etkinlik();
            return View(model);
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
                EtkinlikTurModel model = new EtkinlikTurModel();
                model.turModel=turm.turListele();
                model.etkinlikModel=etkinlik;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }

        public IActionResult sil(int id)
        {
            Etkinlik etkinlik = etkinlikm.etkinlikGetById(id);
            etkinlik.silindi = true;
            etkinlikm.etkinlikGuncelle(etkinlik);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult guncelle(int id)
        {
            EtkinlikTurModel model = new EtkinlikTurModel();
            model.turModel=turm.turListele();
            model.etkinlikModel=etkinlikm.etkinlikGetById(id);
            return View(model);
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
                EtkinlikTurModel model = new EtkinlikTurModel();
                model.turModel=turm.turListele();
                model.etkinlikModel=etkinlik;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }
    }
}