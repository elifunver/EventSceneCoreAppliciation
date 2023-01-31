using System.Collections.Generic;
using EntityLayer;

namespace EventSceneCoreAppliciation.Models
{
    public class SeansEtkinlikSalonModel
    {
        public Seans seansModel { get; set; }
        public IEnumerable<Etkinlik> etkinlikModel { get; set; }
        public IEnumerable<Salon> salonModel { get; set; }
    }
}