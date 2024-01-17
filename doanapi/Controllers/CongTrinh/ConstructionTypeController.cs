using doanapi.Data;
using doanapi.Dto;
using doanapi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace doanapi.Controllers
{
    [Route("api/ConstructionType")]
    [ApiController]
    [Authorize]
    public class ConstructionTypeController : ControllerBase
    {
        private readonly ConstructionTypeService _service;

        public ConstructionTypeController(ConstructionTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<ConstructionTypeDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ConstructionTypeDto> GetById(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<ConstructionType>> Save(ConstructionTypeDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res == true)
            {
                return Ok(new { message = "Loại công trình: Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Loại công trình: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("delete/{Id}")]
        public async Task<ActionResult<ConstructionType>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Loại công trình: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Loại công trình: Lỗi xóa dữ liệu", error = true });
            }
        }

    }
}
