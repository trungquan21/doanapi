namespace doanapi.Dto
{
    public class LicenseDto
    {
        public int Id { get; set; }
        public int? LicenseTypeId { get; set; }
        public int? OrganizationId { get; set; }
        public int? ConstructionId { get; set; }
        public string LicenseName { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime? SignDay { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Duration { get; set; }
        public string Signer { get; set; }
        public string LicensingAuthorities { get; set; }
        public string FileLicense { get; set; }
        public string FileDocument { get; set; }
        public string FilePermission { get; set; }
        public bool? Revoked { get; set; }
        public bool? Deleted { get; set; }
        public List<LicenseFeeDto> LicenseFee { get; set; }
        public string Validityoflicense
        {
            get
            {
                if (Revoked == true)
                {
                    return "da-bi-thu-hoi";
                }
                else if (ExpirationDate.HasValue)
                {
                    DateTime ngayhethan = ExpirationDate.Value;
                    if (ngayhethan >= DateTime.Today && ngayhethan < DateTime.Today.AddDays(160))
                    {
                        return "sap-het-hieu-luc";
                    }
                    else if (ngayhethan < DateTime.Today)
                    {
                        return "het-hieu-luc";
                    }
                    else if (ngayhethan > DateTime.Today.AddDays(160))
                    {
                        return "con-hieu-luc";
                    }
                }
                return "con-hieu-luc";
            }
        }
        //public List<GP_ThongTinDto>? giayphep_cu { get; set; }
        public LicenseTypeDto LicenseType { get; set; }
        public ConstructionDto Construction { get; set; }
        public OrganizationDto Organization { get; set; }
        public List<LicenseFeeDto> LicenseFees { get; set; }

    }
    public class CountFolowLicensingAuthoritiesDto
    {
        public int Total { get; set; } = 0;
        public int Btnmt { get; set; } = 0;
        public int Ubndt { get; set; } = 0;
    }

    public class CountFolowConstructionTypesDto
    {
        public CountFolowConsTypesData Ktsd_nm { get; set; }
        public CountFolowConsTypesData Ktsd_ndd { get; set; }
        public CountFolowConsTypesData Thamdo_ndd { get; set; }
        public CountFolowConsTypesData Hnk_ndd { get; set; }
        public CountFolowConsTypesData Xathai { get; set; }
    }

    public class CountFolowConsTypesData
    {
        public int Total { get; set; }
        public int Con_hieuluc { get; set; }
        public int Bo_cap { get; set; }
        public int Tinh_cap { get; set; }
    }

    public class LicenseStatisticsDto
    {
        public string[] Color { get; set; }
        public int[] Year { get; set; }
        public List<ApexChartSeriesDto> Series { get; set; }
    }
    public class ApexChartSeriesDto
    {
        public string Name { get; set; }
        public List<int> Data { get; set; }
    }
}
