namespace VehiclesForSale.Web.ViewModels.Account
{
    public  class ProfileViewModel
    {
        public ProfileViewModel()
        {
            this.Notifications = new List<NotificationViewModel>();
            this.Profile = new RegisterViewModel();
        }
        public RegisterViewModel Profile { get; set; }

        public List<NotificationViewModel> Notifications { get; set; }
    }
}
