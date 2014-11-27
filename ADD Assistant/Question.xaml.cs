using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json.Linq;
using System.IO.IsolatedStorage;

namespace ADD_Assistant
{
    public partial class Page3 : PhoneApplicationPage
    {
        public Page3()
        {
            InitializeComponent();
            this.BackKeyPress += (sender, e) =>
            {
                e.Cancel = true;
            };  
        }
        string QID = "";
        int QN = 1;
        string stringtmp = "";
        int CorrectCount = 0;
        int ErrorCount = 0;
        int words = 0;
        double time = 0;
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            QID = NavigationContext.QueryString["id"];
            words = int.Parse(NavigationContext.QueryString["words"]);
            time = double.Parse(NavigationContext.QueryString["time"]);
            WebClient wb = new WebClient();
            //添加下载完成后的处理事件
            wb.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wb_DownloadStringCompleted);
            //开始异步下载
            //wb.DownloadStringAsync(new Uri("http://192.168.1.10/test.php", UriKind.Absolute));
            wb.DownloadStringAsync(new Uri("http://addassistant.sinaapp.com/api/question.php?atc_id=" + QID, UriKind.Absolute));

        }

        void wb_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            stringtmp = e.Result;
            QText.Text = stringtmp;

            JObject json = JObject.Parse(stringtmp);
            if((string)json["Q1"]["question"]=="")
            {
                CorrectCount = 1;
                QN = 1;
                UpScore();
            }
            QText.Text = (string)json["Q" + QN]["question"];
            A1.Content = (string)json["Q" + QN]["a1"];
            A2.Content = (string)json["Q" + QN]["a2"];
            A3.Content = (string)json["Q" + QN]["a3"];
            A4.Content = (string)json["Q" + QN]["a4"];

            A1.Visibility = Visibility.Visible;
            A2.Visibility = Visibility.Visible;
            A3.Visibility = Visibility.Visible;
            A4.Visibility = Visibility.Visible;

            Btn_Next.Visibility = Visibility.Visible;
    

        }

        private void UpScore()
        {
            double score = Math.Round(((double)CorrectCount / QN) * (words / time)/10, 2);
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            WebClient wbup = new WebClient();
            wbup.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wbup_DownloadStringCompleted);
            wbup.DownloadStringAsync(new Uri("http://addassistant.sinaapp.com/api/reading_update.php?uid=" + settings["UID"] + "&pt=" + score.ToString(), UriKind.Absolute));
            MessageBox.Show("阅读完成！本次阅读得分："+score.ToString());
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
        private void Next(object sender, RoutedEventArgs e)
        {
            Btn_Next.IsEnabled = false;

            JObject json = JObject.Parse(stringtmp);
            //判断是否正确
            bool pass = false;
            if ((bool)A1.IsChecked && (string)json["Q" + QN]["key"] == "1") pass = true;
            if ((bool)A2.IsChecked && (string)json["Q" + QN]["key"] == "2") pass = true;
            if ((bool)A3.IsChecked && (string)json["Q" + QN]["key"] == "3") pass = true;
            if ((bool)A4.IsChecked && (string)json["Q" + QN]["key"] == "4") pass = true;
            if (pass) CorrectCount++; else ErrorCount++;


            QN++;
            //答题完成后上传
            if((string)json["Q" + QN]["question"]==""||QN==5)
            {
                UpScore();
            }
            else
            {
                //加载下一题
                QText.Text = (string)json["Q" + QN]["question"];
                A1.Content = (string)json["Q" + QN]["a1"];
                A2.Content = (string)json["Q" + QN]["a2"];
                A3.Content = (string)json["Q" + QN]["a3"];
                A4.Content = (string)json["Q" + QN]["a4"];
                A1.IsChecked = true;
                Btn_Next.IsEnabled = true;
            }
            
        }

         void wbup_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
             //阅读数据上传完成
            Btn_Next.IsEnabled = true;
        }
    }
}