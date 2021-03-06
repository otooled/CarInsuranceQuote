﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Email;
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
    public sealed partial class QuoteDetails : Page
    {
        public QuoteDetails()
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
            var nav = (QuoteNav)e.Parameter;
            tbkDisplayQuoteRef.Text = nav.q_ref;
            tbkDisplayQuote.Text = nav.q_price.ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            pgbQuoteDetails.Value = 100;

            tbkMake.Text = GlobalVariables.car_make;
            tbkModel.Text = GlobalVariables.car_model;
            tbkYear.Text = GlobalVariables.carYear.ToString();
            
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
           // EmailRecipient sendTo = new EmailRecipient()

        //    {


        //        Address = "otoole0david@gmail.com"

        //    };
        //    //predefine Recipient


        //    //generate mail object

        //    EmailMessage mail = new EmailMessage();

        //    mail.Subject = "this is the Subject";


        //    mail.Body = "this is the Body";



        //    //add recipients to the mail object

        //    mail.To.Add(sendTo);

        //    //mail.Bcc.Add(sendTo);
        //    //mail.CC.Add(sendTo);
        //    //open the share contract with Mail only:

        //    await EmailManager.ShowComposeNewEmailAsync(mail);
        //}
            Frame.Navigate(typeof(MainPage));
        }

       
    }
}
