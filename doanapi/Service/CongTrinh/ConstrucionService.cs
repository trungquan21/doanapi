﻿using AutoMapper;
using doanapi.Data;
using doanapi.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace doanapi.Service
{
    public class ConstrucionService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        // Constructor to initialize the service with required dependencies
        public ConstrucionService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        // Method to retrieve a list of ConstructionDetails entities based on specified filters
        public async Task<List<ConstructionDto>> GetAllAsync(string ConstructionName, int? ConstructionTypeId, int? DistrictId, int? CommuneId)
        {
            var query = _context.Construction!
                .Where(ct => ct.Deleted == false)
                .Include(ct => ct.ConstructionType)
                .Include(ct => ct.ConstructionDetails)
                 .Include(ct => ct.Commune)
                 .Include(ct => ct.District)
                 .Include(ct => ct.License)
                .OrderBy(x => x.ConstructionTypeId)
                .AsQueryable();

            // Apply filters based on input parameters
            if (!string.IsNullOrEmpty(ConstructionName))
            {
                query = query.Where(ct => ct.ConstructionName!.Contains(ConstructionName));
            }

            if (ConstructionTypeId > 0)
            {
                query = query.Where(ct => ConstructionTypeId == 1 || ConstructionTypeId == 2 || ConstructionTypeId == 3 ? ct.ConstructionType!.IdParent == ConstructionTypeId : ct.ConstructionType!.Id == ConstructionTypeId);
            }
            if (CommuneId > 0)
            {
                query = query.Where(ct => ct.Commune.CommuneId == CommuneId);
            }

            if (DistrictId > 0)
            {
                query = query.Where(ct => ct.District.DistrictId == DistrictId);
            }

            var congtrinh = await query.ToListAsync();

            // Map the result to DTOs
            var congTrinhDtos = _mapper.Map<List<ConstructionDto>>(congtrinh);

            // Further processing on DTOs
            foreach (var dto in congTrinhDtos)
            {
                if (dto.CommuneId != 0)
                {
                    dto.Communes = _mapper.Map<CommuneDto>(await _context.Commune!
                        .FirstOrDefaultAsync(dv => dv.CommuneId == dto.CommuneId));
                }

                dto.Licenses = _mapper.Map<List<LicenseDto>>(dto.Licenses!.Where(x => x.Deleted == false));
            }

            // Return the list of DTOs
            return congTrinhDtos;
        }
        // Method to check if a construction name is unique
        public async Task<bool> IsConstructionNameUniqueAsync(string constructionName)
        {
            return await _context.Construction!
                .AnyAsync(ct => ct.Deleted == false && ct.ConstructionName == constructionName);
        }

        // Method to retrieve a single Construction entity by Id
        public async Task<ConstructionDto> GetByIdAsync(int Id)
        {
            var query = _context.Construction!
                .Where(ct => ct.Deleted == false && ct.Id == Id)
                .Include(ct => ct.ConstructionTypeId)
                .Include(ct => ct.ConstructionDetails)
                .Include(ct => ct.Users)
                //.Include(ct => ct.GiayPhep!).ThenInclude(gp => gp.ToChuc_CaNhan)
                //.Include(ct => ct.GiayPhep!).ThenInclude(gp => gp.GP_TCQ)
                .OrderBy(x => x.ConstructionTypeId)
                .AsQueryable();
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            if (currentUser != null)
            {
                if(await _userManager.IsInRoleAsync(currentUser, "congtrinh"))
                {
                    query = query.Where(ct => ct.Users.UserName.ToLower() == currentUser.UserName.ToLower());
                }
            }

            var congtrinh = query.FirstOrDefault();

            // Map the result to a DTO
            var congTrinhDto = _mapper.Map<ConstructionDto>(query);


            // Return the DTO
            return congTrinhDto;
        }

        // Method to save or update a ConstructionDetails entity
        public async Task<int> SaveAsync(ConstructionDto dto)
        {
            int id = 0;
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            Construction item = null; // Declare item variable

            // Retrieve an existing item based on Id or if dto.Id is 0
            var existingItem = await _context.Construction!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.Deleted == false);

            if (existingItem == null || dto.Id == 0)
            {
                // If the item doesn't exist or dto.Id is 0, create a new item
                item = _mapper.Map<Construction>(dto);
                item.Deleted = false;
                item.CreationTime = DateTime.Now;
                item.AccountCreated = currentUser != null ? currentUser.UserName : null;
                _context.Construction!.Add(item);
            }
            else
            {
                // If the item exists, update it with values from the dto
                item = existingItem;
                _mapper.Map(dto, item);
                item.Deleted = false;
                item.RepairTime = DateTime.Now;
                item.EditAccount = currentUser != null ? currentUser.UserName : null;
                _context.Construction!.Update(item);
            }

            // Save changes to the database
            var res = await _context.SaveChangesAsync();

            // Simplified assignment of id based on the result of SaveChanges
            id = (int)(res > 0 ? item.Id : 0);

            // Return the id
            return id;
        }

        // Method to delete a ConstructionDetails entity
        public async Task<bool> DeleteAsync(int Id)
        {
            // Retrieve an existing item based on Id
            var existingItem = await _context.Construction!.FirstOrDefaultAsync(d => d.Id == Id && d.Deleted == false);
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (existingItem == null) { return false; } // If the item doesn't exist, return false

            existingItem!.Deleted = true; // Mark the item as deleted
            existingItem.RepairTime = DateTime.Now;
            existingItem.EditAccount = currentUser != null ? currentUser.UserName : null;
            _context.Construction!.Update(existingItem);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful deletion
            return true;
        }
    }
}
