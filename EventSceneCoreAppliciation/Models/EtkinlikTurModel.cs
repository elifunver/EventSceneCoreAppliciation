using EntityLayer;

namespace EventSceneCoreAppliciation.Models
{
    public class EtkinlikTurModel
    {
        public Etkinlik etkinlikModel { get; set; }
        public IEnumerable<Tur> turModel { get; set; }
    }
}