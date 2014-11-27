using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.IO.IsolatedStorage;
using Newtonsoft.Json.Linq;

namespace ADD_Assistant
{
    public partial class Page5 : PhoneApplicationPage
    
    {
     
 
        public Page5()
        {
            InitializeComponent();
            

        }


        private void UserInf_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            JObject json = JObject.Parse(e.Result);

            settings["Name"] = (string)json["username"];
        }

        void Login_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            try
            {
                if (Int32.Parse(e.Result) > 0)
                {
                    settings["UID"] = Int32.Parse(e.Result);//将获取到的用户ID保存到本地

                    //获取用户信息
                    WebClient UserInf = new WebClient();
                    UserInf.DownloadStringCompleted += new DownloadStringCompletedEventHandler(UserInf_DownloadStringCompleted);
                    UserInf.DownloadStringAsync(new Uri("http://addassistant.sinaapp.com/api/get_userinfo.php?uid=" + settings["UID"], UriKind.Absolute));

                    //
                    this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

                }else
                {
                    MessageBox.Show("用户名或密码错误:(");
                    BtnOK.IsEnabled = true;
                }
                    
            }
            catch { MessageBox.Show("登陆失败:("); BtnOK.IsEnabled = true; }
           
           
        }




        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {

            if (USER.Text == "") { USER.Focus(); return; }
            if (PW.Password == "") { PW.Focus(); return; }

            USER.IsEnabled = false;
            PW.IsEnabled = false;
            BtnOK.IsEnabled = false;
            //
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            WebClient Login = new WebClient();
            //添加下载完成后的处理事件
            Login.DownloadStringCompleted += new DownloadStringCompletedEventHandler(Login_DownloadStringCompleted);

            //开始异步下载
            Login.DownloadStringAsync(new Uri("http://addassistant.sinaapp.com/api/signin.php?username=" + USER.Text + "&password=" + PW.Password, UriKind.Absolute));
            //
            USER.IsEnabled = true;
            PW.IsEnabled = true;
        }


        private void Name_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.PlatformKeyCode == 13) PW.Focus();

        }


        private void DemoAccount_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            USER.Text = "guest";
            PW.Password = "guest888";
        }



        private void PW_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.PlatformKeyCode == 13)
            {
                BtnOK_Click(this, e);
            }
        }

        private void reg_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Browser.xaml?url=http://addassistant.sinaapp.com/m/signup.php", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains("UID")) settings.Add("UID", "");//初始化UID
            if (!settings.Contains("Name")) settings.Add("Name", "");//初始化用户名字
        }


     







    }
}