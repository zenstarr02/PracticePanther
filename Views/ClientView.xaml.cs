using PP.MAUI.ViewModels;

namespace PP.MAUI.Views;

public partial class ClientView : ContentPage
{
	public ClientView()
	{
		InitializeComponent();
		BindingContext = new ClientViewViewModel();
	}

	private void Toolbar_ClientsClicked(object sender, EventArgs e)
	{
		(BindingContext as ClientViewViewModel).ShowClients();
        Shell.Current.GoToAsync("//ClientView");

    }

    private void Toolbar_ProjectsClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).ShowProjects();
        Shell.Current.GoToAsync("//ProjectView");
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshClientList();
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientDetail");
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshClientList();
    }

    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshClientList();

    }

    private void ProjectsClicked(object sender, EventArgs e)
    {
    
    }
}