using Carceres_Android.Models;
using Carceres_Android.Services.Maps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Maps
{
    public class InteractiveMapsViewModel : BaseViewModel
    {
        private Zone _selectedZone;
        public ObservableCollection<Zone> Zones { get; }
        public Command LoadZonesCommand { get; }

        public IMapsService<Zone> ZonesService => DependencyService.Get<IMapsService<Zone>>();

        public InteractiveMapsViewModel()
        {
            Title = "Mapa";
            Zones = new ObservableCollection<Zone>();
            LoadZonesCommand = new Command(ExecuteLoadZonesCommand);

        }

        public Zone SelectedZone
        {
            get => _selectedZone;
            set
            {
                if(_selectedZone != value)
                {
                    SetProperty(ref _selectedZone, value);
                    OnPropertyChanged();
                }
                
            }
        }

        private async void ExecuteLoadZonesCommand(object obj)
        {
            IsBusy = true;
            try
            {

                Zones.Clear();

                var task1 = ZonesService.GetZonesAsync();

                foreach (var zone in await task1)
                {
                    Zones.Add(zone);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            
        }
    }
}
