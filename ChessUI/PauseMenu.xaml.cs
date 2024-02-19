using System;
using System.Collections.Generic;
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

namespace ChessUI
{
	/// <summary>
	/// Interaction logic for PauseGame.xaml
	/// </summary>
	public partial class PauseGame : UserControl
	{
		public event Action<Option> OptionSelected;
		public PauseGame()
		{
			InitializeComponent();
		}

		private void Continue_Click(object sender, RoutedEventArgs e)
		{
			OptionSelected?.Invoke(Option.Continue);
        }

		private void Restart_Click(object sender, RoutedEventArgs e)
		{
			OptionSelected?.Invoke(Option.Restart);	
		}
	}
}
