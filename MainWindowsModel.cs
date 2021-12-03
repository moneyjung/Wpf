using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TestPT
{
    class MainWindowsModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        
        private void OnPropertyChanged(string info)
        {
            if (PropertyChanged == null) return;

            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        private string _gaugeTitle;
        private string _gaugeUnit;
        private double _max;
        private double _min;
        private double _value;
        private double _settingValue;
        private int _tankProperty;
        private double _maximum;
        private double _minimum;
        private int _radius;
        private int _strokethickness;
        private double _percentage;
        private double _angle;
        private double _value1;
        private double _value2;
        private double _value3;
        private double _value4;
        private double _valued;
        private double _valuep;

        public int Radius
        {
            get { return _radius; }
            set 
            {
                _radius = value;
                OnPropertyChanged("Radius");
            }
        }

        public int StrokeThickness
        {
            get { return _strokethickness; }
            set 
            {
                _strokethickness = value;
                OnPropertyChanged("StrokeThickness");
            }
        }

        public double Percentage
        {
            get { return _percentage; }
            set
            {
                _percentage = value;
                OnPropertyChanged("Percentage");
            }
        }

        public double Angle
        {
            get { return _angle; }
            set 
            { 
                _angle = value;
                OnPropertyChanged("Angle");
            }
        }

        public string GaugeTitle
        {
            get { return _gaugeTitle; }
            set
            {
                _gaugeTitle = value;
                OnPropertyChanged("GaugeTitle");
            }
        }

        public string GaugeUnit
        {
            get { return _gaugeUnit; }
            set
            {
                _gaugeUnit = value;
                OnPropertyChanged("GaugeUnit");
            }
        }

        public double Max
        {
            get { return _max; }
            set
            {
                _max = value;
                OnPropertyChanged("Max");
            }
        }

        public double Min
        {
            get { return _min; }
            set
            {
                _min = value;
                OnPropertyChanged("Min");
            }
        }

        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        public double SettingValue
        {
            get { return _settingValue; }
            set
            {
                _settingValue = value;
                OnPropertyChanged("SettingValue");
            }
        }

        public int TankProperty
        {
            get { return _tankProperty; }
            set
            {
                _tankProperty = value;
                OnPropertyChanged("TankProperty");
            }
        }

        public double Maximum
        {
            get { return _maximum; }
            set
            {
                _maximum = value;
                OnPropertyChanged("Maximum");
            }
        }

        public double Minimum
        {
            get { return _minimum; }
            set
            {
                _minimum = value;
                OnPropertyChanged("Minimum");
            }
        }

        public double Value1
        {
            get { return _value1; }
            set
            {
                _value1 = value;
                OnPropertyChanged("Value1");
            }
        }

        public double Value2
        {
            get { return _value2; }
            set
            {
                _value2 = value;
                OnPropertyChanged("Value2");
            }
        }

        public double Value3
        {
            get { return _value3; }
            set
            {
                _value3 = value;
                OnPropertyChanged("Value3");
            }
        }

        public double Value4
        {
            get { return _value4; }
            set
            {
                _value4 = value;
                OnPropertyChanged("Value4");
            }
        }

        public double Valued
        {
            get { return _valued; }
            set
            {
                _valued = value;
                OnPropertyChanged("Valued");
            }
        }

        public double Valuep
        {
            get { return _valuep; }
            set
            {
                _valuep = value;
                OnPropertyChanged("Valuep");
            }
        }

        public bool? IsChecked
        {
            get; set;
        }

        public void NotifyPropertyChanged(String propertyName = "")
        {
            if(PropertyChanged != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }
    }
}
