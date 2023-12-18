using AutoMapper;
using Microsoft.EntityFrameworkCore;
using doanapi.Data;
using System.Collections.Generic;

namespace doanapi.Models
{
    public class DashboardModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public string? Description { get; set; }
        public bool PermitAccess { get; set; } = false;
        public virtual List<FunctionModel>? Functions { get; set; }
    }
}
