namespace doanapi.Models
{
    public class RoleModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsDefault { get; set; } = false;
        public List<DashboardModel>? Dashboards { get; set; }
    }
}
