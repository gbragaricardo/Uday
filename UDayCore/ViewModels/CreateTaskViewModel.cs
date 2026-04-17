using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace UDayCore.ViewModels
{
    public partial class CreateTaskViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial int Duration { get; set; }
    }
}
