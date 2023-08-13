namespace VehiclesForSale.Core.Services.Admin
{
    using Microsoft.EntityFrameworkCore;

    using VehiclesForSale.Core.Contracts.Admin;
    using Data;
    using Web.ViewModels.AdminPanel;
    public class AdminService : IAdminService
    {
        private readonly VehiclesDbContext context;

        public AdminService(VehiclesDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<AdminPanelUserViewModel>> GetUsersAsync()
        {
            return await context.Users.Select(u => new AdminPanelUserViewModel()
            {
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                RegisteredSince = u.RegistrationDate.ToShortDateString()
            }).ToListAsync();
        }
    }
}
