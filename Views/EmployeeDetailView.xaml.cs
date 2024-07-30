using PP.MAUI.ViewModels;
using PP.Library.Models;
namespace PP.MAUI.Views;

[QueryProperty(nameof(EmployeeId), "employeeId")]


public partial class EmployeeDetailView : ContentPage
{
    public int EmployeeId { get; set; }
    public EmployeeDetailView()
    {
        InitializeComponent();
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EmployeeViewModel(EmployeeId);
        (BindingContext as EmployeeViewModel).RefreshTimes();

    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//EmployeeView");
    }
    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//EmployeeView");
    }

    private void EditClicked(object sender, EventArgs e)
    {
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewModel).RefreshTimes();
    }

}