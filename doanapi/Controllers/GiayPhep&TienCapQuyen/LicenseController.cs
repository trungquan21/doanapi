using doanapi.Data;
using doanapi.Dto;
using doanapi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace doanapi.Controllers.GiayPhep_TienCapQuyen
{
    [Route("api/license")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly LicenseService _service;

        public LicenseController(LicenseService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<LicenseDto>> GetAllData(string LicenseNumber, int LicenseTypeId, int OrganizationId, string Validityoflicense)
        {
            return await _service.GetAllAsync( LicenseNumber,  LicenseTypeId,  OrganizationId,Validityoflicense);
        }

        [HttpGet]
        [Route("countedbylicensingauthority")]
        public async Task<CountFolowLicensingAuthoritiesDto> CountFolowLicensingAuthorities()
        {
            return await _service.CountFolowLicensingAuthoritiesAsync();
        }

        [HttpGet]
        [Route("countedbytypeofconstruction")]
        public async Task<CountFolowConstructionTypesDto> CountFolowConstructionTypes()
        {
            return await _service.CountFolowConstructionTypesAsync();
        }

        [HttpGet]
        [Route("statistical")]
        public async Task<LicenseStatisticsDto> LicenseStatistics(int? tu_nam, int? den_nam)
        {
            return await _service.LicenseStatisticsAsync(tu_nam,  den_nam);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<LicenseDto> GetOneData(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<License>> SaveConstruction(LicenseDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res > 0)
            {
                return Ok(new { message = "Giấy phép: Dữ liệu đã được lưu", id = res });
            }
            else
            {
                return BadRequest(new { message = "Giấy phép: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("delete/{Id}")]
        public async Task<ActionResult<License>> DeleteConstruction(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Giấy phép: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Giấy phép: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}

