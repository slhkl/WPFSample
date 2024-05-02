using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WPF.Utils;

namespace WPF.ViewModels
{
    public class TemperatureViewModel : INotifyPropertyChanged
    {
        #region Members

        private double celsius;

        private double fahrenheit;

        private double kelvin;

        private string selectedMeasurementUnit;

        private bool isCalculating;

        #endregion

        #region Properties

        public double Celsius
        {
            get
            {
                return celsius;
            }
            set
            {
                celsius = value;
                OnPropertyChanged();

                ConvertTemperatures(nameof(Celsius));
            }
        }

        public double Fahrenheit
        {
            get
            {
                return fahrenheit;
            }
            set
            {
                fahrenheit = value;
                OnPropertyChanged();

                ConvertTemperatures(nameof(Fahrenheit));
            }
        }

        public double Kelvin
        {
            get
            {
                return kelvin;
            }
            set
            {
                kelvin = value;
                OnPropertyChanged();

                ConvertTemperatures(nameof(Kelvin));
            }
        }

        public string SelectedMeasurementUnit
        {
            get
            {
                return selectedMeasurementUnit;
            }
            set
            {
                selectedMeasurementUnit = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> MeasurementUnitList { get; } = new ObservableCollection<string> { nameof(Celsius), nameof(Fahrenheit), nameof(Kelvin) };

        #endregion

        #region ICommands

        private ICommand? convertCommand;

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Commands

        public ICommand ConvertCommand
        {
            get
            {
                if (convertCommand == null)
                    convertCommand = new RelayCommand(ConvertTemperatures);
                return convertCommand;
            }
        }

        #endregion

        #region Methods

        protected void OnPropertyChanged([CallerMemberName] string nameOfItem = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameOfItem));
        }

        private void ConvertTemperatures()
        {
            switch (SelectedMeasurementUnit)
            {
                case nameof(Celsius):
                    Fahrenheit = (Celsius * 9.0 / 5.0) + 32;
                    Kelvin = Celsius + 273.15;
                    break;
                case nameof(Fahrenheit):
                    Celsius = (Fahrenheit - 32) * 5.0 / 9.0;
                    Kelvin = Celsius + 273.15;
                    break;
                case nameof(Kelvin):
                    Celsius = Kelvin - 273.15;
                    Fahrenheit = (Celsius * 9.0 / 5.0) + 32;
                    break;
                default:
                    throw new NotSupportedException("Wrong MeasurementUnit");
            }
        }

        private void ConvertTemperatures(string selectedMeasurementUnit)
        {
            if (!isCalculating)
            {
                isCalculating = true;
                switch (selectedMeasurementUnit)
                {
                    case nameof(Celsius):
                        Fahrenheit = (Celsius * 9.0 / 5.0) + 32;
                        Kelvin = Celsius + 273.15;
                        break;
                    case nameof(Fahrenheit):
                        Celsius = (Fahrenheit - 32) * 5.0 / 9.0;
                        Kelvin = Celsius + 273.15;
                        break;
                    case nameof(Kelvin):
                        Celsius = Kelvin - 273.15;
                        Fahrenheit = (Celsius * 9.0 / 5.0) + 32;
                        break;
                    default:
                        throw new NotSupportedException("Wrong MeasurementUnit");
                }
                isCalculating = false;
            }
        }

        #endregion
    }
}
