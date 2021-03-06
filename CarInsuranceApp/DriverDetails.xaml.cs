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
using Windows.UI.Popups;
using System.Text.RegularExpressions;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace CarInsuranceApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DriverDetails : Page
    {
        
        public DriverDetails()
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
            try
            {
                var nav = (DriverDetailsNav)e.Parameter;
                tbxFname.Text = nav.fName;
                tbxSname.Text = nav.sName;
                tbxEmail.Text = nav.email;
                tbxAge.Text = nav.age.ToString();
                
            }
            catch
            {
                //tbxFname.Text = "";

            }
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            pgbDriverDetails.Value = 48;

        }

        private void btnDDNext_Click(object sender, RoutedEventArgs e)
        {
           

            if(string.IsNullOrWhiteSpace(tbxFname.Text))
            {
                MessageDialog msg = new MessageDialog("First name must be entered");
                msg.ShowAsync();
                return;
            }
            if (string.IsNullOrWhiteSpace(tbxSname.Text))
            {
                MessageDialog msg = new MessageDialog("Surname must be entered");
                msg.ShowAsync();
                return;
            }

            if (Convert.ToInt32(tbxAge.Text) < 18 || Convert.ToInt32(tbxAge.Text) >80)
            {
                MessageDialog msg = new MessageDialog("Customer must be between 18 and 80");
                msg.ShowAsync();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbxAge.Text))
            {
                MessageDialog msg = new MessageDialog("Age must be entered");
                msg.ShowAsync();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbxEmail.Text))
            {
                MessageDialog msg = new MessageDialog("Email must be entered");
                msg.ShowAsync();
                return;
            }
            DriverDetailsNav nav = new DriverDetailsNav()
            {
                fName = tbxFname.Text,
                sName = tbxSname.Text,
                age = Convert.ToInt16(tbxAge.Text),
                email = tbxEmail.Text
            };

            GlobalVariables.f_name = tbxFname.Text;
            GlobalVariables.sname = tbxSname.Text;
            GlobalVariables.age = Convert.ToInt32(tbxAge.Text);

            Match match = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(tbxEmail.Text);

            if (match.Success == false)
            {
                MessageDialog msg = new MessageDialog("Invalid Email");
                msg.ShowAsync();
                return;               
            }
           

            Frame.Navigate(typeof(ConfirmDvrDets), nav);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DriverExpierence));
        }

       

        
    }
}
