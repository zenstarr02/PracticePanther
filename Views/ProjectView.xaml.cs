using PP.MAUI.ViewModels;
using PP.Library.Models;
namespace PP.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]

public partial class ProjectView : ContentPage
{

    public int ClientId { get; set; }
	public ProjectView()
	{
		InitializeComponent();
	}


    /*public ProjectView(int clientId)
    {
        InitializeComponent();
        BindingContext = new ProjectViewViewModel(clientId);
    }*/

    private void Toolbar_ClientsClicked(object sender, EventArgs e)
    {
    //    (BindingContext as ProjectViewViewModel).ShowClients();
        Shell.Current.GoToAsync("//ClientView");

    }

    private void Toolbar_ProjectsClicked(object sender, EventArgs e)
    {
  //
  //(BindingContext as ProjectViewViewModel).ShowProjects();
        Shell.Current.GoToAsync("//ProjectView");
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientView");
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
      (BindingContext as ProjectViewViewModel).RefreshProjects();
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ProjectDetail?clientId={ClientId}&projectId = {0}");
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectViewViewModel(ClientId);
        (BindingContext as ProjectViewViewModel).RefreshProjects();

    }

    private void EditClicked(object sender, EventArgs e)
    {

    }

}