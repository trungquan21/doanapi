using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace doanapi.Data
{
    public class District
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public virtual ICollection<Commune> Communes { get; set; }
    }

        public class Commune
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommuneId { get; set; }
        public int DistrictId { get; set; }
        public string CommuneName { get; set; }
        public string AdministrativeLevel { get; set; }

        [ForeignKey(nameof(DistrictId))]
        public virtual  District District { get; set; }
    }
}
