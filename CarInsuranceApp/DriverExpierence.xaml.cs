using CarInsuranceApp.ServiceClass;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class DriverExpierence : Page
    {
       
        private MobileServiceCollection<ServiceClass.NoOfClaims> claims;
        private IMobileServiceTable<ServiceClass.NoOfClaims> clm_table = App.MobileService.GetTable<ServiceClass.NoOfClaims>();

        private MobileServiceCollection<ServiceClass.PenPoints> points;
        private IMobileServiceTable<ServiceClass.PenPoints> pnts_table = App.MobileService.GetTable<ServiceClass.PenPoints>();

        //private MobileServiceCollection<ServiceClass.LicenceType> license;
        //private IMobileServiceTable<ServiceClass.LicenceType> License_table = App.MobileService.GetTable<ServiceClass.LicenceType>();
        private MobileServiceCollection<ServiceClass.LicenceType> license;
        private IMobileServiceTable<ServiceClass.LicenceType> License_table = App.MobileService.GetTable<ServiceClass.LicenceType>();
        

        public DriverExpierence()
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

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            pgbDriverExpierence.Value = 32;

            List<NoOfClaims> num_claims = new List<NoOfClaims>();

            var no_claims = await clm_table.ToCollectionAsync();
            var noc = no_claims.ToList();
            foreach (var items in no_claims)
            {
                num_claims.Add(items);
            }

            cmbNoOfClaims.DataContext = num_claims;


            List<PenPoints> pn_pnts = new List<PenPoints>();

            var pp = await pnts_table.ToCollectionAsync();
            var pnPnts = pp.ToList();

            foreach(var items in pp)
            {
                pn_pnts.Add(items);
            }
            cmbNoOfPenalty.DataContext = pn_pnts;

            //List<LicenceType> lce_ty = new List<LicenceType>();

            //var lt = await License_table.ToCollectionAsync();
            //var lceTy = lt.ToList();

            //foreach (var items in lt)
            //{
            //    lce_ty.Add(items);
            //}

            //cmbLicence.DataContext = lce_ty;

            //List<LicenceType> lt = new List<LicenceType>();

            //var l_t = await License_table.ToCollectionAsync();
            //var lnc_ty = l_t.ToList();

            //foreach (var items in l_t)
            //{
            //    lt.Add(items);
            //}
            //cmbLicence.DataContext = lt;
                 
            if (cmbNoOfClaims != null)
            {
                spinIcon.IsActive = false;
            }

            if (cmbNoOfPenalty != null)
            {
                spinIcon.IsActive = false;
            }
        
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (cmbNoOfClaims.SelectedValue == null || cmbNoOfPenalty.SelectedValue == null)
            {
                MessageDialog msg = new MessageDialog("Both options must be selected");
                msg.ShowAsync();
                return;
            }  

            NoOfClaims noc = (NoOfClaims)cmbNoOfClaims.SelectedItem;
            GlobalVariables.noOfClaims = noc.ClaimsNum;

            PenPoints pp = (PenPoints)cmbNoOfPenalty.SelectedItem;
            GlobalVariables.penPoints = pp.NumOfPoints;

           

            Frame.Navigate(typeof(DriverDetails));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CarDetails));
        }
    }
}
