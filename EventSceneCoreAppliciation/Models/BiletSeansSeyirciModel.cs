using EntityLayer;
using System.Collections.Generic;

namespace EventSceneCoreAppliciation.Models
{
    public class BiletSeansSeyirciModel
    {
        public Bilet biletModel { get; set; }
        public IEnumerable<Seans> seansModel { get; set; }
        public IEnumerable<Seyirci> seyirciModel { get; set; }
    }
}
