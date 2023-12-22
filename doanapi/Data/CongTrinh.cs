using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using doanapi.Dto;

namespace doanapi.Data
{
    public class CongTrinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ConstructionTypeId { get; set; }
        public int DVHCId { get; set; }
        public string ConstructionName { get; set; }
        public int StartDate { get; set; }
        public string ConstructionLocation { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;
        public string AccountCreated { get; set; }
        public DateTime RepairTime { get; set; } 
        public string EditAccount { get; set; }
        public bool Deleted { get; set; }

        //tao khoa ngoai voi loai cong trinh
        [ForeignKey(nameof(ConstructionTypeId))]
        public virtual LoaiCongTrinh ConstructionType { get; set; }
       
        [ForeignKey(nameof(DVHCId))]
        public virtual DonViHC DonViHC { get; set; }
        public virtual ICollection<License> License { get; set; }
        public virtual ThongSoCongTrinh ConstructionDetails { get; set; }

    }
}
