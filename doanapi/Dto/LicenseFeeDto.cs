namespace doanapi.Dto
{
    public class LicenseFeeDto
    {
        public int Id { get; set; }
        public int LicenseId { get; set; }
        public string DecisionNumber { get; set; }
        public DateTime? SignDay { get; set; }
        public string LicensingAuthorities { get; set; }
        public double Total { get; set; }
        public string FilePDF { get; set; }
        public bool Deleted { get; set; }
    }
}
