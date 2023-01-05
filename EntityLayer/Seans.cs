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

        //Tür ile ilişkilendirelecek.
        public virtual ICollection<Tur> turler { get; set; }
    }
}
