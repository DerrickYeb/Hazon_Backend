namespace Core.Domain.Contracts
{
    public interface IIdentityTenant
    {
        public string TenantKey { get; set; }
    }
}