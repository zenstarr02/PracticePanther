﻿using PP.Library.Models;
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
    public class TimeViewViewModel: INotifyPropertyChanged
    {

        public ObservableCollection<TimeViewModel> Times
        {
            get
            {
                   return new ObservableCollection<TimeViewModel>(TimeService.Current.Times.Select(c => new TimeViewModel(c)).ToList());
            }
        }


         public void RefreshTimeList()
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
