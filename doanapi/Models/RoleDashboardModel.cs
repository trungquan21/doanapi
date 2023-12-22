namespace doanapi.Models
{
    public class RoleDashboardModel
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public int DashboardId { get; set; }
        public string DashboardName { get; set; }
        public string FileControl { get; set; }
        public bool PermitAccess { get; set; }
    }
}
