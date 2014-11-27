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
using Newtonsoft.Json.Linq;

namespace ADD_Assistant
{
    public partial class Page6 : PhoneApplicationPage
    {
        public Page6()
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
            wb.DownloadStringAsync(new Uri("http://addassistant.sinaapp.com/api/get_userinfo.php?uid=" + settings["UID"], UriKind.Absolute));
        }

        void wb_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            try
            {
                JObject json = JObject.Parse(e.Result);

                settings["Name"] = (string)json["username"];
                INFTXT.Text = "名字：" + (string)json["username"] + "\n性别：" + (string)json["gender"] + "\n年龄：" + (string)json["age"] + "\n学校：" + (string)json["school"] + "\n积分：" + (string)json["prt_set"];
            }

            catch { this.NavigationService.GoBack(); }

            


        }
    }

  
}