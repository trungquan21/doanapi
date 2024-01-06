using AutoMapper;
using doanapi.Data;
using doanapi.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace doanapi.Service
{
    public class DonViHCService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        public DonViHCService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<List<DistrictDto>> GetAllDistrictAsync()
        {
            var items = await _context.District!
                .Where(l => l.DistrictId>0)
                .ToListAsync();

            var listItems = _mapper.Map<List<DistrictDto>>(items);
            return listItems;
        }

        public async Task<List<CommuneDto>> GetAllCommuneAsync()
        {
            var items = await _context.Commune!
                .Where(l => l.CommuneId >0 )
                .ToListAsync();

            var listItems = _mapper.Map<List<CommuneDto>>(items);
            return listItems;
        }

        public async Task<List<CommuneDto>> GetAllCommuneByDistrictAsync(int DistrictId)
        {
            var items = await _context.Commune!
                .Where(l => l.DistrictId == DistrictId )
                .ToListAsync();
            if (items != null) return new List<CommuneDto>();
            var listItems = _mapper.Map<List<CommuneDto>>(items);
            return listItems;
        }
    }
}
