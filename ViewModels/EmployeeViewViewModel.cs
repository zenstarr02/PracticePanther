using PP.Library.Services;
using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PP.MAUI.ViewModels
{
    public class EmployeeViewViewModel : INotifyPropertyChanged
    {
        public EmployeeViewViewModel() { }
        public ObservableCollection<EmployeeViewModel> Employees 
        {
            get
            {
                return new ObservableCollection<EmployeeViewModel>(EmployeeService.Current.Employees
                .Select(c => new EmployeeViewModel(c)).ToList());
            }
        
        }




        public void RefreshEmployeeList()
        {
            NotifyPropertyChanged(nameof(Employees));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
