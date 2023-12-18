﻿namespace doanapi.Models
{
    public class FunctionModel
    {
        public int Id { get; set; }
        public string? PermitCode { get; set; }
        public string? PermitName { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; } = false;
    }
}
