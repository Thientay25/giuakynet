using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public string MaKh { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
    }
}
