using doanapi.Data;

namespace doanapi.Dto
{
    public class DistrictDto
    {
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public List<CommuneDto> Communes { get; set; }
    }
    public class CommuneDto
    {
        public int? CommuneId { get; set; }
        public string CommuneName { get; set; }
        public string AdministrativeLevel { get; set; }
    }
}
