using doanapi.Data;
using doanapi.Dto;
using doanapi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace doanapi.Controllers.GiayPhep_TienCapQuyen
{
    [Route("api/LicenseFee")]
    [ApiController]
    public class LicenseFeeController : ControllerBase
    {
        private readonly LicenseFeeService _service;

        public LicenseFeeController(LicenseFeeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<LicenseFeeDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("list/{LicensingAuthor}")]
        public async Task<List<LicenseFeeDto>> GetByLicensingAuthorities(string coquan_cp)
        {
            return (await _service.GetByLicensingAuthoritiesAsync(coquan_cp));
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<LicenseFeeDto> GetById(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<ActionResult<LicenseFee>> Save(LicenseFeeDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res > 0)
            {
                return Ok(new { message = "Tiền cấp quyền: Dữ liệu đã được lưu", id = res });
            }
            else
            {
                return BadRequest(new { message = "Tiền cấp quyền: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("delete/{Id}")]
        public async Task<ActionResult<LicenseFee>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Tiền cấp quyền: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Tiền cấp quyền: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
