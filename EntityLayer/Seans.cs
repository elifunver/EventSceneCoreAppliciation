using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Seans
    {
        [Key]
        public int seansId { get; set; }
        [StringLength(50)]
        public string sure { get; set; }
        [StringLength(50)]
        public DateTime tarih { get; set; }
        [StringLength(50)]
        public string saat { get; set; }
        public bool silindi { get; set; }

        //Etkinlik ile ilişkilendirilecek.
        public int etkinlikId { get; set; }
        public virtual Etkinlik etkinlik{ get; set; }

        //Salon ile ilişkilendirilecek.
        public int salonId { get; set; }
        public virtual Salon salon { get; set; }

        //Bilet ile ilişkilendirelecek.
        public virtual ICollection<Bilet> biletler { get; set; }
    }
}