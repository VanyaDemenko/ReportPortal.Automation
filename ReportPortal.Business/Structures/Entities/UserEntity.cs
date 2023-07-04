using ReportPortal.Business.Interfaces;

namespace ReportPortal.Business.Structures.Entities
{
    public class UserEntity : IBusinessEntity
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
    }
}
