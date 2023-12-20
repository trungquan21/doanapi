namespace doanapi.Dto
{
    public class LicenseDto
    {
        public int Id { get; set; }
        public int? IdCon { get; set; }
        public int? LicenseTypeId { get; set; }
        public int? OrganizationId { get; set; }
        public int? ConstructionId { get; set; }
        public string? LicenseName { get; set; }
        public string? LicenseNumber { get; set; }
        public DateTime? SignDay { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? Duration { get; set; }
        public string? Signer { get; set; }
        public string? LicensingAuthorities { get; set; }
        public string? FileLicense { get; set; }
        public string? FileDocument { get; set; }
        public string? FilePermission { get; set; }
        public bool? Revoked { get; set; }
        public bool? Deleted { get; set; }
    }
}
