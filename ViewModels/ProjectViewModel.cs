using PP.MAUI.Views;
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
    public class ProjectViewModel : INotifyPropertyChanged
    {

        public ICommand DeleteCommand { get; private set; }

        public ICommand EditCommand { get; private set; }

        public ICommand AddCommand { get; private set; }

        public ICommand TimerCommand {  get; private set; }

        public ICommand ShowBillCommand { get; private set; }

        public Project Model { get; set; }


        //public List<Time> Times { get { return new List<Time>(TimeService.Current.Times.Where((c) => c.ProjectId == Model.Id)); } }




        public ProjectViewModel() 
        {
            Model = new Project();
            SetupCommands();
        }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public ProjectViewModel(Project p)
        {
            Model = p;
            SetupCommands();

        }

        

        public ProjectViewModel(int clientid,int id)
        {
            if(id == 0)
            {
                Model = new Project { ClientId = clientid };


            }
            else
            {
                Model = ProjectService.Current.Get(id);
            }

            SetupCommands();
        }
        public ProjectViewModel(int clientid)
        {

          Model = new Project { ClientId = clientid };
            SetupCommands();
        }


        public void SetupCommands()
        {
            AddCommand = new Command(ExecuteAdd);
            TimerCommand = new Command(ExecuteTimer);
            DeleteCommand = new Command(ExecuteDelete);
            EditCommand = new Command(ExecuteEdit);
            ShowBillCommand = new Command(ExecuteGenerateBill);
        }

        private void ExecuteDelete()
        {
            ProjectService.Current.Projects.Remove(Model);
        }

        private void ExecuteTimer()
        {
            var window = new Window(new TimerView(Model.Id))
            {
                Width = 250,
                Height = 300,
                X = 0,
                Y = 0
                
            };

            Application.Current.OpenWindow(window);
            
        }


       
        public void AddOrUpdate()
        {
            ProjectService.Current.AddOrUpdate(Model);
        }

        public bool IsActive()
        {
            return Model.IsActive;
        }

        private void ExecuteAdd()
        {
            AddOrUpdate();
            Shell.Current.GoToAsync($"//ClientDetail?clientId={Model.ClientId}");
        }


        private void ExecuteGenerateBill()
        {
            Shell.Current.GoToAsync($"//BillView?projectId={Model.Id}");
        }

        private void ExecuteEdit()
        {
            Shell.Current.GoToAsync($"//ProjectDetail?clientId={Model.ClientId}&projectId={Model.Id}");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
