using doanapi.Data;
using doanapi.Dto;
using doanapi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace doanapi.Controllers
{
    [Route("api/Construction")]
    [ApiController]
    //[Authorize]
    public class ConstructionController : ControllerBase
    {
        private readonly ConstrucionService _service;

        public ConstructionController(ConstrucionService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        //[Authorize(Roles = "chuyenvien")]
        public async Task<List<ConstructionDto>> GetAllData(string? ConstructionName, int? ConstructionTypeId, int? DistrictId, int? CommuneId)
        {
            return await _service.GetAllAsync(ConstructionName, ConstructionTypeId, DistrictId, CommuneId);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ConstructionDto?> GetOneData(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<CongTrinh>> Save(ConstructionDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res > 0)
            {
                return Ok(new { message = "Công trình: Dữ liệu đã được lưu", id = res });
            }
            else
            {
                return BadRequest(new { message = "Công trình: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("delete/{Id}")]
        public async Task<ActionResult<CongTrinh>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Công trình: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Công trình: Lỗi xóa dữ liệu", error = true });
            }
        }
    
    }
}
