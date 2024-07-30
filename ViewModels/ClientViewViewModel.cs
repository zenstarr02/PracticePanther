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
    public class ClientViewViewModel : INotifyPropertyChanged
    {

        public Client SelectedClient { get; set; }

        public ClientViewViewModel()
        {
            IsClientVisible = true;
            IsProjectVisible = false;


        }



        public ObservableCollection<ClientViewModel> Clients
        {
            get
            {
                /* var FilteredList = ClientService.Current.Clients.Where(s => s.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty));    
                 return new ObservableCollection<Client>(FilteredList);*/
               // return new ObservableCollection<Client>(ClientService.Current.Clients);
               return new ObservableCollection<ClientViewModel>(ClientService.Current.Clients
                .Select(c=> new ClientViewModel(c)).ToList());
            }
        }

        public ClientViewViewModel(Client client)
        {
        }


        public bool IsClientVisible { get; set; }
        public bool IsProjectVisible { get; set; }

        public void ShowClients()
        {
            IsClientVisible = true;
            IsProjectVisible = false;
            NotifyPropertyChanged("IsClientVisible");
            NotifyPropertyChanged("IsProjectVisible");
        }

        public void ShowProjects()
        {
            IsClientVisible = false;
            IsProjectVisible = true;
            NotifyPropertyChanged("IsClientVisible");
            NotifyPropertyChanged("IsProjectVisible");
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshClientList()
        {
            NotifyPropertyChanged(nameof(Clients));
        }
    }
}

