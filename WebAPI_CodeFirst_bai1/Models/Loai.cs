using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebAPI_CodeFirst_bai1.Models
{
    public class Loai
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string TenLoai { get; set; }
               

    }

    public class LoaiViewModel
    {
        [MaxLength(50)]
        public string TenLoai { get; set; }
    }
}
