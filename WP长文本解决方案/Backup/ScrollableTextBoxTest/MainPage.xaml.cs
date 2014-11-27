using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace ScrollableTextBoxTest
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            string text = @"We're reporting live from the San Francisco Museum of Modern Art, where Google's just taken the wraps off its latest software product. The announcement itself is taking its time right now, with background facts like Google recently crossing the one billion users a week milestone, but the Google Instant service has been activated and you can see details about its immediate result delivery at the source below. Basically, the Goog no longer waits for you to hit enter while searching and starts updating its results page Instantly as you type. Google describes it as a fundamental shift in seach and you can see its warm and fuzzy video introduction after the break. Google Instant isn't yet available for mobile, but the plan is to release it soon. " + "\r\n";
            text += " The service is rolling out right now to signed-in users -- some of us even got to use it ahead of the announcement -- but it's pretty much a question of luck as to when you might get it over the next few days. The UK, France, Germany, Italy, Russia, and Spain join the United States as the first countries to benefit from this new hotness, while Chrome, Firefox, Safari, and Internet Explorer 8 are the first supported browsers. Boom! One press of the 'w' key brought up local weather results instantaneously. Google's also integrated a predictive algorithm into Instant, which it describes as a physic element ... in that we're able to predict what you're going to type. Google becomes search before you type. Scroll to search is another touted feature, whereby going up or down through the suggested dropbox searches (as in the image above) also automatically updates your results in line with the suggestion you've got highlighted. One curious side note: there's an ever-growing counter on the side of the stage, which just crossed the 20,000 mark. Our suspicion is that's the number of Google Instant search users active so far. Or maybe it's something even more awesome, who knows! Ooh, the mobile version is coming this fall. We've lifted the testing address for the mob version from their presentation. Hit it up here to check it out for yourself. The best quote we can leave you with from here is the following: search is fast, Google Instant's even faster. With Intel showing signs of jumping on board, USB 3.0 is looking more and more like the one next-gen interconnect to rule them all. Them all except for Apple, of course, who has notably thrown its support exclusively behind Light Peak. The chums at Cupertino have no interest in newer, bluer revisions of USB, but enterprise storage firm CalDigit thinks that many Apple lovers will. It has developed USB 3.0 PCIe and ExpressCard adapters (plus the necessary drivers) that will bring 5Gbps transfers to Macs, and is releasing its CalDigit AV Drive to match, up to 2TB of external storage with 145MBps transfers. (It also sports FireWire 800 compatibility if you're not ready to cross the interface picket line just yet.) That PCIe adapter will set you back a not entirely unreasonable $59, while the 1TB external drive is $199. No price on the ExpressCard adapter or 2TB version yet, but all are said to be shipping presently.";
            text += @"Last month we released a beta of the Microsoft Web Farm Framework. The Microsoft Web Farm Framework is a free product we are shipping that enables you to easily provision and mange a farm of web servers.  It enables you to automate the installation and configuration of platform components across the server farm, and enables you to automatically synchronize and deploy ASP.NET applications across them.  It also supports integration with load balancers - and enables you to automate updates across your servers so that your site/application is never down or unavailable to customers (it can automatically pull servers one-at-a-time out of the load balancer rotation, update them, and then inject them back into rotation).";
            text += " Administrators and developers managing a web farm today often perform a lot of manual steps to do the above (which is error prone and dangerous), or write a lot of custom scripts to automate it (which is time consuming and hard).  Adding new servers or making configuring or application changes can often be painful and time-consuming.";
            scrollableTextBlock1.Text = text;

        }
    }
}