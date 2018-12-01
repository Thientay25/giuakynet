using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("TinTuc")]
    public class TinTuc
    {
        [Key]
        public int MaTin { get; set; }
        [Required]
        [MaxLength(50)]
        public string TieuDe { get; set; }
        public string Hinh { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayDang { get; set; }  
        public int MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }
    }
}
