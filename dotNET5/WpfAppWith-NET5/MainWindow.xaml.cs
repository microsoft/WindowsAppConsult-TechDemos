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

namespace WpfAppWith_NET5
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private async void btnGetGeoLocation_Click(object sender, RoutedEventArgs e)
		{
			Windows.Devices.Geolocation.Geolocator gl = new Windows.Devices.Geolocation.Geolocator();
			Windows.Devices.Geolocation.Geoposition gp = await gl.GetGeopositionAsync();
			tbGeolocation.Text = $"My location is lat={gp.Coordinate.Latitude}, long={gp.Coordinate.Longitude}";
		}
	}
}
