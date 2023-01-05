using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Kullanici
    {
        [Key]
        public int kullaniciId { get; set; }
        [StringLength(50)]
        public string kullaniciSifre { get; set; }
        [StringLength(50)]
        public string kullaniciTur { get; set; }
        public DateTime dogumTarihi { get; set; }
        [StringLength(11)]
        public string tc { get; set; }
        [StringLength(50)]
        public string mail { get; set; }
        public bool cinsiyet { get; set; }
        [StringLength(11)]
        public string tel { get; set; }

        public bool silindi { get; set; }

        //guzergahOtobusKullanici ile ilişkilendirelecek.
        public virtual ICollection<GuzergahOtobusKullanici> biletler { get; set; }
    }
}
