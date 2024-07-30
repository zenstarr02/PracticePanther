using PP.MAUI.ViewModels;

namespace PP.MAUI.Views;

public partial class TimeView : ContentPage
{
    public TimeView()
    {
        InitializeComponent();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }


    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new TimeViewViewModel();
    }

    private void EditClicked(object sender, EventArgs e)
    {

    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewViewModel).RefreshTimeList();
    }

    private void AddClicked(object sender, EventArgs e) 
    {
        Shell.Current.GoToAsync("//TimeDetail");
    }
}