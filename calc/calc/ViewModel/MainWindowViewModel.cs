using calc.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calc.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnpropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private const string TAG = "[MainWindow]";

        private double _accu;
        private double _res;
        private int _oper;

        private string _historyString;

        public ICommand buttonCommand { get; set; }

        public double accu
        {
            get { return _accu; }
            set
            {
                _accu = value;
                OnpropertyChanged("accu");
            }
        }
        public double res
        {
            get { return _res; }
            set
            {
                _res = value;
                OnpropertyChanged("res");
            }
        }
        public int oper
        {
            get { return _oper; }
            set
            {
                _oper = value;
                OnpropertyChanged("oper");
            }
        }
        public string historyString
        {
            get { return _historyString; }
            set
            {
                _historyString = value;
                OnpropertyChanged("historyString");
            }
        }

        private enum state
        {
            LIT, OPER, DONE, NONE,
        }

        private enum operEnum
        {
            PLUS, MINUS, MUL, DIV, PERCENT, SQRT, SQR, EQ, DOT, PM, C, CE, BACK, REVERSE,
        }

        // constructor
        public MainWindowViewModel()
        {
            buttonCommand = new RelayCommand(new Action<object>(buttonClicked));
        }

        private void buttonClicked(object param)
        {

        }
    }
}
