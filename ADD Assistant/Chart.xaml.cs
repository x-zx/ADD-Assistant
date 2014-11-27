using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;

namespace ADD_Assistant
{
    public partial class Page4 : PhoneApplicationPage
    {
        string[] s1 = new string[7];
        string[] s2 = new string[7];
        double[] v1 = new double[7];
        double[] v2 = new double[7];

        public Page4()
        {
            InitializeComponent();
        }

        private ObservableCollection<TestDataItem> _data = new ObservableCollection<TestDataItem>()  
        {  
            new TestDataItem() { cat1 = "过去", val1=0},  
            new TestDataItem() { cat1 = ".", val1=0},  
            new TestDataItem() { cat1 = ".", val1=0},  
            new TestDataItem() { cat1 = ".", val1=0},  
            new TestDataItem() { cat1 = ".", val1=0},  
            new TestDataItem() { cat1 = ".", val1=0},  
            new TestDataItem() { cat1 = "现在", val1=0},  
 
 
        };

        public ObservableCollection<TestDataItem> Data { get { return _data; } }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;

            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            WebClient wb1 = new WebClient();
            WebClient wb2 = new WebClient();
            //添加下载完成后的处理事件
            wb1.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wb1_DownloadStringCompleted);
            wb2.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wb2_DownloadStringCompleted);
            //开始异步下载
            //wb.DownloadStringAsync(new Uri("http://192.168.1.10/test.php", UriKind.Absolute));
            wb1.DownloadStringAsync(new Uri("http://addassistant.sinaapp.com/api/rd_get_pts.php?uid=" + settings["UID"], UriKind.Absolute));
            wb2.DownloadStringAsync(new Uri("http://addassistant.sinaapp.com/api/gm_get_pts.php?uid=" + settings["UID"], UriKind.Absolute));
        }

        void wb1_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            try 
            { 
                s1 = e.Result.Split(',');
                for (int i = 0; i < 7; i++) { v1[i] = double.Parse(s1[i]); }
                ViewChart();
            }

            catch{ this.NavigationService.GoBack(); }
            
            
        }

        void wb2_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            try
            {
                s2 = e.Result.Split(',');
                for (int i = 0; i < 7; i++) { v2[i] = double.Parse(s2[i]); }
            }

            catch { this.NavigationService.GoBack(); }

        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(pivot.SelectedIndex==0)
            {
                _data.Clear();
                _data.Add(new TestDataItem() { cat1 = "过去", val1 =v1[0]});
                _data.Add(new TestDataItem() { cat1 = ".", val1 = v1[1]});
                _data.Add(new TestDataItem() { cat1 = ".", val1 = v1[2]});
                _data.Add(new TestDataItem() { cat1 = ".", val1 = v1[3]});
                _data.Add(new TestDataItem() { cat1 = ".", val1 = v1[4]});
                _data.Add(new TestDataItem() { cat1 = ".", val1 = v1[5]});
                _data.Add(new TestDataItem() { cat1 = "现在", val1 = v1[6]});  
            }
            else
            {
                _data.Clear();
                _data.Add(new TestDataItem() { cat1 = "过去", val1 = v2[0]});
                _data.Add(new TestDataItem() { cat1 = ".", val1 = v2[1]});
                _data.Add(new TestDataItem() { cat1 = ".", val1 = v2[2]});
                _data.Add(new TestDataItem() { cat1 = ".", val1 = v2[3]});
                _data.Add(new TestDataItem() { cat1 = ".", val1 = v2[4]});
                _data.Add(new TestDataItem() { cat1 = ".", val1 = v2[5]});
                _data.Add(new TestDataItem() { cat1 = "现在", val1 = v2[6]});  
            };
        }

        private void ViewChart()
        {
            _data.Clear();
            _data.Add(new TestDataItem() { cat1 = "过去", val1 = v1[0], val2 = 15, val3 = 10 });
            _data.Add(new TestDataItem() { cat1 = ".", val1 = v1[1], val2 = 1.5, val3 = 10 });
            _data.Add(new TestDataItem() { cat1 = ".", val1 = v1[2], val2 = 5, val3 = 10 });
            _data.Add(new TestDataItem() { cat1 = ".", val1 = v1[3], val2 = 1, val3 = 10 });
            _data.Add(new TestDataItem() { cat1 = ".", val1 = v1[4], val2 = 1, val3 = 10 });
            _data.Add(new TestDataItem() { cat1 = ".", val1 = v1[5], val2 = 1, val3 = 10 });
            _data.Add(new TestDataItem() { cat1 = "现在", val1 = v1[6], val2 = 4, val3 = 10 });
        }

    }

    public class TestDataItem
    {
        public string cat1 { get; set; }
        public double val1 { get; set; }
        public double val2 { get; set; }
        public decimal val3 { get; set; }
    }  

}