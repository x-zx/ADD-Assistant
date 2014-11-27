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
    
    public partial class Page1 : PhoneApplicationPage
    {

        int Goal = 1;
        long StartTime;
        long EndTime;


        private void NewGame()
        {
            List<int> list = new List<int>();
            Random rand = new Random();
            int Num;
            Goal = 1;

            while (true)
            {
                if (list.Count == 20) break;
                Num = rand.Next(1, 21);
                if (!list.Contains(Num))
                {
                    list.Add(Num);
                }
            }
            int n = 0;
            foreach (UIElement element in Boxs.Children)
            {
                if (element is Button)
                {
                    Button btn= ((Button)element);

                    btn.Content = list[n++];
                    btn.IsEnabled = true;
                }
            }
        }

        public Page1()
        {
            InitializeComponent();
            //计时器
            

            NewGame();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool IsNewGame = false;
            Button btn = (Button)sender;
            if (btn.Content.ToString() == Goal.ToString())
            {
                btn.IsEnabled = false;

                if (Goal == 1)
                {
                    StartTime = DateTime.Now.Ticks;
                }
                else if (Goal == 20)
                {
                    EndTime = DateTime.Now.Ticks;
                    double time = (double)(EndTime - StartTime) / 10000000;
                    double score = (50 - time) / 5;
                    MessageBox.Show("已完成:)\n用时: " + Math.Round(time, 2) + " 秒\n得分：" + Math.Round(score, 2));
                    NewGame();
                    IsNewGame = true;
                    //
                    IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
                    WebClient wb = new WebClient();
                    wb.DownloadStringAsync(new Uri("http://addassistant.sinaapp.com/api/game_update.php?uid=" + settings["UID"] + "&pt=" + Math.Round(score, 2), UriKind.Absolute));
                }

                if(IsNewGame==false)Goal++;
            }
        }
    }
}