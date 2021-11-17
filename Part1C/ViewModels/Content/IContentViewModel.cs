using Part1C.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1C.ViewModels
{
    interface IContentViewModel : INotifyPropertyChanged
    {
        object CurrentView { get; }
        RelayCommand ListCommand { get; }
        RelayCommand BoxCommand { get; }
    }
}