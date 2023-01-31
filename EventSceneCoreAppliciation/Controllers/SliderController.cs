using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace EventSceneCoreAppliciation.Controllers
{
    public class SliderController: Controller
    {
        SliderManager sm = new SliderManager(new EfSliderRepository());

        public IActionResult Index()
        {

            return View(sm.SliderListele());
        }

        [HttpGet]
        public IActionResult Ekle()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Slider slider)
        {
            sm.sliderEkle(slider);
            return RedirectToAction("Index");
        }

        public IActionResult sil(int id)
        {
            Slider slider = sm.sliderGetById(id);
            slider.silindi = true;
            sm.sliderGuncelle(slider);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult guncelle(int id)
        {
            return View(sm.sliderGetById(id));
        }

        [HttpPost]
        public IActionResult guncelle(Slider slider)
        {
            sm.sliderGuncelle(slider);
            return RedirectToAction("Index");
        }
    }
}