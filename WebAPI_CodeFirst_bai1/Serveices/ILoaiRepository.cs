using System.Collections.Generic;
using WebAPI_CodeFirst_bai1.Models;

namespace WebAPI_CodeFirst_bai1.Serveices
{
    public interface ILoaiRepository
    {
        List<Loai> GetAll();
        Loai GetById(int id);
        Loai Add(LoaiViewModel loai);
        void Update(int id, Loai loai);
        void Delete(int id);
    }
}
