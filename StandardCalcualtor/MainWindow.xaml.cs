using StandardCalcualtor.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StandardCalcualtor
{
    public partial class MainWindow : Window
    {
        double result, lastNumber;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();

            // stil working on this feature 
            deleteButton.IsEnabled = false;

            ACButton.Click += ACButton_Click;
            deleteButton.Click += DeleteButton_Click;
            pointButton.Click += PointButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equalButton.Click += EqualButton_Click;
            reverseButton.Click += ReverseButton_Click;
            powerButton.Click += PowerButton_Click;
            radicalButton.Click += RadicalButton_Click;
            githubButton.Click += GithubButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(Result.Text.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Addition(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Substraction:
                        result = SimpleMath.Substraction(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }
                selectedOperator = SelectedOperator.Addition;
                lastNumber = 0;
                Result.Text = result.ToString();
            }
        }
        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(Result.Text.ToString(), out tempNumber))
            {
                tempNumber = (tempNumber / 100);
                if (lastNumber != 0)
                    tempNumber *= lastNumber;
                Result.Text = tempNumber.ToString();
            }
        }
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Result.Text.ToString(), out lastNumber))
            {
                Result.Text = "0";
            }

            if (sender == multiplicationButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == divisionButton)
                selectedOperator = SelectedOperator.Division;
            if (sender == plusButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == minusButton)
                selectedOperator = SelectedOperator.Substraction;
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e) // work in progres
        {
            if (Result.Text == "" || Result.Text == "0" || Result.Text.ToString().Length == 1 || Result.Text == "-")
            {
                Result.Text = "0";
            }
            else
            {
                Result.Text = Result.Text.ToString().Remove(Result.Text.ToString().Length - 1);
            }
        }
        private void ReverseButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(Result.Text.ToString(), out tempNumber))
            {
                if(tempNumber != 0)
                {
                    Result.Text = $"{Math.Round(1 / tempNumber, 8) }";
                }
                else
                {
                    MessageBox.Show("Division by 0 is not supported", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Result.Text = "0";
                }
            }
        }
        private void PowerButton_Click(Object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if(double.TryParse(Result.Text.ToString(),out tempNumber))
            {
                Result.Text = $"{Math.Pow(tempNumber,2)}";
            }
        }
        private void RadicalButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(Result.Text.ToString(), out tempNumber))
            {
                Result.Text = $"{Math.Sqrt(tempNumber)}";
            }
        }
        private void GithubButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/KacperCedro/StandardCalcualtor",
                UseShellExecute = true
            });
        }
        private void PointButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(Result.Text.ToString().Contains(".")))
            {
                Result.Text += ".";
            }
        }
        private void ACButton_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = "0";
            result = 0;
            lastNumber = 0;
        }
        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Result.Text, out lastNumber))
            {
                lastNumber = lastNumber * -1;
                Result.Text = lastNumber.ToString();
            }
        }
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == zeroButton)
                selectedValue = 0;
            if (sender == oneButton)
                selectedValue = 1;
            if (sender == twoButton)
                selectedValue = 2;
            if (sender == threeButton)
                selectedValue = 3;
            if (sender == fourButton)
                selectedValue = 4;
            if (sender == fiveButton)
                selectedValue = 5;
            if (sender == sixButton)
                selectedValue = 6;
            if (sender == sevenButton)
                selectedValue = 7;
            if (sender == eightButton)
                selectedValue = 8;
            if (sender == nineButton)
                selectedValue = 9;

            if (Result.Text == "0")
            {
                Result.Text = selectedValue.ToString();
            }
            else
            {
                Result.Text += selectedValue.ToString();
            }
        }
        public enum SelectedOperator

        {
            Addition,
            Substraction,
            Multiplication,
            Division
        }
    }
}
