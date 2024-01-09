using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace doanapi.Data
{
    public class LicenseFee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int LicenseId { get; set; }
        public string DecisionNumber { get; set; }
        public DateTime? SignDay { get; set; }
        public string LicensingAuthorities { get; set; }
        public double Total { get; set; }
        public string FilePDF { get; set; }
        public DateTime? CreationTime { get; set; }
        public string AccountCreated { get; set; }
        public DateTime? RepairTime { get; set; }
        public string EditAccount { get; set; }
        public bool Deleted { get; set; }
        //noi voi giay phep
        [ForeignKey("LicenseId")]
        public virtual License Licenses { get; set; }
    }
}
