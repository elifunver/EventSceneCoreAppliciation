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
        public string kullaniciAd { get; set; }
        [StringLength(50)]
        public string kullaniciSifre { get; set; }
        [StringLength(11)]
        public string kullaniciTc { get; set; }
        [StringLength(11)]
        public string kullaniciTel { get; set; }
        [StringLength(50)]
        public string kullaniciMail { get; set; }
        public DateTime dogumTarihi { get; set; }
        public bool silindi { get; set; }

        //Bilet ile ilişkilendirilecek.
        public virtual ICollection<Bilet> biletler { get; set; }
    }
}
