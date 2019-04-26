using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using TrackMyWalks.Models;

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

        public WalksPageViewModel()
        {
            walkEntries = new ObservableCollection<WalkEntries>
            {
                new WalkEntries
                {
                    Title = " Tytuł",
                    Notes = " NotatkaNotatkaNotatkaNotatkaNotatkaNotatkaNotatka NotatkaNotatka Notatka",
                    Latitude = -33.9727604,
                    Longitude = 115.0861599,
                    Kilometers = 3,
                    Distance = 0,
                    Difficulty = "Średnio",
                    ImageUrl = "https://i2.wp.com/palitechnika.com/wp-content/uploads/2019/03/nwrto.png?w=1000&ssl=1"
                },
                new WalkEntries
                {
                    Title = " Tytuł2",
                    Notes = " Notatka222222222NotatkaNotatkaNotatkaNotatkaNotatkaNotatka NotatkaNotatka Notatka",
                    Latitude = -33.9727604,
                    Longitude = 115.0861599,
                    Kilometers = 5,
                    Distance = 2,
                    Difficulty = "Średnio2",
                    ImageUrl = "https://i2.wp.com/palitechnika.com/wp-content/uploads/2019/03/nwrto.png?w=1000&ssl=1"
                },
            };
        }
    }
}
