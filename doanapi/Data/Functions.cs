﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doanapi.Data
{
    public class Functions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? PermitCode { get; set; }
        public string? PermitName { get; set; }
        public string? Description { get; set; }
    }
}
