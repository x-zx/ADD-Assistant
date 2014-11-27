using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Threading;
using Newtonsoft.Json.Linq;
using System.IO.IsolatedStorage;


namespace ADD_Assistant
{
    public partial class Page2 : PhoneApplicationPage
    {
        long StartTime;
        long EndTime;
        double time;
        int words = 0;
        public Page2()
        {
            InitializeComponent();
            //DispatcherTimer timer;
            //timer = new DispatcherTimer();
            //timer.Tick += (ss, ee) => { if (SV.VerticalOffset > SV.ActualHeight)BtnOK.Visibility = Visibility.Visible; };
            //timer.Interval = TimeSpan.FromMilliseconds(100);
            //timer.Start();
            //
            this.BackKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                //ShellToast toast = new ShellToast();
                //toast.Title = "ADD Assistant";
                //toast.Content = "阅读过程中不能返回哦";
                //toast.Show();
                MessageBox.Show("阅读过程中不能退出哦！");
            };  
            
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string TextID = NavigationContext.QueryString["id"];

            this.NavigationService.Navigate(new Uri("/Question.xaml?id=" + TextID + "&words=" + words + "&time=" + time, UriKind.Relative));
        }


        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string TextID = NavigationContext.QueryString["id"];

            WebClient wb = new WebClient();
            //添加下载完成后的处理事件
            wb.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wb_DownloadStringCompleted);
            //开始异步下载
            //wb.DownloadStringAsync(new Uri("http://192.168.1.10/test.php", UriKind.Absolute));
            wb.DownloadStringAsync(new Uri("http://addassistant.sinaapp.com/api/get_article_body.php?atc_id=" + TextID, UriKind.Absolute));
        }

        void wb_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
           
            JObject json = JObject.Parse(e.Result);

            title.Text = (string)json["title"];
            txt.Text = (string)json["body"];
            words = txt.Text.Length;
            txt.Text+="\r\n\t[双击结束阅读]";
            
            StartTime = DateTime.Now.Ticks;
        }

        private void txt_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            EndTime = DateTime.Now.Ticks;
            time = (double)(EndTime - StartTime) / 10000000;
            txt.Text = "\t祝贺你，" + settings["Name"] +"！\r\n\t你已经读完了：\r\n\t\t《" + title.Text + "》\r\n\t本文章字数：" + words + "字\r\n\t阅读用时：" + Math.Round(time, 2) + " 秒\r\n";
            title.Text = "^-^";
            BtnOK.Visibility = Visibility.Visible;
            string TextID = NavigationContext.QueryString["id"];

            //this.NavigationService.Navigate(new Uri("/Question.xaml?id=" + TextID +"&words="+words+"&time="+time, UriKind.Relative));
        }

    }
}