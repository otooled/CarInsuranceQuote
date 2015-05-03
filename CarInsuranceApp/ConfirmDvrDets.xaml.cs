using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace CarInsuranceApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConfirmDvrDets : Page
    {
        public ConfirmDvrDets()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var nav = (DriverDetailsNav)e.Parameter;
            tbkFname.Text = nav.fName;
            tbkSname.Text = nav.sName;
            tbkEmail.Text = nav.email;
            tbxAge.Text = nav.age.ToString();
        }

        private void btnConDvrDetsNo_Click(object sender, RoutedEventArgs e)
        {
            DriverDetailsNav nav = new DriverDetailsNav()
            {
                fName = tbkFname.Text,
                sName = tbkSname.Text,
                email = tbkEmail.Text,
                age = Convert.ToInt16(tbxAge.Text)
            };

            //Frame.Navigate(typeof(ConfirmDvrDets), nav);
            Frame.Navigate(typeof(DriverDetails), nav);
            //Frame.GoBack(typeof(DriverDetails), nav.fName);
        }

        private void btnConDvrDetsYes_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(QuickQuote));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            pgbConDrvDets.Value = 64;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
            //Frame.Navigate(typeof(DriverDetails));
        }
    }
}
