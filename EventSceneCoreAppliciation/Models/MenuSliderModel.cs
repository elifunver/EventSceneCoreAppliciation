using EntityLayer;
using System.Collections.Generic;

namespace EventSceneCoreAppliciation.Models
{
    public class MenuSliderModel
    {
        public IEnumerable<Slider> sliderModel { get; set; }
        public IEnumerable<Menu> menuModel { get; set; }
    }
}