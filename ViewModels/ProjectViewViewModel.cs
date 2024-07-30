using PP.Library.Models;
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
    public class ProjectViewViewModel : INotifyPropertyChanged
    {


        public Client client { get; set; }  
        public ProjectViewViewModel() {}

        public ProjectViewViewModel(int id)
        {
            if(id > 0)
            {
                client = ClientService.Current.Get(id);
//                  List<Bill> Bills = new List<Bill>() { };
    }
            else
            {
                client = new Client();

            }

        }

        public ObservableCollection<ProjectViewModel> Projects
        {

            get
            {
                if(client == null|| client.Id == 0)
                {
                    return new ObservableCollection<ProjectViewModel>();
                }
                return new ObservableCollection<ProjectViewModel>(ProjectService.Current.Projects.Where(s => s.ClientId == client.Id).Select(r => new ProjectViewModel(r)));
            }
           /* {
                *//* var FilteredList = ClientService.Current.Clients.Where(s => s.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty));    
                 return new ObservableCollection<Client>(FilteredList);*//*
                // return new ObservableCollection<Client>(ClientService.Current.Clients);
                return new ObservableCollection<ProjectViewModel>(ProjectService.Current.Projects
                 .Select(c => new ProjectViewModel(c)).ToList());*//*
            }*/
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
