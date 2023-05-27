using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLNS.Models
{
    public class Hopdong
    { 
        [Key]
        [Display(Name ="Mã Nhân viên")]
        public string MaNV { get; set; }
        [Display(Name ="Ngày bắt đầu")]
        public string Ngaybatdau { get; set; }
        [Display(Name ="Ngày kết thúc")]
        public string Ngayketthuc { get; set; }
    }
}