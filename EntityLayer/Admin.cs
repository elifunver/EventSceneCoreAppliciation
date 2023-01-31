using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Admin
    {
        [Key]
        public int adminId { get; set; }

        [StringLength(20)]
        public string adminAd { get; set; }

        [StringLength(20)]
        public string adminSifre { get; set; }

        [StringLength(50)]
        public string adminMail { get; set; }

        [StringLength(20)]
        public string adminTur { get; set; }

        public bool silindi { get; set; }
    }
}