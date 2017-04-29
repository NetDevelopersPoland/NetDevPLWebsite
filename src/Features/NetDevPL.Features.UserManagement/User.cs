using System;

namespace NetDevPL.Features.UserManagement
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Provider { get; set; }
        public string ProviderExternalId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}