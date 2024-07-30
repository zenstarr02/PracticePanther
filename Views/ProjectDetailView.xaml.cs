using PP.MAUI.ViewModels;
using PP.Library.Models;

namespace PP.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
[QueryProperty(nameof(ProjectId), "projectId")]

public partial class ProjectDetailView : ContentPage
{

    public int ClientId { get; set; }

    public int ProjectId { get; set; }  

    public ProjectDetailView()
	{

		InitializeComponent();
       // BindingContext = new ProjectViewModel();
    }


    private void OkClicked(object sender, EventArgs e)
    {
        // (BindingContext as ProjectViewModel).ExecuteAdd();
        (BindingContext as ProjectViewModel).AddOrUpdate();
        Shell.Current.GoToAsync($"//ClientDetail?clientId={ClientId}");
    }
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ClientView");
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectViewModel(ClientId,ProjectId);

    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}