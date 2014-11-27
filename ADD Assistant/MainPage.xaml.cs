using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ADD_Assistant.Resources;
using System.ComponentModel;
using System.IO.IsolatedStorage;

namespace ADD_Assistant
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
            this.BackKeyPress += (sender, e) =>
            {
            };  
        }




        private void NavigatGame(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Game1.xaml", UriKind.Relative));
           // this.NavigationService.Navigate(new Uri("/Read.xaml", UriKind.Relative));
            
        }

        private void NavigatRead(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/ArticleList.xaml#/Read.xaml?id=1#/ArticleList.xaml", UriKind.Relative));
        }

   

        private void NavigatInf(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MyInf.xaml", UriKind.Relative));
        }

        private void NavigatChart(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Chart.xaml", UriKind.Relative));
        }

        private void NavigatAch(object sender,RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Browser.xaml?url=http://addassistant.sinaapp.com/m/goal/", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains("UID"))
            {
                if (settings["UID"].ToString() == "") this.NavigationService.Navigate(new Uri("/Welcome.xaml", UriKind.Relative));
            }
            else { this.NavigationService.Navigate(new Uri("/Welcome.xaml", UriKind.Relative));}
           
        }

        private void NavigatSet(object sender, RoutedEventArgs e)
        {
            //IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            //settings.Remove("UID");
            this.NavigationService.Navigate(new Uri("/Setting.xaml", UriKind.Relative));
        }


        // 用于生成本地化 ApplicationBar 的示例代码
        //private void BuildLocalizedApplicationBar()
        //{
        //    // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
        //    ApplicationBar = new ApplicationBar();

        //    // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // 使用 AppResources 中的本地化字符串创建新菜单项。
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}