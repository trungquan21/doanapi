using doanapi.Dto;
using doanapi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace doanapi.Controllers
{
    [Route("api/ ConstructionDetails")]
    [ApiController]
    //[Authorize]
    public class ConstructionDetailsController : ControllerBase
    {
        private readonly ConstructionDetailsService _service;

        public ConstructionDetailsController(ConstructionDetailsService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult> Save(ConstructionDetailsDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res)
            {
                return Ok(new { message = "Thông số công trình: Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Thông số công trình: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("delete/{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Thông số công trình: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Thông số công trình: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
