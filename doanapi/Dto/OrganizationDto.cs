namespace doanapi.Dto
{
    public class OrganizationDto
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string Location { get; set; }
        public string TaxCode { get; set; }
        public string SDT { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Manager { get; set; }
        public string AuthorizedPerson { get; set; }
        public string LegalRepresentation { get; set; }
        public string Account { get; set; }
        public bool Deleted { get; set; }
    }
}
