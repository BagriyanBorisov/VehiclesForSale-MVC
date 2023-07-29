using Microsoft.EntityFrameworkCore;
using VehiclesForSale.Core.Contracts.Vehicle;
using VehiclesForSale.Data;
using VehiclesForSale.Web.ViewModels.Vehicle;

namespace VehiclesForSale.Core.Services.Vehicle
{
    public class ExtraService : IExtraService
    {
        private readonly VehiclesDbContext context;


        public ExtraService(VehiclesDbContext context)
        {
            this.context = context;
        }

        public async Task<ExtraFormViewModel> GetAllExtras()
        {
            ExtraFormViewModel viewModel = new ExtraFormViewModel();

            viewModel.SafetyExtras = await context.SafetyExtras.Select(se => new SafetyExtraFormViewModel
            {
                Id = se.Id,
                Name = se.Name,
                IsChecked = false
            }).ToListAsync();

            viewModel.ComfortExtras = await context.ComfortExtras.Select(se => new ComfortExtraFormViewModel
            {
                Id = se.Id,
                Name = se.Name,
                IsChecked = false
            }).ToListAsync();


            viewModel.InteriorExtras = await context.InteriorExtras.Select(se => new InteriorExtraFormViewModel()
            {
                Id = se.Id,
                Name = se.Name,
                IsChecked = false
            }).ToListAsync();

            viewModel.ExteriorExtras = await context.ExteriorExtras.Select(se => new ExteriorExtraFormViewModel()
            {
                Id = se.Id,
                Name = se.Name,
                IsChecked = false
            }).ToListAsync();

            viewModel.OtherExtras = await context.OtherExtras.Select(se => new OtherExtraFormViewModel()
            {
                Id = se.Id,
                Name = se.Name,
                IsChecked = false
            }).ToListAsync();

            return viewModel;
        }
    }
}
