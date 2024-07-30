using PP.MAUI.ViewModels;

namespace PP.MAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void ClientClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//ClientView");
        }

        private void EmployeeClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//EmployeeView");
        }

        private void TimeClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//TimeView");
        }
    }
}