using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_CodeFirst_bai1.Models;
using WebAPI_CodeFirst_bai1.Serveices;

namespace WebAPI_CodeFirst_bai1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly ILoaiRepository _loaiRepository;

        public LoaisController(ILoaiRepository loaiRepository)
        {
            _loaiRepository = loaiRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_loaiRepository.GetAll());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetLoaiById(int id)
        {
            try
            {
                return Ok(_loaiRepository.GetById(id));
            }
            catch
            {
                return StatusCode(404);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Loai loai)
        {
            try
            {
                _loaiRepository.Update(id, loai);
                return NoContent();
            }
            catch { return StatusCode(500); }
        }

        [HttpPost]
        public IActionResult Create(LoaiViewModel loaivm)
        {
            try
            {
                return Ok(_loaiRepository.Add(loaivm));
            }
            catch { return StatusCode(500); }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _loaiRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }


        }
    }
}