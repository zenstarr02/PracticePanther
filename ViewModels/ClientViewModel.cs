using PP.Library.Services;
using PP.Library.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PP.MAUI.ViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
      
        public ICommand AddProjectCommand { get; private set; }

        public ICommand CloseCommand { get; private set; } 

        public ICommand ShowProjectsCommand { get; private set; }

        public Client Model { get; set; }


        bool Edit { get; set; }

        public bool IsEdit()
        {
            if (Model.Id == 0)
            {
                return false;
            }
                return true;

        }

        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            { 
                if(Model == null || Model.Id == 0)
                {
                    return new ObservableCollection<ProjectViewModel>();
                }

              var FilteredList = ProjectService.Current.Projects.Where(s => s.ClientId == Model.Id).Select(r=> new ProjectViewModel(r));
                return new ObservableCollection<ProjectViewModel>(FilteredList); 
            }
        }

     /* public ObservableCollection<BillViewModel> Bills { 
            get
            {
                if(Model == null || Model.Id == 0)
                {
                    return new ObservableCollection<BillViewModel>();
                }

                return new ObservableCollection<BillViewModel>(BillService.Current.Bills.Where());
            } 
        
        }
*/

        public string Display
        {
            get
            {
               return Model.ToString() ?? string.Empty; 
            }
        }

        public ClientViewModel()
        {
            Model = new Client();
            SetupCommands();

        }


        public bool IsClose()
        {
            for(int i = 0; i < Projects.Count; i++)
            {
                if (Projects[i].IsActive() == true)
                {
                    return false;
                }
            }

            return true;
        }

        private Visibility Visible;

        public Visibility Vi
        {
            
            get { return Visible; }

            set { 
                if (IsClose())
                {
                    Visible = Visibility.Visible;
                }
                else
                {
                    Visible = Visibility.Hidden;
                }

                NotifyPropertyChanged("Vi");
            
            }
        }

         
        public Client SelectedClient { get; set; }  

        public ClientViewModel(int clientid)
        {

            if(clientid == 0)
            {
                Model = new Client();
            }
            else
            {
                Model = ClientService.Current.Get(clientid);

            }
            SetupCommands();

        }
        public ClientViewModel(Client client)
        {
            Model = client;
            SetupCommands();

        }

        public void AddOrUpdate()
        {
            ClientService.Current.AddOrUpdate(Model);
        }

        private void SetupCommands()
        {
            DeleteCommand = new Command(
              (c) => ExecuteDelete((c as ClientViewModel).Model.Id));
            EditCommand = new Command(
              (c) => ExecuteEdit((c as ClientViewModel).Model.Id));
            AddProjectCommand = new Command(
                (c) => ExecuteAddProject());
            CloseCommand = new Command((c) => ExecuteClose(Model.Id));
            ShowProjectsCommand = new Command((c) => ExecuteShowProjects((c as ClientViewModel).Model.Id));
            

        }

        public void ExecuteClose(int id)
        {
            bool go = true;
            for(int i = 0;i<Projects.Count;i++) 
            {
                if (Projects[i].IsActive())
                {
                    go = false;
                }
            }

            if (go)
            {
                ClientService.Current.Close(id);
            }
        }

        public void ExecuteShowProjects(int id)
        {
            Shell.Current.GoToAsync($"//ProjectView?clientId={id}");
        }
        
        public void ExecuteDelete(int id)
        {
            ClientService.Current.Delete(id);
        }

        public void ExecuteEdit(int id)
        {
            Edit = IsEdit();
            NotifyPropertyChanged("Edit");

            Shell.Current.GoToAsync($"//ClientDetail?clientId={id}");

        }

        public void ExecuteAddProject()
        {
            AddOrUpdate();
            Shell.Current.GoToAsync($"//ProjectDetail?clientId={Model.Id}");
        }

        


        public void RefreshProjects()
        {
            NotifyPropertyChanged(nameof(Projects)); 
        }



        public event PropertyChangedEventHandler PropertyChanged;


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



       
    }
}
