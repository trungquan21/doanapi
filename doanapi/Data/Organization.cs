using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace doanapi.Data
{
    public class Organization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;
        public string AccountCreated { get; set; }
        public DateTime RepairTime { get; set; }
        public string EditAccount { get; set; }
        public bool Deleted { get; set; }

        // Navigation property to represent the relationship
        public virtual ICollection<License> License { get; set; }
    }
}
