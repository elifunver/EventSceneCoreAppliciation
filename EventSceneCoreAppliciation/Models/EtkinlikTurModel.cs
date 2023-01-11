using EntityLayer;

namespace EventSceneCoreAppliciation.Models
{
    public class EtkinlikTurModel
    {
        public Etkinlik etkinlikModal { get; set; }
        public IEnumerable<Tur> turModal { get; set; }
    }
}
