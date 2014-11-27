using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ADD_Assistant
{
    public partial class Page8 : PhoneApplicationPage
    {
        public Page8()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string URL = NavigationContext.QueryString["url"];
            web.Navigate(new Uri(URL, UriKind.Absolute));
        }

        private void web_Navigated(object sender, NavigationEventArgs e)
        {
            //MessageBox.Show(web.Source.AbsoluteUri);
            if (web.Source.AbsoluteUri.IndexOf("ok.php")>-1)
            {
                this.NavigationService.GoBack();//注册成功跳转
                MessageBox.Show("注册成功:)");
            }

            web.Visibility = Visibility.Visible;
        }

        private void web_Navigating(object sender, NavigatingEventArgs e)
        {
            //web.Visibility = Visibility.Collapsed;
        }

        private void web_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            web.Visibility = Visibility.Collapsed;
            this.NavigationService.GoBack();
        }
    }
}