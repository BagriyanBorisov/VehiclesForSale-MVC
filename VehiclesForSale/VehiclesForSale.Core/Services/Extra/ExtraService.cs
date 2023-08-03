namespace VehiclesForSale.Core.Services.Extra
{
    using Microsoft.EntityFrameworkCore;
    using Data.Models.VehicleModel.Extras;
    using Contracts.Extra;
    using Data;
    using Web.ViewModels.Vehicle;

    public class ExtraService : IExtraService
    {
        private readonly VehiclesDbContext context;

        public ExtraService(VehiclesDbContext context)
        {
            this.context = context;
        }

        public async Task AddExtraAsync(ExtraFormViewModel extraVm, string userId, string extraId)
        {
            var vehicle = await context.Vehicles
                .Where(v => v.ExtraId.ToString() == extraId && v.OwnerId == userId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (vehicle == null)
            {
                throw new NullReferenceException("This vehicle does not exist or you are not the owner!");
            }

            var extraDb = await context.Extras
                .Where(e => e.Id.ToString() == extraId)
                .Include(e => e.ExteriorExtras)
                .Include(e => e.InteriorExtras)
                .Include(e => e.ComfortExtras)
                .Include(e => e.SafetyExtras)
                .Include(e => e.OtherExtras)
                .FirstOrDefaultAsync();

            if (extraDb == null)
            {
                throw new NullReferenceException("Extra not found.");
            }


            var safetyExtras = new List<SafetyExtra>();
            var comfortExtras = new List<ComfortExtra>();
            var exteriorExtras = new List<ExteriorExtra>();
            var interiorExtras = new List<InteriorExtra>();
            var otherExtras = new List<OtherExtra>();
            foreach (var extra in extraVm.SafetyExtrasChecked)
            {
                SafetyExtra safeExtra = new SafetyExtra
                {
                    ExtraId = extraDb.Id,
                    Name = extra
                };
                safetyExtras.Add(safeExtra);
            }

            foreach (var extra in extraVm.ComfortExtrasChecked)
            {
                ComfortExtra comfortExtra = new ComfortExtra
                {
                    ExtraId = extraDb.Id,
                    Name = extra
                };
                comfortExtras.Add(comfortExtra);
            }

            foreach (var extra in extraVm.ExteriorExtrasChecked)
            {
                ExteriorExtra exteriorExtra = new ExteriorExtra
                {
                    ExtraId = extraDb.Id,
                    Name = extra
                };
                exteriorExtras.Add(exteriorExtra);
            }

            foreach (var extra in extraVm.InteriorExtrasChecked)
            {
                InteriorExtra interiorExtra = new InteriorExtra
                {
                    ExtraId = extraDb.Id,
                    Name = extra
                };
                interiorExtras.Add(interiorExtra);
            }

            foreach (var extra in extraVm.OtherExtrasChecked)
            {
                OtherExtra otherExtra = new OtherExtra
                {
                    ExtraId = extraDb.Id,
                    Name = extra
                };
                otherExtras.Add(otherExtra);
            }

            await context.SafetyExtras.AddRangeAsync(safetyExtras);
            await context.ComfortExtras.AddRangeAsync(comfortExtras);
            await context.ExteriorExtras.AddRangeAsync(exteriorExtras);
            await context.InteriorExtras.AddRangeAsync(interiorExtras);
            await context.OtherExtras.AddRangeAsync(otherExtras);

            context.Extras.Update(extraDb);
            await context.SaveChangesAsync();
        }

        public async Task<ExtraFormViewModel> GetAddExtraAsync(string id)
        {
            var vehicle = await context.Vehicles.Where(v => v.Id.ToString() == id).FirstOrDefaultAsync();
            if (vehicle == null)
            {
                throw new NullReferenceException("This vehicle does not exist");
            }

            vehicle.Extra = new Extra();
            var viewModel = await GetAllExtras(vehicle.ExtraId);
            return viewModel;
        }

        private async Task<ExtraFormViewModel> GetAllExtras(int extraId)
        {
            ExtraFormViewModel viewModel = new ExtraFormViewModel();
            viewModel.ExtraId = extraId;
            viewModel.SafetyExtras = await context.SafetyExtras
                .Where(sf => sf.ExtraId == null)
                .Select(se => new SafetyExtraFormViewModel
                {
                    Id = se.Id,
                    Name = se.Name,
                    IsChecked = false
                }).ToListAsync();

            viewModel.ComfortExtras = await context.ComfortExtras
                .Where(sf => sf.ExtraId == null)
                .Select(se => new ComfortExtraFormViewModel
                {
                    Id = se.Id,
                    Name = se.Name,
                    IsChecked = false
                }).ToListAsync();


            viewModel.InteriorExtras = await context.InteriorExtras
                .Where(sf => sf.ExtraId == null)
                .Select(se => new InteriorExtraFormViewModel()
                {
                    Id = se.Id,
                    Name = se.Name,
                    IsChecked = false
                }).ToListAsync();

            viewModel.ExteriorExtras = await context.ExteriorExtras
                .Where(sf => sf.ExtraId == null)
                .Select(se => new ExteriorExtraFormViewModel()
                {
                    Id = se.Id,
                    Name = se.Name,
                    IsChecked = false
                }).ToListAsync();

            viewModel.OtherExtras = await context.OtherExtras
                .Where(sf => sf.ExtraId == null)
                .Select(se => new OtherExtraFormViewModel()
                {
                    Id = se.Id,
                    Name = se.Name,
                    IsChecked = false
                }).ToListAsync();

            return viewModel;
        }
    }
}