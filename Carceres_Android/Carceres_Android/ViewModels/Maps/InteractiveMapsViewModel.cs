using Carceres_Android.Models;
using Carceres_Android.Services.Maps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Maps
{
    public class InteractiveMapsViewModel : BaseViewModel
    {
        private Zone _selectedZone;
        public ObservableCollection<Zone> Zones { get; }
        public Command LoadZonesCommand { get; }
        public AbsoluteLayout absl  = new AbsoluteLayout();
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
                SelectedZone = Zones[0];               

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
        public void UpdatePins()
        {
            absl.Children.Clear();
            foreach (var place in SelectedZone.places)
            {
                
                RelativeLayout rel = new RelativeLayout();
                Image image = new Image();
                if(place.occupied) image.Source = "pin_blue.png";
                else image.Source = "pin_green.png";
                rel.Children.Add(image, Constraint.Constant(place.pos_x*4.8), Constraint.Constant(place.pos_y*4.9));
                absl.Children.Add(rel);
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            
            
        }
    }
}
