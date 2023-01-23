using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Etkinlik
    {
        [Key]
        public int etkinlikId { get; set; }
        [StringLength(50)]
        public string etkinlikAd { get; set; }
        [StringLength(6000)]
        public string aciklama { get; set; }

        public string? etkinlikAfis { get; set; }

        public bool silindi { get; set; }

        //Tur ile ilişkilendirilecek.
        public int turId { get; set; }
        public virtual Tur tur { get; set; }

        //Seans ile ilişkilendirilecek.
        public virtual ICollection<Seans> seanslar { get; set; }
    }
}
