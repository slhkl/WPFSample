using System.Windows;
using WPF.ViewModels;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TemperatureViewModel temperatureViewModel;

        public MainWindow()
        {
            temperatureViewModel = new TemperatureViewModel();
            InitializeComponent();
            this.DataContext = temperatureViewModel;
        }
    }
}