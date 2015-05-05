using CarInsuranceApp.ServiceClass;
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
    public sealed partial class QuickQuote : Page
    {
        
        private IMobileServiceTable<ServiceClass.Quote> quotes_table = App.MobileService.GetTable<ServiceClass.Quote>();
        
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
            
            

        }

        private async void btnGetQuote_Click(object sender, RoutedEventArgs e)
        {
            double totalQuoteCost = 300;

            var qref = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            

            

            Calculation clc = new Calculation()
            {
                county = GlobalVariables.countyRating,
                cover_type = GlobalVariables.coverRating,
                no_of_claims = GlobalVariables.noOfClaims,
                pen_points = GlobalVariables.penPoints,
                year = GlobalVariables.carYear,
                eng_size = GlobalVariables.eng_size,
                age = GlobalVariables.age
            };

            if (clc.age < 25 && clc.eng_size >1.3)
            {
                totalQuoteCost = totalQuoteCost + 350;
                
            }

            QuoteNav nav = new QuoteNav()
            {
                q_ref = qref,
                q_price = totalQuoteCost

            };
            Frame.Navigate(typeof(QuoteDetails), nav);

            Quote q = new Quote { q_ref = qref, f_name = GlobalVariables.f_name, sname = GlobalVariables.sname, q_price = totalQuoteCost };
            await quotes_table.InsertAsync(q);
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
