using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI_CodeFirst_bai1.Data;
using WebAPI_CodeFirst_bai1.Models;

namespace WebAPI_CodeFirst_bai1.Serveices
{
    public class LoaiResository : ILoaiRepository
    {
        private readonly HangHoaDBContext _context;

        public LoaiResository (HangHoaDBContext context)
        {
            _context = context;
        }

        public Loai Add(LoaiViewModel loai)
        {
            try
            {
                var _loai = new Loai { TenLoai = loai.TenLoai };
                _context.Add(_loai);
                _context.SaveChanges();
                return _loai;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private Loai BadRequest(object message)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var loai = _context.Loai.ToList().SingleOrDefault(l => l.Id == id);
            _context.Remove(loai);
        }

        public List<Loai> GetAll()
        {
            var ds = _context.Loai.ToList();
            return ds;
        }

        public Loai GetById(int id)
        {
            var loai = _context.Loai.ToList().SingleOrDefault(l => l.Id == id);
            return loai;
        }       

        public void Update(int id, Loai loai)
        {
            var _loai = _context.Loai.ToList().SingleOrDefault(l => l.Id == id);
            _loai.TenLoai= loai.TenLoai;
           _context.SaveChanges();
        }
    }
}
