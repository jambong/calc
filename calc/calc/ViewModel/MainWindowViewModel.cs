using calc.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
        private string _currentString;
        private double _currentNum;
        private int _oper;
        private string _historyString;

        private operEnum currentOper { get; set; }

        private state currentState { get; set; }

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
        public double currentNum
        {
            get { return _currentNum; }
            set
            {
                _currentNum = value;
                OnpropertyChanged("currentNum");
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
        public string currentString
        {
            get { return _currentString; }
            set
            {
                _currentString = value;
                _currentNum = double.Parse(_currentString);
                OnpropertyChanged("currentString");
            }
        }

        private enum state
        {
            ZERO, LIT, DOUBLE, OPER, DONE, NONE,
        }

        private enum operEnum
        {
            NONE, PLUS, MINUS, MUL, DIV, PERCENT, SQRT, SQR, EQ, DOT, PM, C, CE, BACK, REVERSE,
        }

        // constructor
        public MainWindowViewModel()
        {
            buttonCommand = new RelayCommand(new Action<object>(buttonClicked));
            currentString = "0";
            currentState = state.ZERO;
            currentOper = operEnum.NONE;
        }

        private void buttonClicked(object param)
        {
            var v = param as Button;
            if(v == null)
            {
                return;
            }

            var tmp = v.Content.ToString();

            if(isDot(tmp) || isNum(tmp))
            {
                writeNumber(tmp);
            }
        }

        private void writeNumber(string numStr)
        {
            if(isDot(numStr))
            {
                if(currentState == state.DOUBLE)
                {
                    return;
                }
                else
                {
                    currentString = currentString + numStr;
                    currentState = state.DOUBLE;
                }                
            }
            else if(isNum(numStr))
            {
                if(currentState == state.ZERO)
                {
                    currentString = numStr;
                    currentState = state.LIT;
                }
                else if(currentState == state.LIT || currentState == state.DOUBLE)
                {
                    currentString = currentString + numStr;
                }
                else if(currentState == state.OPER)
                {
                    currentString = currentString + numStr;
                }
            }
        }

        private void setOper(string oper)
        {
            if(currentState == state.DOUBLE || currentState == state.LIT)
            {

            }
        }

        private void calc(operEnum oper, double newNumber)
        {
            if (currentState == state.OPER)
            {
                if (oper == operEnum.PLUS)
                {
                    accu = accu + newNumber;
                    currentString = accu.ToString();
                }
                else if (oper == operEnum.MINUS)
                {
                    accu = accu - newNumber;
                    currentString = accu.ToString();
                }
                else if (oper == operEnum.MUL)
                {
                    accu = accu * newNumber;
                    currentString = accu.ToString();
                }
                else if (oper == operEnum.DIV)
                {
                    if (newNumber == 0) { return; }
                    accu = accu / newNumber;
                    currentString = accu.ToString();
                }
            }
        }

        private bool isOper(string str)
        {
            return str == "X" || str == "/" || str == "-" || str == "+";
        }

        private bool isNum(string str)
        {
            return int.TryParse(str, out int n);
        }

        private bool isDot(string str)
        {
            return str == ".";
        }
    }
}
