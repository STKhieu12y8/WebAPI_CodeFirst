using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_CodeFirst_bai1.Serveices;

namespace WebAPI_CodeFirst_bai1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly IHangHoaRepository _hangHoaRepository;
        public HangHoaController(IHangHoaRepository hangHoaRepository)
        {
            _hangHoaRepository = hangHoaRepository;
        }

        [HttpGet]
        public IActionResult GetAllHangHoa(string search, double? from, double? to, int page = 1)
        {
            try
            {
                var result = _hangHoaRepository.GetALl(search, from, to, page);
                return Ok(result);
            }
            catch { return BadRequest(); }
        }
    }
}
