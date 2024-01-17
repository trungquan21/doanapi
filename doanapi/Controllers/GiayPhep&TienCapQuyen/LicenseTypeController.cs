using doanapi.Data;
using doanapi.Dto;
using doanapi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace doanapi.Controllers.GiayPhep_TienCapQuyen
{
    [Route("api/licenseType")]
    [ApiController]
    [Authorize]
    public class LicenseTypeController : ControllerBase
    {
        private readonly LicenseTypeService _service;

        public LicenseTypeController(LicenseTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<LicenseTypeDto>> GetAllGP_Loai()
        {
            return (await _service.GetAllAsync());
        }

        //[HttpGet]
        //[Route("{Id}")]
        //public async Task<LicenseTypeDto?> GetGP_LoaiById(int Id)
        //{
        //    return await _service.GetGP_LoaiByIdAsync(Id);
        //}

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<LicenseType>> SaveGP_Loai(LicenseTypeDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res == true)
            {
                return Ok(new { message = "Loại giấy phép: Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Loại giấy phép: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("delete/{Id}")]
        public async Task<ActionResult<LicenseType>> DeleteLicenseType(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Loại giấy phép: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Loại giấy phép: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
