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
        public int UserID { get; set; }

        [Required(ErrorMessage = "Bắt buộc.")]
        [Display(Name ="Họ tên")]
        public string HoTen { get; set; }      

        [Required(ErrorMessage = "Bắt buộc")]
        [Display(Name = "Tên tài khoản")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bắt buộc.")]
        [DataType(DataType.Password)]
        [Display(Name ="Mật khẩu")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Không trùng khớp.")]
        [DataType(DataType.Password)]
        [Display(Name ="Nhập lại mật khẩu")]
        public string ConfirmPassword { get; set; }
    }
}
