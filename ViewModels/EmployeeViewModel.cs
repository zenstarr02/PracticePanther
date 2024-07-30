using PP.Library.Models;
using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PP.MAUI.ViewModels
{
    public class EmployeeViewModel
    { 
        public Employee Model
        {
            get; 
        }

        public ICommand EditCommand { get;set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public EmployeeViewModel()
        {
            Model = new Employee();
            SetupCommands();

        }

        public EmployeeViewModel(Employee model) 
        { 
            if(model.Id == 0)
            {
                Model = new Employee();
            }
            else
            {
                Model = model;
            }
            SetupCommands();
        }

        public EmployeeViewModel(int id)
        {
            if(id == 0) 
            {
                Model = new Employee();
            }
            else
            {
                Model = EmployeeService.Current.Get(id);
            }
            SetupCommands();

        }


        public ObservableCollection<TimeViewModel> Times { 
            
            get
            {
                var FilteredList = TimeService.Current.Times.Where(s => s.EmployeeId == Model.Id).Select(r => new TimeViewModel(r));
                return new ObservableCollection<TimeViewModel>(FilteredList);
            } 
        }

        private void SetupCommands()
        {
            DeleteCommand = new Command(
            (c) => ExecuteDelete(Model.Id));
            EditCommand = new Command(ExecuteEdit);
        }

        public void ExecuteEdit()
        {
            Shell.Current.GoToAsync($"//EmployeeDetail?employeeId={Model.Id}");
        }

        public void ExecuteDelete(int id)
        {
            EmployeeService.Current.Delete(id);
            

        }

        public void AddOrUpdate()
        {
            EmployeeService.Current.AddOrUpdate(Model);
        }


        public void RefreshTimes()
        {
            NotifyPropertyChanged(nameof(Times));  

        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
