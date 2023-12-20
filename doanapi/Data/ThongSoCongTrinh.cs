using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace doanapi.Data
{
    public class ThongSoCongTrinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdConstruction { get; set; }
        public string? MiningMode { get; set; }
        public string? MiningMethod { get; set; }
        public string? MiningPurposes { get; set; }
        public string? ExploitedWater { get; set; }
        //nuoc mat
        public int? MachineCapacity { get; set; }
        public double? FlowMax { get; set; }
        public double? FlowTT { get; set; }
        public double? MNC { get; set; }
        public double? MNDL { get; set; }
        public double? MNDBT { get; set; }
        public double? MNCNTL { get; set; }
        //nuocduoidat
        public int? NumberOfExploitation { get; set; }
        public int? PracticeTime { get; set; }
        //xa thai
        public string? WastewaterReceiving { get; set; }
        public string? DischargeLocation { get; set; }

        public DateTime? CreationTime { get; set; }
        public string? AccountCreated { get; set; }
        public DateTime? RepairTime { get; set; }
        public string? EditAccount { get; set; }
        public bool? Deleted { get; set; }

        //tao khoa ngoai voi cong trinh
        [ForeignKey("IdConstruction")]
        public virtual CongTrinh? ConstructionDetail { get; set; }

    }
}
