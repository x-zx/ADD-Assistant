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
    public partial class Page7 : PhoneApplicationPage
    {
        public class ArtList
        {
            public string Title { get; set; }

            public string ID { get; set; }

        }


        public Page7()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            WebClient wb = new WebClient();
            //添加下载完成后的处理事件
            wb.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wb_DownloadStringCompleted);
            //开始异步下载
            //wb.DownloadStringAsync(new Uri("http://192.168.1.10/test.php", UriKind.Absolute));
            wb.DownloadStringAsync(new Uri("http://addassistant.sinaapp.com/api/get_article_list.php?uid=" + settings["UID"], UriKind.Absolute));

        }

        void wb_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            try {
                string[] strlist = e.Result.Split(',');

                List<ArtList> artlist = new List<ArtList>();

                for (int i = 0; i < strlist.Length; i++)
                {
                    //string Title = strlist[i].Split(':')[0];
                    //string ID = strlist[i].Split(':')[1];
                    artlist.Add(new ArtList { Title = strlist[i].Split(':')[1], ID = strlist[i].Split(':')[0] });
                }
                list.ItemsSource = artlist;
            }
                
            catch { this.NavigationService.GoBack(); }
            
        }

        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            this.NavigationService.Navigate(new Uri("/Read.xaml?id="+tb.Tag.ToString(), UriKind.Relative));
        }
    }
}