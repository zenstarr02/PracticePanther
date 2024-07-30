using PP.MAUI.ViewModels;
using System.Collections.ObjectModel;

namespace PP.MAUI.Views;

[QueryProperty(nameof(ClientId),"clientId")]

public partial class ClientDetailView : ContentPage
{
    public int ClientId { get; set; }

    public bool Edit { get; set; }

    public void IsEdit()
    {
        if (ClientId == 0)
        {
            Edit = false;
        }

        Edit = true;
    }

    public ClientDetailView()
	{
		InitializeComponent();
        BindingContext = new ClientViewModel();

    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//ClientView");
    }
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientView");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ClientViewModel(ClientId);
        IsEdit();
        (BindingContext as ClientViewModel).RefreshProjects();
    }

    private void AddPClicked(object sender, EventArgs e)
    {
       // Shell.Current.GoToAsync("//ProjectDetail");

        (BindingContext as ClientViewModel).RefreshProjects();
    }

    private void DeleteProjClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).RefreshProjects();

    }

    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).RefreshProjects();
    }

    private void CloseClientClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).RefreshProjects();
        Shell.Current.GoToAsync("//ClientView");
    }
}