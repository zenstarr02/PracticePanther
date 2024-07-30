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

namespace PP.MAUI.ViewModels
{
    public class BillViewModel : INotifyPropertyChanged
    {
        public Bill Model { get; set; }

     //   public Project Project { get; set; }

        public ObservableCollection<TimeViewModel> Times { get { return new ObservableCollection<TimeViewModel>(TimeService.Current.Times.
                Where((c)=> c.ProjectId == Model.ProjectId).Select(c => new TimeViewModel(c)).ToList()); } }

        

        public BillViewModel(int id)
        {
            if(id == 0)
            {
                Model = new Bill();
            }
            else
            {
                Model = new Bill(id);
            }
        }

        public string DueDateDisplay
        {
            get 
            { 
            return Model.DueDate.ToString("D");
            }

        }

        

        public string AmountDisplay
        {
            get 
            {
                return $"${Model.TotalAmount}";
            }
        }

        /*  public BillViewModel(Bill model)
          {
              if(model.Id != 0)
              {
                  Model = model;
                 // Time = TimeService.Current.Get(Model.TimeId);
              }
          }*/

        //public Time Time { get; }




        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
