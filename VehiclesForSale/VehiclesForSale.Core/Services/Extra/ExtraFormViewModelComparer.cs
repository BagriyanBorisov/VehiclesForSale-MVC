namespace VehiclesForSale.Core.Services.Extra
{
    using VehiclesForSale.Web.ViewModels.Vehicle;


    public class ExtraFormViewModelComparer<T> : IEqualityComparer<T>
      where T : BaseExtraFormViewModel
    {
        public bool Equals(T? x, T? y)
        {
            return x?.Name == y?.Name;
        }

        public int GetHashCode(T obj)
        {
            return obj.Name.GetHashCode();
        }
    }


}
