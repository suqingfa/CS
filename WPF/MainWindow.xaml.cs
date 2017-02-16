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

namespace WPF
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			listBox.Items.Add(new Book("C#", "Wrox Press"));
			listBox.Items.Add(new Book("HTML", "Wiley"));
			listBox.Items.Add(new Book("C++", "SU"));
		}
	}

	public class Book
	{
		public string Title { get; set; }
		public string Publisher { get; set; }
		public Book(string title, string publisher)
		{
			Title = title;
			Publisher = publisher;
		}
		public override string ToString()
		{
			return Title;
		}
	}
}
