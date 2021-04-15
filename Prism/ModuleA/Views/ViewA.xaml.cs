using HansPlc;
using ModuleA.ViewModels;
using Prism.Mvvm;
using System.Windows.Controls;

namespace ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class ViewA : UserControl
    {
        public ViewA()
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                ViewModelLocator.SetAutoWireViewModel(this, false);
                this.DataContext = new ViewAViewModel(new DummyPlc());
            }
            InitializeComponent();
        }
    }
}
