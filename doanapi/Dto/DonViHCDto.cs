namespace doanapi.Dto
{
    public class DonViHCDto
    {
        public int Id { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? CommuneId { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictName { get; set; }
        public string CommuneName { get; set; }
        public string AdministrativeLevel { get; set; }
        public bool? Deleted { get; set; }
    }
    public class HuyenDto
    {
        public string DistrictId { get; set; }
        public string DistrictName { get; set; }
    }
    public class XaDto
    {
        public string DistrictId { get; set; }
        public string CommuneId { get; set; }
        public string DistrictName { get; set; }
        public string CommuneName { get; set; }
        public string AdministrativeLevel { get; set; }
    }
}
