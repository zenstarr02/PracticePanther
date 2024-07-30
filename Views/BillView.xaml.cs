using PP.MAUI.ViewModels;
using PP.Library.Models;
namespace PP.MAUI.Views;

[QueryProperty(nameof(ProjectId), "projectId")]

public partial class BillView : ContentPage
{

	public int ProjectId { get; set; }

	public BillView()
	{
		InitializeComponent();
	}



    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
		BindingContext = new BillViewModel(ProjectId);
    }

    private void OkClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ProjectDetail?projectId={ProjectId}");
    }
}