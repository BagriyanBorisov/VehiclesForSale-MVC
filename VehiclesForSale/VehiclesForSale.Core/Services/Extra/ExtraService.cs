namespace VehiclesForSale.Core.Services.Extra
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    using Data;
    using Contracts.Extra;
    using Data.Models.VehicleModel.Extras;
    using Web.ViewModels.Vehicle;

    public class ExtraService : IExtraService
    {
        private readonly VehiclesDbContext context;

        public ExtraService(VehiclesDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CheckOwner(string vehicleId, string userId)
        {
            return await context.Vehicles
                .Where(v => v.Id.ToString() == vehicleId && v.OwnerId == userId).AnyAsync();
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
        public async Task<ExtraFormViewModel> GetEditExtraAsync(string id)
        {
            var vehicle = await context.Vehicles.Where(v => v.Id.ToString() == id).FirstOrDefaultAsync();
            if (vehicle == null)
            {
                throw new NullReferenceException("This vehicle does not exist");
            }
            var viewModel = await GetAllExtrasForEdit(vehicle.ExtraId);
            return viewModel;
        }




        private async Task<ExtraFormViewModel> GetAllExtrasForEdit(int extraId)
        {
            ExtraFormViewModel viewModel = new ExtraFormViewModel();

            viewModel.ExtraId = extraId;
            viewModel.ExteriorExtras = await GetExteriorExtrasForEdit(extraId);
            viewModel.InteriorExtras = await GetInteriorExtrasForEdit(extraId);
            viewModel.OtherExtras = await GetOtherExtrasForEdit(extraId);
            viewModel.SafetyExtras = await GetSafetyExtrasForEdit(extraId);
            viewModel.ComfortExtras = await GetComfortExtrasForEdit(extraId);

            return viewModel;
        }

        private async Task<List<ExteriorExtraFormViewModel>> GetExteriorExtrasForEdit(int? extraId)
        {
            var matchedExtras = await context.ExteriorExtras
                .Where(e => e.ExtraId == extraId)
                .ToListAsync();

            var unmatchedExtras = await context.ExteriorExtras
                .Where(e => e.ExtraId != extraId && e.ExtraId == null)
                .ToListAsync();

            var matchedViewModels = matchedExtras.Select(e => MapExteriorExtraToViewModel(e, extraId)).ToList();
            var unmatchedViewModels = unmatchedExtras.Select(e => MapExteriorExtraToViewModel(e, extraId)).ToList();

            return matchedViewModels
            .Union(unmatchedViewModels, new ExtraFormViewModelComparer<ExteriorExtraFormViewModel>())
            .ToList();
        }

        private async Task<List<InteriorExtraFormViewModel>> GetInteriorExtrasForEdit(int? extraId)
        {
            var matchedExtras = await context.InteriorExtras
                .Where(e => e.ExtraId == extraId)
                .ToListAsync();

            var unmatchedExtras = await context.InteriorExtras
                .Where(e => e.ExtraId != extraId && e.ExtraId == null)
                .ToListAsync();

            var matchedViewModels = matchedExtras.Select(e => MapInteriorExtraToViewModel(e, extraId)).ToList();
            var unmatchedViewModels = unmatchedExtras.Select(e => MapInteriorExtraToViewModel(e, extraId)).ToList();

            return matchedViewModels
                .Union(unmatchedViewModels, new ExtraFormViewModelComparer<InteriorExtraFormViewModel>())
                .ToList();
        }
        private async Task<List<OtherExtraFormViewModel>> GetOtherExtrasForEdit(int? extraId)
        {
            var matchedExtras = await context.OtherExtras
                .Where(e => e.ExtraId == extraId)
                .ToListAsync();

            var unmatchedExtras = await context.OtherExtras
                .Where(e => e.ExtraId != extraId && e.ExtraId == null)
                .ToListAsync();

            var matchedViewModels = matchedExtras.Select(e => MapOtherExtraToViewModel(e, extraId)).ToList();
            var unmatchedViewModels = unmatchedExtras.Select(e => MapOtherExtraToViewModel(e, extraId)).ToList();

            return matchedViewModels
                .Union(unmatchedViewModels, new ExtraFormViewModelComparer<OtherExtraFormViewModel>())
                .ToList();
        }

        private async Task<List<SafetyExtraFormViewModel>> GetSafetyExtrasForEdit(int? extraId)
        {
            var matchedExtras = await context.SafetyExtras
                .Where(e => e.ExtraId == extraId)
                .ToListAsync();

            var unmatchedExtras = await context.SafetyExtras
                .Where(e => e.ExtraId != extraId && e.ExtraId == null)
                .ToListAsync();

            var matchedViewModels = matchedExtras.Select(e => MapSafetyExtraToViewModel(e, extraId)).ToList();
            var unmatchedViewModels = unmatchedExtras.Select(e => MapSafetyExtraToViewModel(e, extraId)).ToList();

            return matchedViewModels
                .Union(unmatchedViewModels, new ExtraFormViewModelComparer<SafetyExtraFormViewModel>())
                .ToList();
        }

        private async Task<List<ComfortExtraFormViewModel>> GetComfortExtrasForEdit(int? extraId)
        {
            var matchedExtras = await context.ComfortExtras
                .Where(e => e.ExtraId == extraId)
                .ToListAsync();

            var unmatchedExtras = await context.ComfortExtras
                .Where(e => e.ExtraId != extraId && e.ExtraId == null)
                .ToListAsync();

            var matchedViewModels = matchedExtras.Select(e => MapComfortExtraToViewModel(e, extraId)).ToList();
            var unmatchedViewModels = unmatchedExtras.Select(e => MapComfortExtraToViewModel(e, extraId)).ToList();

            return matchedViewModels
                .Union(unmatchedViewModels, new ExtraFormViewModelComparer<ComfortExtraFormViewModel>())
                .ToList();
        }


        private OtherExtraFormViewModel MapOtherExtraToViewModel(OtherExtra model, int? extraId)
        {
            return new OtherExtraFormViewModel
            {
                Id = model.Id,
                Name = model.Name,
                IsChecked = model.ExtraId == extraId
            };
        }

        private SafetyExtraFormViewModel MapSafetyExtraToViewModel(SafetyExtra model, int? extraId)
        {
            return new SafetyExtraFormViewModel
            {
                Id = model.Id,
                Name = model.Name,
                IsChecked = model.ExtraId == extraId
            };
        }

        private ComfortExtraFormViewModel MapComfortExtraToViewModel(ComfortExtra model, int? extraId)
        {
            return new ComfortExtraFormViewModel
            {
                Id = model.Id,
                Name = model.Name,
                IsChecked = model.ExtraId == extraId
            };
        }

        private ExteriorExtraFormViewModel MapExteriorExtraToViewModel(ExteriorExtra model, int? extraId)
        {
            return new ExteriorExtraFormViewModel
            {
                Id = model.Id,
                Name = model.Name,
                IsChecked = model.ExtraId == extraId // Set IsChecked based on the condition
            };
        }

        private InteriorExtraFormViewModel MapInteriorExtraToViewModel(InteriorExtra model, int? extraId)
        {
            return new InteriorExtraFormViewModel
            {
                Id = model.Id,
                Name = model.Name,
                IsChecked = model.ExtraId == extraId
            };
        }

        public async Task EditExtraAsync(ExtraFormViewModel extraVm, string userId, string extraId)
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

            var safetyExtrasToAdd = extraVm.SafetyExtrasChecked
                .Where(extra => !extraDb.SafetyExtras.Any(se => se.Name == extra))
                .Select(extra => new SafetyExtra
                {
                    ExtraId = extraDb.Id,
                    Name = extra
                }).ToList();

            var comfortExtrasToAdd = extraVm.ComfortExtrasChecked
                .Where(extra => !extraDb.ComfortExtras.Any(se => se.Name == extra))
                .Select(extra => new ComfortExtra
                {
                    ExtraId = extraDb.Id,
                    Name = extra
                }).ToList();

            var exteriorExtrasToAdd = extraVm.ExteriorExtrasChecked
               .Where(extra => !extraDb.ExteriorExtras.Any(se => se.Name == extra))
               .Select(extra => new ExteriorExtra
               {
                   ExtraId = extraDb.Id,
                   Name = extra
               }).ToList();

            var interiorExtrasToAdd = extraVm.InteriorExtrasChecked
                .Where(extra => !extraDb.InteriorExtras.Any(se => se.Name == extra))
                .Select(extra => new InteriorExtra
                {
                    ExtraId = extraDb.Id,
                    Name = extra
                }).ToList();

            var otherExtrasToAdd = extraVm.OtherExtrasChecked
                .Where(extra => !extraDb.OtherExtras.Any(se => se.Name == extra))
                .Select(extra => new OtherExtra
                {
                    ExtraId = extraDb.Id,
                    Name = extra
                }).ToList();

            // Remove extras that were previously checked but now unchecked
            var extrasToRemove = extraDb.SafetyExtras
                .Where(e => !extraVm.SafetyExtrasChecked.Contains(e.Name))
                .ToList();
            context.SafetyExtras.RemoveRange(extrasToRemove);

            var extrasToRemoveC = extraDb.ComfortExtras
                .Where(e => !extraVm.ComfortExtrasChecked.Contains(e.Name))
                .ToList();
            context.ComfortExtras.RemoveRange(extrasToRemoveC);

            var extrasToRemoveE = extraDb.ExteriorExtras
               .Where(e => !extraVm.ExteriorExtrasChecked.Contains(e.Name))
               .ToList();
            context.ExteriorExtras.RemoveRange(extrasToRemoveE);

            var extrasToRemoveI = extraDb.InteriorExtras
              .Where(e => !extraVm.InteriorExtrasChecked.Contains(e.Name))
              .ToList();
            context.InteriorExtras.RemoveRange(extrasToRemoveI);

            var extrasToRemoveO = extraDb.OtherExtras
             .Where(e => !extraVm.OtherExtrasChecked.Contains(e.Name))
             .ToList();
            context.OtherExtras.RemoveRange(extrasToRemoveO);


            context.SafetyExtras.AddRange(safetyExtrasToAdd);
            context.ComfortExtras.AddRange(comfortExtrasToAdd);
            context.ExteriorExtras.AddRange(exteriorExtrasToAdd);
            context.InteriorExtras.AddRange(interiorExtrasToAdd);
            context.OtherExtras.AddRange(otherExtrasToAdd);

            context.Extras.Update(extraDb);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<InteriorExtraFormViewModel>> GetInteriorExtrasAsync()
        {
            return await context.InteriorExtras.Where(e => e.ExtraId == null)
                .Select(e => new InteriorExtraFormViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                }).ToListAsync();
        }

        public async Task<IEnumerable<ExteriorExtraFormViewModel>> GetExteriorExtrasAsync()
        {
            return await context.ExteriorExtras.Where(e => e.ExtraId == null)
               .Select(e => new ExteriorExtraFormViewModel()
               {
                   Id = e.Id,
                   Name = e.Name,
               }).ToListAsync();
        }

        public async Task<IEnumerable<SafetyExtraFormViewModel>> GetSafetyExtrasAsync()
        {
            return await context.SafetyExtras.Where(e => e.ExtraId == null)
              .Select(e => new SafetyExtraFormViewModel()
              {
                  Id = e.Id,
                  Name = e.Name,
              }).ToListAsync();
        }

        public async Task<IEnumerable<ComfortExtraFormViewModel>> GetComfortExtrasAsync()
        {
            return await context.ComfortExtras.Where(e => e.ExtraId == null)
             .Select(e => new ComfortExtraFormViewModel()
             {
                 Id = e.Id,
                 Name = e.Name,
             }).ToListAsync();
        }

        public async Task<IEnumerable<OtherExtraFormViewModel>> GetOtherExtrasAsync()
        {
            return await context.OtherExtras.Where(e => e.ExtraId == null)
            .Select(e => new OtherExtraFormViewModel()
            {
                Id = e.Id,
                Name = e.Name,
            }).ToListAsync();
        }

        public async Task<bool> CheckInteriorByNameExist(string name)
        {
            return await context.InteriorExtras.Where(m => m.Name.ToLower() == name.ToLower()).AnyAsync();
        }

        public async Task<bool> CheckExteriorByNameExist(string name)
        {
            return await context.ExteriorExtras.Where(m => m.Name.ToLower() == name.ToLower()).AnyAsync();
        }

        public async Task<bool> CheckSafetyByNameExist(string name)
        {
            return await context.SafetyExtras.Where(m => m.Name.ToLower() == name.ToLower()).AnyAsync();
        }

        public async Task<bool> CheckComfortByNameExist(string name)
        {
            return await context.ComfortExtras.Where(m => m.Name.ToLower() == name.ToLower()).AnyAsync();
        }

        public async Task<bool> CheckOtherByNameExist(string name)
        {
            return await context.OtherExtras.Where(m => m.Name.ToLower() == name.ToLower()).AnyAsync();
        }

        public async Task AddInteriorAsync(string name)
        {
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrWhiteSpace(name))
            {
                var exToAdd = new InteriorExtra()
                {
                    ExtraId = null,
                    Name = name,
                };

                await context.InteriorExtras.AddAsync(exToAdd);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddExteriorAsync(string name)
        {
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrWhiteSpace(name))
            {
                var exToAdd = new ExteriorExtra()
                {
                    ExtraId = null,
                    Name = name,
                };

                await context.ExteriorExtras.AddAsync(exToAdd);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddSafetyAsync(string name)
        {
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrWhiteSpace(name))
            {
                var exToAdd = new SafetyExtra()
                {
                    ExtraId = null,
                    Name = name,
                };

                await context.SafetyExtras.AddAsync(exToAdd);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddComfortAsync(string name)
        {
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrWhiteSpace(name))
            {
                var exToAdd = new ComfortExtra()
                {
                    ExtraId = null,
                    Name = name,
                };

                await context.ComfortExtras.AddAsync(exToAdd);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddOtherAsync(string name)
        {
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrWhiteSpace(name))
            {
                var exToAdd = new OtherExtra()
                {
                    ExtraId = null,
                    Name = name,
                };

                await context.OtherExtras.AddAsync(exToAdd);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteInteriorAsync(string Id)
        {
            var entityToDel = await context.InteriorExtras.Where(m => m.Id.ToString() == Id).FirstOrDefaultAsync();
            if (entityToDel == null)
            {
                throw new NullReferenceException("This Extra does not exist!");
            }
            context.InteriorExtras.Remove(entityToDel);
            await context.SaveChangesAsync();
        }

        public async Task DeleteExteriorAsync(string Id)
        {
            var entityToDel = await context.ExteriorExtras.Where(m => m.Id.ToString() == Id).FirstOrDefaultAsync();
            if (entityToDel == null)
            {
                throw new NullReferenceException("This Extra does not exist!");
            }
            context.ExteriorExtras.Remove(entityToDel);
            await context.SaveChangesAsync();
        }

        public async Task DeleteSafetyAsync(string Id)
        {
            var entityToDel = await context.SafetyExtras.Where(m => m.Id.ToString() == Id).FirstOrDefaultAsync();
            if (entityToDel == null)
            {
                throw new NullReferenceException("This Extra does not exist!");
            }
            context.SafetyExtras.Remove(entityToDel);
            await context.SaveChangesAsync();
        }

        public async Task DeleteComfortAsync(string Id)
        {
            var entityToDel = await context.ComfortExtras.Where(m => m.Id.ToString() == Id).FirstOrDefaultAsync();
            if (entityToDel == null)
            {
                throw new NullReferenceException("This Extra does not exist!");
            }
            context.ComfortExtras.Remove(entityToDel);
            await context.SaveChangesAsync();
        }

        public async Task DeleteOtherAsync(string Id)
        {
            var entityToDel = await context.OtherExtras.Where(m => m.Id.ToString() == Id).FirstOrDefaultAsync();
            if (entityToDel == null)
            {
                throw new NullReferenceException("This Extra does not exist!");
            }
            context.OtherExtras.Remove(entityToDel);
            await context.SaveChangesAsync();
        }
    }
}