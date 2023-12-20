using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace doanapi.Data
{
    public class LoaiCongTrinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdParent { get; set; }
        public string? TypeName { get; set; }
        public string? ConstructionTypeCode { get; set; }
        public DateTime? CreationTime { get; set; }
        public string? AccountCreated { get; set; }
        public DateTime? RepairTime { get; set; }
        public string? EditAccount { get; set; }
        public bool? Deleted { get; set; }

        // Navigation property to represent the relationship
        public virtual ICollection<CongTrinh>? CongTrinh { get; set; }
    }
}
