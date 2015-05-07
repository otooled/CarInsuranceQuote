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
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
           

            try
            {
                var nav = (VehDetsNav)e.Parameter;
                tbkMake.Text = nav.Make.ToString();
                //tbkModel.Text = nav.Model.ToString();
                tbkYear.Text = nav.Year.ToString();
                tbkEng_size.Text = nav.Engine_Size.ToString();
                if(nav != null)
                {
                    tbkConfirmTitle.Visibility = Visibility.Visible;

                    tbkMakeTitle.Visibility = Visibility.Visible;
                    bdrMake.Visibility = Visibility.Visible;
                    tbkMake.Visibility = Visibility.Visible;

                    tbkModelTitle.Visibility = Visibility.Visible;
                    bdrModel.Visibility = Visibility.Visible;
                    tbkModel.Visibility = Visibility.Visible;

                    tbkEngineTitle.Visibility = Visibility.Visible;
                    tbkEng_size.Visibility = Visibility.Visible;
                    bdrEngine.Visibility = Visibility.Visible;

                    tbkYearTitle.Visibility = Visibility.Visible;
                    bdrYear.Visibility = Visibility.Visible;
                    tbkYear.Visibility = Visibility.Visible;

                    tbkContinueTitle.Visibility = Visibility.Visible;
                    btnBack.Visibility = Visibility.Visible;
                    btnNext.Visibility = Visibility.Visible;
                }

            }
            catch
            {

            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            pgbCarDets.Value = 16;

            if (tbkMake.Text == "")
            {
                spinIcon.IsActive = false;
            }

            if (tbkModel.Text == "")
            {
                spinIcon.IsActive = false;
            }
            if (tbkYear.Text == "")
            {
                spinIcon.IsActive = false;
            }
            if (tbkEng_size.Text == "")
            {
                spinIcon.IsActive = false;
            }
           
        }

        private async void btnGetCarDets_Click(object sender, RoutedEventArgs e)
        {
            var cMake = await ex_vhlesTable.ToCollectionAsync();
            var c = cMake.ToList();
            try
            {

                var q =c.Where(a => a.Reg == tbxCarReg.Text.ToUpper()).FirstOrDefault();
                if  (q != null)
                {
                    tbkMake.Text = q.Make;
                    tbkModel.Text = q.Model;
                    tbkEng_size.Text = q.Eng_size.ToString();
                    tbkYear.Text = q.Year.ToString();

                    tbkConfirmTitle.Visibility = Visibility.Visible;

                    tbkMakeTitle.Visibility = Visibility.Visible;
                    bdrMake.Visibility = Visibility.Visible;
                    tbkMake.Visibility = Visibility.Visible;

                    tbkModelTitle.Visibility = Visibility.Visible;
                    bdrModel.Visibility = Visibility.Visible;
                    tbkModel.Visibility = Visibility.Visible;

                    tbkEngineTitle.Visibility = Visibility.Visible;
                    tbkEng_size.Visibility = Visibility.Visible;
                    bdrEngine.Visibility = Visibility.Visible;

                    tbkYearTitle.Visibility = Visibility.Visible;
                    bdrYear.Visibility = Visibility.Visible;
                    tbkYear.Visibility = Visibility.Visible;

                    tbkContinueTitle.Visibility = Visibility.Visible;
                    btnBack.Visibility = Visibility.Visible;
                    btnNext.Visibility = Visibility.Visible;                    
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
            try
            {
                //CarDetails cy = Convert.ToInt32(tbkYear.Text);
                GlobalVariables.carYear = Convert.ToInt32(tbkYear.Text);
                GlobalVariables.eng_size = Convert.ToDouble(tbkEng_size.Text);
                GlobalVariables.car_make = tbkMake.Text;

                GlobalVariables.car_model = tbkModel.Text;
            }
            catch { }

            if (tbkMake.Text == "")
            {
                spinIcon.IsActive = true;
            }

            if (tbkModel.Text == "")
            {
                spinIcon.IsActive = true;
            }
            if (tbkYear.Text == "")
            {
                spinIcon.IsActive = true;
            }
            if (tbkEng_size.Text == "")
            {
                spinIcon.IsActive = true;
            }

            Frame.Navigate(typeof(DriverExpierence));
        }

        

      
    }
}
