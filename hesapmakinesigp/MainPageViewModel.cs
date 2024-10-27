using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace hesapmakinesigp { 

public class MainPageViewModel : INotifyPropertyChanged
{
    private string expressionDisplay;
    private string resultDisplay;

    public string ExpressionDisplay
    {
        get => expressionDisplay;
        set
        {
            if (expressionDisplay != value)
            {
                expressionDisplay = value;
                OnPropertyChanged(nameof(ExpressionDisplay));
            }
        }
    }

    public string ResultDisplay
    {
        get => resultDisplay;
        set
        {
            if (resultDisplay != value)
            {
                resultDisplay = value;
                OnPropertyChanged(nameof(ResultDisplay));
            }
        }
    }

    public ICommand HandleButtonPressCommand { get; }

    public MainPageViewModel()
    {
        ExpressionDisplay = string.Empty;
        ResultDisplay = string.Empty;

        HandleButtonPressCommand = new Command<string>(OnButtonPressed);
    }

    private void OnButtonPressed(string parameter)
    {

        switch (parameter)
        {
            case "AC":
                ExpressionDisplay = string.Empty;
                ResultDisplay = string.Empty;
                break;

            case "=":

                try
                {
                    var result = EvaluateExpression(ExpressionDisplay);
                    ResultDisplay = result.ToString();
                }
                catch (Exception ex)
                {
                    ResultDisplay = "Error";
                }
                break;

            case "DEL":

                if (ExpressionDisplay.Length > 0)
                    ExpressionDisplay = ExpressionDisplay.Substring(0, ExpressionDisplay.Length - 1);
                break;

            case "(  )":

                ExpressionDisplay += "()";
                break;

            case "%":

                ExpressionDisplay += "%";
                break;

            case "÷":

                ExpressionDisplay += "/";
                break;

            case "x":

                ExpressionDisplay += "*";
                break;

            case "-":

                ExpressionDisplay += "-";
                break;

            case "+":

                ExpressionDisplay += "+";
                break;

            case ".":

                ExpressionDisplay += ".";
                break;

            default:

                ExpressionDisplay += parameter;
                break;
        }
    }

    private double EvaluateExpression(string expression)
    {

        var table = new System.Data.DataTable();
        return Convert.ToDouble(table.Compute(expression, string.Empty));
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
} 

