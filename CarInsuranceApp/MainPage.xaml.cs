﻿using CarInsuranceApp.ServiceClass;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Email;
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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace CarInsuranceApp
{
   
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MobileServiceCollection<ServiceClass.Counties> counties;
        private IMobileServiceTable<ServiceClass.Counties> counties_table = App.MobileService.GetTable<ServiceClass.Counties>();

        private MobileServiceCollection<ServiceClass.CoverType> covTyp;
        private IMobileServiceTable<ServiceClass.CoverType> covTyp_table = App.MobileService.GetTable<ServiceClass.CoverType>();
        
        
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Counties> cties = new List<Counties>();

            var loc = await counties_table.ToCollectionAsync();
            var c = loc.ToList();
            foreach (var items in loc)
            {
                cties.Add(items);
                    
            }
            cmbVehicleLoc.DataContext = cties;

            List<CoverType> cvrTyp = new List<CoverType>();
            var type = await covTyp_table.ToCollectionAsync();
            var ct = type.ToList();
            foreach (var items in type)
            {
                cvrTyp.Add(items);
            }

            cmbCoverType.DataContext = cvrTyp;

            if(cmbVehicleLoc != null  )
            {
                spinIcon.IsActive = false;
            }

            if (cmbVehicleLoc != null)
            {
                spinIcon.IsActive = false;
            }

            //Counties a = new Counties { Name = "Sligo", Premium = 3 };
            //await counties_table.InsertAsync(a);
          
            
           
        }

       

        private void btnRetrieve_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RetrieveQuote));
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (cmbCoverType.SelectedValue == null)
            {
                MessageDialog msg = new MessageDialog("Cover type must be selected");
                msg.ShowAsync();
                return;
            }

            if (cmbVehicleLoc.SelectedValue == null)
            {
                MessageDialog msg = new MessageDialog("A location must be selected");
                msg.ShowAsync();
                return;
            }

            //MainPageNav nav = new MainPageNav()
            //{
            //    coverType = cmbCoverType.SelectedValue.ToString(),
            //    location = cmbVehicleLoc.SelectedValue.ToString()

            //};
            try
            {
                Counties c = (Counties)cmbVehicleLoc.SelectedItem;                 
                GlobalVariables.countyRating = c.Premium;//Convert.ToInt32(cmbVehicleLoc.SelectedValue);
                

                CoverType ct = (CoverType)cmbCoverType.SelectedItem;
                GlobalVariables.coverRating = ct.CoverTypeValue;
            }
            catch { }
            Frame.Navigate(typeof(CarDetails));
        }

        

         
    }
}
