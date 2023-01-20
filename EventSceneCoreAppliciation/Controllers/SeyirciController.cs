using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace EventSceneCoreAppliciation.Controllers
{
    public class SeyirciController : Controller
    {
        SeyirciManager seyircim = new SeyirciManager(new EfSeyirciRepository());

        public IActionResult Index()
        {
            var seyirciler = seyircim.seyirciListele();
            return View(seyirciler);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Seyirci seyirci)
        {
            SeyirciValidator seyirciValidator = new SeyirciValidator();
            var result = seyirciValidator.Validate(seyirci);

            if (result.IsValid)
            {
                seyircim.seyirciEkle(seyirci);
                return RedirectToAction("Index");
            }

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(seyirci);
            }
        }

        public IActionResult sil(int id)
        {
            Seyirci seyirci = seyircim.seyirciGetById(id);
            seyirci.silindi = true;
            seyircim.seyirciGuncelle(seyirci);
            return RedirectToAction("Index");
        }

        public IActionResult guncelle(int id)
        {
            Seyirci seyirci = seyircim.seyirciGetById(id);
            return View(seyirci);
        }

        [HttpPost]
        public IActionResult guncelle(Seyirci seyirci)
        {
            SeyirciValidator seyirciValidator = new SeyirciValidator();
            var result = seyirciValidator.Validate(seyirci);

            if (result.IsValid)
            {
                seyircim.seyirciGuncelle(seyirci);
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