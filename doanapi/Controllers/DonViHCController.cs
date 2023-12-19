using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using doanapi.Data;
using doanapi.Dto;
using doanapi.Service;

namespace doanapi.Controllers
{
    [Route("api/administrative")]
    [ApiController]
    //[Authorize]
    public class DonViHCController : ControllerBase
    {
        private readonly DonViHCService _service;

        public DonViHCController(DonViHCService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("district/list")]
        public async Task<List<HuyenDto>> GetAllDistricts()
        {
            return (await _service.GetAllDistrictAsync());
        }

        [HttpGet]
        [Route("commune/list")]
        public async Task<List<XaDto>> GetAllCommunes()
        {
            return (await _service.GetAllCommuneAsync());
        }

        [HttpGet]
        [Route("commune/list/{DistrictId}")]
        public async Task<List<XaDto>> GetAllCommunesByDistrict(int DistrictId)
        {
            return (await _service.GetAllCommuneByDistrictAsync(DistrictId));
        } 

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<DonViHC>> Save(DonViHCDto moddel)
        {
            var res = await _service.SaveAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("delete/{Id}")]
        public async Task<ActionResult<DonViHC>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
