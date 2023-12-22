using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace doanapi.Data
{
    public class LicenseType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LicenseTypeName { get; set; }
        public string LicenseTypeCode { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;
        public string AccountCreated { get; set; }
        public DateTime? RepairTime { get; set; }
        public string EditAccount { get; set; }
        public bool? Deleted { get; set; }

        // Navigation property to represent the relationship
        public virtual ICollection<License> License { get; set; }
    }
}
