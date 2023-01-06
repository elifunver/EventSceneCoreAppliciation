using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Salon
    {
        [Key]
        public int salonId { get; set; }
        [StringLength(50)]
        public string salonAd { get; set; }
        [StringLength(50)]
        public int kapasite { get; set; }

        public bool silindi { get; set; }

        //Seans ile ilişkilendirilecek.
        public virtual ICollection<Seans> seanslar { get; set; }
    }
}
