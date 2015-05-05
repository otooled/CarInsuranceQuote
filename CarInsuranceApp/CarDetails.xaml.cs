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
    public sealed partial class CarDetails : Page
    {
        private MobileServiceCollection<ServiceClass.ExistingVehicles> vhles;
        private IMobileServiceTable<ServiceClass.ExistingVehicles> ex_vhlesTable = App.MobileService.GetTable<ServiceClass.ExistingVehicles>();
        public CarDetails()
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
                var nav = (VehDetsNav)e.Parameter;
                tbkMake.Text = nav.Make.ToString();
                //tbkModel.Text = nav.Model.ToString();
                //tbkYear.Text = nav.Year.ToString();
               // tbkEng_size.Text = nav.Engine_Size.ToString();

            }
            catch
            {

            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            pgbCarDets.Value = 16;
           
        }

        private void btnGetCarDets_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var q = vhles.Where(a => a.Reg == tbxCarReg.Text.ToUpper()).FirstOrDefault();
                if (q.Reg == tbxCarReg.Text)
                {
                    tbkMake.Text = q.Make;
                    tbkModel.Text = q.Model;
                    tbkEng_size.Text = q.Eng_size.ToString();
                  
                }

                //var q = ex_vhlesTable.Where(a => a.Reg == tbxCarReg.Text.ToUpper());
                //    if(q. == tbxCarReg.Text)
                //        {
                //            tbkDisplayDets.Text = ;
                //        }
            }

                catch(Exception)
                {

                }
            //stkConfirmCarDets.Visibility = Visibility.Visible;
        }

        //private void btnConfirmDets_Click(object sender, RoutedEventArgs e)
        //{
        //    Frame.Navigate(typeof(DriverExpierence));
        //}

        //private void btnBack_Click(object sender, RoutedEventArgs e)
        //{
            
        //}

        private void hplCarReg_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(VehicleDetails));
        }

        private void btnBack_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DriverExpierence));
        }

        

      
    }
}
