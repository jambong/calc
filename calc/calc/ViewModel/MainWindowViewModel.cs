using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private const string TAG = "[MainWindow]";

        private double _accu;
        private double _res;
        private int _oper;

        private enum state
        {
            LIT, OPER, DONE, NONE,
        }

        private enum operEnum
        {
            PLUS, MINUS, MUL, DIV, PERCENT, SQRT, SQR, EQ, DOT, PM, C, CE, BACK, REVERSE,
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnpropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
