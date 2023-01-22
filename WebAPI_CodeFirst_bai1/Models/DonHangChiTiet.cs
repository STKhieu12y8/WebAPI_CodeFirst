namespace WebAPI_CodeFirst_bai1.Models
{
    public class DonHangChiTiet
    {
        public int MaDonHangId { get; set; }
        public int HangHoaId { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }

        //relationship
        public DonHang DonHang { get; set; }
        public HangHoa HangHoa { get; set; }
    }
}
