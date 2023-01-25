using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_CodeFirst_bai1.Models
{
    public class HangHoa
    {
        [Key]
        public int Id { get; set; }
        public string TenHangHoa { get; set; }
        public string MoTa { get; set; }
        public double DonGia { get; set; }
        public double GiamGia { get; set; }

        public int? MaLoaiId { get; set; }
        [ForeignKey("Loai")]
        public Loai loai { get; set; }
        public ICollection<DonHangChiTiet> DonHangChiTiets { set; get; }

        public HangHoa() {
            DonHangChiTiets = new List<DonHangChiTiet>();
        }
    }

    public class HangHoaVM {
        public int id { get; set; }
        public string TenHangHoa { get; set; }
        public string MoTa { get; set; }
        public double DonGia { get; set; }
        public double GiamGia { get; set; }
        public int? MaLoaiId { get; set; }
    }
}
