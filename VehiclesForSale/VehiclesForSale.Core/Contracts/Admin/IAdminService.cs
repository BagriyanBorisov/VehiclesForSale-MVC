namespace VehiclesForSale.Core.Contracts.Admin
{
    using Web.ViewModels.AdminPanel;
    public interface IAdminService
    {
        public Task<ICollection<AdminPanelUserViewModel>> GetUsersAsync();
    }
}
