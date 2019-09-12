using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using TrackMyWalks.Models;
using System.Threading.Tasks;
using TrackMyWalks.Services;
using Xamarin.Forms;

namespace TrackMyWalks.ViewModels 
{
    class WalksPageViewModel : WalkBaseViewModel
    {
        ObservableCollection<WalkEntries> _walkEntries;

        public ObservableCollection<WalkEntries> walkEntries
        {
            get { return _walkEntries; }
            set { _walkEntries = value;
                OnPropertyChanged();
            }
        }

        public WalksPageViewModel(IWalkNavService navService) : base(navService)
        {
            walkEntries = new ObservableCollection<WalkEntries>();
        }
        public override async Task Init()
        {
            await LoadWalkDetails();
        }
        public async Task LoadWalkDetails()
        {
            await Task.Factory.StartNew(() =>
            {
                walkEntries = new ObservableCollection<WalkEntries>() {
                new WalkEntries {
                    Title = "10-milowy szlak wzdłuż strumienia, Margaret River",
                    Notes = " 10-milowy szlak wzdłuż strumienia zaczyna się w Rotary Park w pobliżu Old Kate, czyli starej lokomotywy stoj�cej w p�nocnej cz�ci Margaret River. ",
                    Latitude = -33.9727604,
                    Longitude = 115.0861599,
                    Kilometers = 7.5,
                    Distance = 0,
                    Difficulty = "�redni",
                    ImageUrl = "http://trailswa.com.au/media/cache/media/images/trails/_mid/FullSizeRender1_600_480_c1.jpg"
                },
                new WalkEntries
                {
                    Title = "Szlak Ancient Empire, Dolina Gigant�w",
                    Notes = " Ancient Empire to 450-metrowy szlak po�r�d gigantycznych drzew, w�r�d kt�rych znajduj� si� popularne s�kate olbrzymy zwane Grandma Tingle.",
                    Latitude = -34.9749188,
                    Longitude = 117.3560796,
                    Kilometers = 450,
                    Distance = 0,
                    Difficulty = "Wysoki",
                    ImageUrl = "http://trailswa.com.au/media/cache/media/images/trails/_mid/Ancient_Empire_534_480_c1.jpg"
                },
                };
            });
        }
        Command _createNewWalk;
        public Command CreateNewWalk
        {
            get
            {
                return _createNewWalk
                    ?? (_createNewWalk = new Command(async () =>
                                                     await NavService.NavigateToViewModel<WalkEntryViewModel, WalkEntries>(null)));
            }
        }

        Command<WalkEntries> _trailDetails;
        public Command<WalkEntries> WalkTrailDetails
        {
            get
            {
                return _trailDetails
                    ?? (_trailDetails = new Command<WalkEntries>(async (trailDetails) =>
                                                                 await NavService.NavigateToViewModel<WalksTrailViewModel, WalkEntries>(trailDetails)));
            }
        }
    }
}
