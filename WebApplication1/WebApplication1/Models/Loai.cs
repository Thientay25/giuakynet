using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        [Display(Name = "Mã loại")]
        public int MaLoai { get; set; }
        [Required(ErrorMessage = "Chưa nhập tên hàng hóa")]
        [MaxLength(50, ErrorMessage = "Tối đa 50 kí tự")]
        [Display(Name = "Tên loại")]
        public string TenLoai { get; set; }
       
    
    }
}
