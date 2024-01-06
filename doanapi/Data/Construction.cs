using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using doanapi.Dto;
using System.ComponentModel.Design;

namespace doanapi.Data
{
    public class Construction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? ConstructionTypeId { get; set; }
        public int? DistrictId { get; set; }
        public int? CommuneId { get; set; }
        public string ConstructionName { get; set; }
        public string ConstructionLocation { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public DateTime? CreationTime { get; set; }
        public string AccountCreated { get; set; }
        public DateTime? RepairTime { get; set; } 
        public string EditAccount { get; set; }
        public bool? Deleted { get; set; }

        //tao khoa ngoai voi loai cong trinh
        [ForeignKey(nameof(ConstructionTypeId))]
        public virtual ConstructionType ConstructionType { get; set; }

        [ForeignKey(nameof(DistrictId))]
        public virtual District District { get; set; }

        [ForeignKey(nameof(CommuneId))]
        public virtual Commune Commune { get; set; }

        public virtual ICollection<License> License { get; set; }
        public virtual ConstructionDetail ConstructionDetails { get; set; }

    }
}
