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
    public class TimeViewModel : INotifyPropertyChanged
    {
        public Time Model { get; }



        private Employee employee;
        public Employee Employee { 
            get 
            {
                return employee;
            
            
            }
            set
            {
                employee = value;
                if(employee != null)
                {
                    Model.EmployeeId = employee.Id;
                }
            }
        
        
        }

        private Project project;

        public Project Project
        {
            get
            {
                return project;
            }
            set
            {
                project = value;
                if(project != null) 
                { 
                    Model.ProjectId = project.Id;
                }
            }
        }


        public string HoursDisplay
        {
            get { return Model.Hours.ToString(); }
            set
            {
                if(decimal.TryParse(value, out decimal v))
                     Model.Hours = v;
            }
        }


      //  public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public TimeViewModel()
        {
            Model = new Time();
        }

        public TimeViewModel(int id)
        {

            if(id == 0)
            {
                Model = new Time();
            }
            else
            {
            Model = TimeService.Current.Get(id);
            /*Project = ProjectService.Current.Get(Model.ProjectId);
            Employee = EmployeeService.Current.Get(Model.EmployeeId);*/
            }
            SetupCommands();
        }

        public TimeViewModel(Time model)
        {
            if (model.Id == 0)
            {
                Model = new Time();
            }
            else
            {
                Model = TimeService.Current.Get(model.Id);
                
                var p = ProjectService.Current.Get(Model.ProjectId);
                if(p != null)
                {
                    Project = p;
                }

                var e = EmployeeService.Current.Get(Model.EmployeeId);
                if(e != null)
                {
                    Employee = e;
                }
            }
            SetupCommands();

        }


        public string EmployeeDisplay => Employee.Name ?? string.Empty;
        public string ProjectDisplay => Project.ShortName ?? string.Empty;

        public ObservableCollection<Employee> Employees => new ObservableCollection<Employee>(EmployeeService.Current.Employees);
        public ObservableCollection<Project> Projects => new ObservableCollection<Project>(ProjectService.Current.Projects);

        public void AddOrUpdate()
        {
            TimeService.Current.AddOrUpdate(Model);
            NotifyPropertyChanged("Times");
        }

        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//TimeDetail?timeId={id}");
        }

        public void ExecuteDelete(int id)
        {

            TimeService.Current.Delete(id);

        }
        


        public void SetupCommands()
        {
            DeleteCommand = new Command(
             (c) => ExecuteDelete(Model.Id));
            EditCommand = new Command(
              (c) => ExecuteEdit(Model.Id));
           
        }

       

        public event PropertyChangedEventHandler PropertyChanged;


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
