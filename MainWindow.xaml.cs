using System.Windows;
using System.Windows.Controls;

namespace Deel_1___calculator
{
	public partial class MainWindow : Window
	{
		enum Operator{add,subtract,divide,multiply}
		Operator? _currentOperator = null;

		public MainWindow() => InitializeComponent();
	
		private void Problem(string what) => MessageBox.Show(what,"Oh nee, niet weer");

		private void Button_Calculate_Click(object sender, RoutedEventArgs e)
		{
			void Print(string str) {ListBox_History.Items.Add(str); Label_Result.Content = str; }

			if (_currentOperator == null) { Problem("Geen operator"); return; }
			bool okOne = double.TryParse(TextBox_One.Text, out double valueOne);
			bool okTwo = double.TryParse(TextBox_Two.Text, out double valueTwo);
			if (!okOne | !okTwo) { Problem("Wel goeie text invoeren AUB"); }
			if (valueTwo == 0 && _currentOperator == Operator.divide) { Print("Error"); return; }

			string result = string.Empty;
			switch(_currentOperator)
			{
				case Operator.add:      result = $"{valueOne} + {valueTwo} = {valueOne + valueTwo}"; break;
				case Operator.subtract: result = $"{valueOne} - {valueTwo} = {valueOne - valueTwo}"; break;
				case Operator.multiply: result = $"{valueOne} * {valueTwo} = {valueOne * valueTwo}"; break;
				case Operator.divide:   result = $"{valueOne} / {valueTwo} = {valueOne / valueTwo}"; break;
			}
			Print(result);
		}

		private void Radio_operator_Click(object sender, RoutedEventArgs e)
		{
			var radio = (RadioButton)sender;
			switch(radio.Name)
			{
				case "Radio_Add":      _currentOperator = Operator.add;      break;
				case "Radio_Subtract": _currentOperator = Operator.subtract; break;
				case "Radio_Multiply": _currentOperator = Operator.multiply; break;
				case "Radio_Divide":   _currentOperator = Operator.divide;   break;
			}
		}

		private void Button_clear_Click(object sender, RoutedEventArgs e) => ListBox_History.Items.Clear();
	}
}