using doanapi.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace doanapi.Dto
{
    public class ConstructionDto
    {
        public int Id { get; set; }
        public int? ConstructionTypeId { get; set; }
        public int? DistrictId { get; set; }
        public int? CommuneId { get; set; }
        public string? ConstructionName { get; set; }
        public double? StartDate { get; set; }
        public string? ConstructionLocation { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public bool? Deleted { get; set; }
        public ConstructionTypeDto? ConstructionType { get; set; }
        public ConstructionDetailsDto? ConstructionDetails { get; set; }
        public DonViHCDto? DonViHanhChinh { get; set; }

    }
}
