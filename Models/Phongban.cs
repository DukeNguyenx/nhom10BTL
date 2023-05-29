using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLNS.Models
{
    public class Phongban
    { 
        [Key]
        [Display(Name ="Mã Phòng")]
        public string? MaPhong { get; set; }
        
        [Required(ErrorMessage ="Tên của phòng không được bỏ trống")]
        [Display(Name ="Tên Phòng")]
        public string? TenPhong { get; set; }
    }
}