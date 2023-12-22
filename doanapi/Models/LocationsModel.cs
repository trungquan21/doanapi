namespace doanapi.Models
{
    public class LocationsModel
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string CityId { get; set; }
        public string DistrictName { get; set; }
        public string DistrictId { get; set; }
        public string CommuneName { get; set; }
        public string CommuneId { get; set; }
        public string CommuneLevel { get; set; }
    }

    public class DistrictModel
    {
        public string DistrictName { get; set; }
        public string DistrictId { get; set; }
    }
    public class CommuneModel
    {
        public string DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string CommuneId { get; set; }
        public string CommuneName { get; set; }
        public string CommuneLevel { get; set; }
    }
}
