using HansPlc;
using System;
using System.Linq;

namespace Recipes.Essentials.Wpf
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            PLC = Entry.HansPlc;
        }

        public HansPlcTwinController PLC { get; }
    }
}
