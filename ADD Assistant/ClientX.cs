using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;//

namespace ADD_Assistant
{
    public class ClientX
    {


  
        public void Upload(string str)
        {
            WebClient wc = new WebClient();
            var URI = new Uri("http://localhost/");
            //If any encoding is needed.
            wc.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            //Or any other encoding type.
            //If any key needed
            wc.Headers["KEY"] = "Your_Key_Goes_Here";
            wc.UploadStringCompleted += new UploadStringCompletedEventHandler(wc_UploadStringCompleted);
            wc.UploadStringAsync(URI, "POST", "Data_To_Be_sent");
        }
        public void wc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            try
            {
                MessageBox.Show(e.Result);
                //e.result fetches you the response against your POST request.
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}


