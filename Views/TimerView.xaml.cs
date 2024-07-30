using PP.MAUI.ViewModels;
using System.Diagnostics;

namespace PP.MAUI.Views;

public partial class TimerView : ContentPage
{
	
    public TimerView(int id)
    {
        InitializeComponent();
        BindingContext = new TimerViewModel(id);
    }

    private void OnExiting(object sender, NavigatedFromEventArgs e)
    {
    }

    private void CloseClicked(object sender, EventArgs e) 
    { 
     //   (BindingContext as TimerViewModel).AddOrUpdate();
        
    }
}