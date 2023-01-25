using System.Collections.Generic;
using WebAPI_CodeFirst_bai1.Models;

namespace WebAPI_CodeFirst_bai1.Serveices
{
    public interface IHangHoaRepository
    {
        List<HangHoaVM> GetALl(string search, double? from, double? to, int page = 1);
    }
}   
