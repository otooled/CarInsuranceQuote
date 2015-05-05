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
    public sealed partial class VehicleDetails : Page
    {
        private MobileServiceCollection<ServiceClass.CarMake> carMake;
        private IMobileServiceTable<ServiceClass.CarMake> cMake_table = App.MobileService.GetTable<ServiceClass.CarMake>();

        private MobileServiceCollection<ServiceClass.EngineSize> enSize;
        private IMobileServiceTable<ServiceClass.EngineSize> enSize_table = App.MobileService.GetTable<ServiceClass.EngineSize>();

        private MobileServiceCollection<ServiceClass.ManufactureYear> manYear;
        private IMobileServiceTable<ServiceClass.ManufactureYear> year_table = App.MobileService.GetTable<ServiceClass.ManufactureYear>();



        public VehicleDetails()
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
            pgbCarDets.Value = 16;            

            List<CarMake> carM = new List<CarMake>();

            var cMake = await cMake_table.ToCollectionAsync();
            var c = cMake.ToList();
            foreach (var items in cMake)
            {
                carM.Add(items);

            }
            cmbCarMake.DataContext = carM;

            List<EngineSize> e_size = new List<EngineSize>();
            var eSize = await enSize_table.ToCollectionAsync();
            var es = eSize.ToList();
            foreach(var items in eSize)
            {
                e_size.Add(items);
            }
            cmbEngSize.DataContext = e_size;

            List<ManufactureYear> man_year = new List<ManufactureYear>();
            var year = await year_table.ToCollectionAsync();
            var m_y = year.ToList();
            foreach(var items in year)
            {
                man_year.Add(items);
            }
            cmbYear.DataContext = man_year;
        }

        private void btnVDNext_Click(object sender, RoutedEventArgs e)
        {
            
                VehDetsNav nav = new VehDetsNav()
                {
                    Make = cmbCarMake.SelectedValue.ToString(),
                    //Model = cmbCarModel.SelectedIndex.ToString(),
                    //Year = Convert.ToInt32(cmbYear.SelectedValue),
                   // Engine_Size = Convert.ToDouble(cmbEngSize.SelectedValue)
                    
                };

                
            
            Frame.Navigate(typeof(CarDetails), nav);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CarDetails));
        }

        private void btnNoListing_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ContactUs));
        }

       
    }
}
