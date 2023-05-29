using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLNS.Models
{
    public class Hopdong
    { 
        [Key]
        [Required(ErrorMessage ="Mã nhân viên không được bỏ trống")]
        [Display(Name ="Mã Nhân viên")]
        public string MaNV { get; set; }
        [Required(ErrorMessage ="Không được bỏ trống ngày")]
        [Display(Name ="Ngày bắt đầu")]
        public string Ngaybatdau { get; set; }
        [Required(ErrorMessage ="Không được bỏ trống ngày")]
        [Display(Name ="Ngày kết thúc")]
        public string Ngayketthuc { get; set; }
    }
}