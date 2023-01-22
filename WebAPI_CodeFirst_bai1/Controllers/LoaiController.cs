using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebAPI_CodeFirst_bai1.Data;
using WebAPI_CodeFirst_bai1.Models;

namespace WebAPI_CodeFirst_bai1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoaiController : ControllerBase
    {
        private readonly HangHoaDBContext _context;

        public LoaiController(HangHoaDBContext context)
        {
            _context = context;
        }

        [HttpGet] 
        public IActionResult GetAll ()
        {
            var dsLoai = _context.Loai.ToList(  );
            if (dsLoai.Count == 0)
            {
                return NotFound();
            }

            return Ok(dsLoai);  
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = _context.Loai.SingleOrDefault(l => l.Id == id);

            if (loai == null)
            {
                return NotFound();
            }

            return Ok(loai);
        }

        [HttpPost]
        public IActionResult Create (LoaiViewModel loaiViewModel)
        {
            try
            {
                var loai = new Loai { TenLoai = loaiViewModel.TenLoai};
                _context.Loai.Add(loai);
                _context.SaveChanges();
                return StatusCode(201, loai);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult EditById(int id, LoaiViewModel loaiVM)   
        {
            var loai = _context.Loai.SingleOrDefault(l => l.Id == id);

            if (loai == null)
            {
                return NotFound();
            }

            loai.TenLoai= loaiVM.TenLoai;
            _context.SaveChanges();
            return StatusCode(204, loai);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var loai = _context.Loai.SingleOrDefault(l => l.Id == id);

            if (loai == null)
            {
                return NotFound();
            }

            _context.Loai.Remove(loai);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
