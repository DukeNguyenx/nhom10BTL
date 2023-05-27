using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLNS.Models
{
    public class ChucVu
    { 
        [Key]
        [Display(Name ="Mã chức vụ")]
        public string? MaCV { get; set; }
        [Display(Name ="Tên chức vụ")]
        public string? TenCV { get; set; }
    }
}