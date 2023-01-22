using System;
using System.Collections.Generic;

namespace WebAPI_CodeFirst_bai1.Models
{
    public enum TinhTrangDonHang
    {
        New = 0, Payment = 1, Complete = 2, Cancel = -1
    }
    public class DonHang
    {
        public int Id { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime? NgaGiao { get; set; }
        public TinhTrangDonHang TinhTrangDonDatHang { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChiGiaoHang { get; set; }

        public ICollection<DonHangChiTiet> DonHangChiTiet { get; set; }
        public DonHang ()
        {
            DonHangChiTiet = new List<DonHangChiTiet> ();
        }

    }
}
