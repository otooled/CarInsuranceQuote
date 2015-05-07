using Microsoft.WindowsAzure.MobileServices;
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
    public sealed partial class RetrieveQuote : Page
    {
        private IMobileServiceTable<ServiceClass.Quote> quotes_table = App.MobileService.GetTable<ServiceClass.Quote>();

        public RetrieveQuote()
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
            if (tbkFname.Text == "" || tbkSname.Text == "" || tbxQuote.Text == "")
            {
                spinIcon.IsActive = false;
            }
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ContactUs));
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
           
        //}

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void btnQuoteRetrieval_Click(object sender, RoutedEventArgs e)
        {
           

            var qtes = await quotes_table.ToCollectionAsync();
            var q_t = qtes.ToList();
            try
            {
               // var q = q_t.Where(a => a.q_ref == tbxQuote.Text.to)
                var q = q_t.Where(a => a.q_ref == tbxQuote.Text.ToUpper()).FirstOrDefault();
                if (q != null)
                {
                    tbkFname.Text = q.f_name;
                    tbkSname.Text = q.sname;
                    tbkYourQuote.Text = q.q_price.ToString();

                }
                if (tbkFname.Text == "" || tbkSname.Text == "" || tbxQuote.Text == "")
                {
                    spinIcon.IsActive = true;
                }
                else
                {
                    spinIcon.IsActive = false;
                }

            }

            catch (Exception)
            {

            }
        }
    }
}
