using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI_CodeFirst_bai1.Data;
using WebAPI_CodeFirst_bai1.Models;

namespace WebAPI_CodeFirst_bai1.Serveices
{
    public class HangHoaRepository : IHangHoaRepository
    {
        private readonly HangHoaDBContext _context;
        public static int PAGE_SIZE { get; set; } = 5;

        public HangHoaRepository (HangHoaDBContext context)
        {
            _context = context;
        }

        public List<HangHoaVM> GetALl(string search, double? from, double? to, int page = 1)
        {
            var allProduct = _context.HangHoa.Include(hh => hh.loai) .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
               allProduct.Where(hh => hh.TenHangHoa.Contains(search));
            }

            if (from.HasValue) {
                allProduct = allProduct.Where(hh => hh.DonGia >= from);
            }

            if (to.HasValue)
            {
                allProduct = allProduct.Where(hh => hh.DonGia <= to);
            }

            //Page
           /* PAGE_SIZE = pageSize??1;
            allProduct = allProduct.Skip((PAGE_SIZE - 1) * PAGE_SIZE).Take(PAGE_SIZE);


            var result = allProduct.Select(hh => new HangHoaVM
            {
                id = hh.Id,
                MaLoaiId = hh.MaLoaiId,
                TenHangHoa = hh.TenHangHoa,
                DonGia = hh.DonGia,
                GiamGia = hh.GiamGia,
                MoTa = hh.MoTa,
            });

            return result.ToList();
           */

            var result = PaginatedList<HangHoa>.Create(allProduct, page, PAGE_SIZE);

            return result.Select(hh => new HangHoaVM
            {
                id = hh.Id,
                TenHangHoa = hh.TenHangHoa,
                MaLoaiId = hh.MaLoaiId,
                DonGia = hh.DonGia,
                GiamGia = hh.DonGia,
                MoTa = hh.MoTa
            }).ToList();
        }
    }
}
