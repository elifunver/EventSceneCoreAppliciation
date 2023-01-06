using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Bilet
    {
        [Key]
        public int biletId { get; set; }
        [StringLength(50)]
        public string seyirciAd { get; set; }
        [StringLength(50)]
        public string seyirciSoyad { get; set; }
        [StringLength(50)]
        public int fiyat { get; set; }
        public DateTime biletKesimTarihi { get; set; }
        public bool silindi { get; set; }

        //Seans ile ilişkilendirilecek.
        public int seansId { get; set; }
        public virtual Seans seans { get; set; }

        //Seyirci ile ilişkilendirilecek.
        public int seyirciId { get; set; }
        public virtual Seyirci seyirci { get; set; }
    }
}
