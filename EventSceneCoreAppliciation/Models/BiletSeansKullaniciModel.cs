using EntityLayer;
using System.Collections.Generic;

namespace EventSceneCoreAppliciation.Models
{
    public class BiletSeansKullaniciModel
    {
        public Bilet biletModel { get; set; }
        public IEnumerable<Seans> seansModel { get; set; }
        public IEnumerable<Kullanici> kullaniciModel { get; set; }
    }
}