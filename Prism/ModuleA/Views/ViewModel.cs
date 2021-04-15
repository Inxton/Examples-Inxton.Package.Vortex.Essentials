using HansPlc;
using Prism.Mvvm;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private IHansPlcTwinController _plc;

        public IHansPlcTwinController PLC { get => _plc; set => SetProperty(ref _plc,value); }

        public ViewAViewModel(IPlc PLC)
        {
            this.PLC = PLC.Controller;
        }

        public ViewAViewModel()
        {
            this.PLC = new DummyPlc().Controller;
        }
    }

}
