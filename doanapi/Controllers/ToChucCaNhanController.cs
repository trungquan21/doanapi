using doanapi.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using doanapi.Data;
using doanapi.Service;

namespace doanapi.Controllers
{
    [Route("api/organization")]
    [ApiController]
    public class ToChucCaNhanController : ControllerBase
    {

        private readonly ToChucCaNhanService _service;

        public ToChucCaNhanController(ToChucCaNhanService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<OrganizationDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<OrganizationDto> GetById(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<Organization>> Save(OrganizationDto moddel)
        {
            var res = await _service.SaveAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Doanh nghiệp: Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Doanh nghiệp: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("delete/{Id}")]
        public async Task<ActionResult<Organization>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Doanh nghiệp: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Doanh nghiệp: Lỗi xóa dữ liệu" });
            }
        }
    }
}
