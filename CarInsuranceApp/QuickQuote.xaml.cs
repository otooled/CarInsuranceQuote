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
    public sealed partial class QuickQuote : Page
    {
        public QuickQuote()
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
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            pgbQuickQuote.Value = 80;
            btnGetQuote.IsEnabled = false;
            
            Calculation clc = new Calculation()
            {
                county = GlobalVariables.countyRating
            };

        }

        private void btnGetQuote_Click(object sender, RoutedEventArgs e)
        {
            var qref = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            

            QuoteNav nav = new QuoteNav()
            {
                q_ref = qref
            };
            Frame.Navigate(typeof(QuoteDetails), nav);
        }

        private void cbxTerms_Checked(object sender, RoutedEventArgs e)
        {
            if (btnGetQuote.IsEnabled == false)
            {
                btnGetQuote.IsEnabled = true;
            }
            else
            {
                btnGetQuote.IsEnabled = false;
            }
        }

       

        //private void btnBack_Click(object sender, RoutedEventArgs e)
        //{
        //    Frame.Navigate(typeof(ConfirmDvrDets));
        //}
    }
}
