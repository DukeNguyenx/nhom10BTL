using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLNS.Models
{
    public class Phongban
    { 
        [Key]
        [Display(Name ="Mã Phòng")]
        public string? MaPhong { get; set; }
        [Display(Name ="Tên Phòng")]
        public string? TenPhong { get; set; }
    }
}