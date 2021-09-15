using Calculator.Core.Calculator;
using Calculator.ViewModels.Base;
using Prism.Commands;
using System;
using System.Data;

namespace Calculator.ViewModels
{
    class ShellViewModel : ViewModelBase
    {
        public string Title { get; } = "Cool Calculator";

        public ShellViewModel()
        {
        }

        private string _calculatorText;
        private readonly ICalculator calculator;

        public string CalculatorText
        {
            get { return _calculatorText; }
            set {
                //_calculatorText = value;
                SetProperty(ref _calculatorText, value);
            }
        }

        public DelegateCommand<string> AddNumberCommand { get; set; }

        protected override void RegisterCommands()
        {
            //base.RegisterCommands();
            AddNumberCommand = new DelegateCommand<string>(AddNumber);
            ClearCommand = new DelegateCommand(Clear);
            EqualsCommand = new DelegateCommand(Equals);
        }

        private void AddNumber(string obj)
        {
            CalculatorText += obj;
        }

        public DelegateCommand ClearCommand { get; set; }

        private void Clear()
        {
            CalculatorText = "";
        }

        public DelegateCommand EqualsCommand { get; set; }

        private void Equals()
        {
            //CalculatorText = _calculator.Calculate(CalculatorText).ToString("N2");
            var datatable = new DataTable();
            var value = datatable.Compute(CalculatorText, "");
            CalculatorText = Convert.ToDouble(value).ToString("N2");
        }
    }
}
