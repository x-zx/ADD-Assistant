using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace ADD_Assistant
{
    public partial class Page9 : PhoneApplicationPage
    {
        public Page9()
        {
            InitializeComponent();
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            Version version = new System.Reflection.AssemblyName(System.Reflection.Assembly.GetExecutingAssembly().FullName).Version;
            MessageBox.Show("ADD Assistant "+version.ToString()+"\nAirForce Studio");
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            settings["UID"] = "";
            settings["Name"] = "";
            logout.IsEnabled = false;
            this.NavigationService.Navigate(new Uri("/Welcome.xaml", UriKind.Relative));
        }
    }
}