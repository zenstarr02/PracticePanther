using PP.MAUI.ViewModels;
using PP.Library.Models;
namespace PP.MAUI.Views;

[QueryProperty(nameof(TimeId), "timeId")]

public partial class TimeDetailView : ContentPage
{

	public int TimeId { get; set; }
	public TimeDetailView()
	{
		InitializeComponent();
	}

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
		BindingContext = new TimeViewModel(TimeId);
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//TimeView");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//TimeView");
    }
}