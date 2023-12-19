﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using doanapi.Dto;

namespace doanapi.Data
{
    public class CongTrinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? ConstructionId { get; set; }
        public int? DistrictId { get; set; }
        public int? CommuneId { get; set; }
        public string? ConstructionName { get; set; }
        public double? StartDate { get; set; }
        public string? ConstructionLocation { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public DateTime? CreationTime { get; set; }
        public string? AccountCreated { get; set; }
        public DateTime? RepairTime { get; set; }
        public string? EditAccount { get; set; }
        public bool? Deleted { get; set; }


        [ForeignKey("ConstructionId")]
        public virtual LoaiCongTrinh? TypeOfConstruction { get; set; }
        public virtual ThongSoCongTrinh? ConstructionDetails { get; set; }

    }
}
