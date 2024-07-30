using PP.MAUI.ViewModels;

namespace PP.MAUI.Views;

public partial class EmployeeView : ContentPage
{
	public EmployeeView()
	{
		InitializeComponent();


    }
    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void EditClicked(object sender, EventArgs e)
    {
    
    }
    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).RefreshEmployeeList();
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EmployeeViewViewModel();
    }

    private void AddClicked(object sender, EventArgs e) 
    {
        Shell.Current.GoToAsync("//EmployeeDetail");
    }

}