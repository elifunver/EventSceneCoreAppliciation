using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Tur
    {
        [Key]
        public int turId { get; set; }
        [StringLength(50)]
        public string turAd { get; set; }
        public bool silindi{ get; set; }

        //Etkinlik ile ilişkilendirelecek.
        public virtual ICollection<Etkinlik> etkinlikler { get; set; }
    }
}
