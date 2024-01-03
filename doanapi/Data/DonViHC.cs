using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace doanapi.Data
{
    public class DonViHC
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? CommuneId { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictName { get; set; }
        public string CommuneName { get; set; }
        public string AdministrativeLevel { get; set; }
        public DateTime CreationTime { get; set; }
        public string AccountCreated { get; set; }
        public DateTime RepairTime { get; set; }
        public string EditAccount { get; set; }
        public bool Deleted { get; set; }
    }
}
