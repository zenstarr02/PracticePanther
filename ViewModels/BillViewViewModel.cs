using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PP.MAUI.ViewModels
{
    public class BillViewViewModel: INotifyPropertyChanged
    {

        public BillViewViewModel() { }

        /*public ObservableCollection<BillViewModel> Bills {
            get
            {
                return new ObservableCollection<BillViewModel>(BillService.Current.Bills.Where(s => s.ProjectId == Model.Id).Select(r => new BillViewModel(r)));
            }
                
                
                
         }*/



        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
