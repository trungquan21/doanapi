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
        public async Task<List<DistrictDto>> GetAllDistricts()
        {
            return (await _service.GetAllDistrictAsync());
        }

        [HttpGet]
        [Route("commune/list")]
        public async Task<List<CommuneDto>> GetAllCommunes()
        {
            return (await _service.GetAllCommuneAsync());
        }

        [HttpGet]
        [Route("commune/list/{DistrictId}")]
        public async Task<List<CommuneDto>> GetAllCommunesByDistrict(int DistrictId)
        {
            return (await _service.GetAllCommuneByDistrictAsync(DistrictId));
        } 

  
    }
}
