using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using TrackMyWalks.Models;
using TrackMyWalks.ViewModels;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using TrackMyWalks.Services;

namespace TrackMyWalks.ViewModels
{
    public class WalkEntryViewModel : WalkBaseViewModel
    {
        string _title;
        public string Title
        {
            get { return _title;}
            set { _title = value;
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();
            }
        }
        string _notes;
        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }

        double _latitude;
        public double Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                OnPropertyChanged();
            }
        }

        double _longitude;
        public double Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                OnPropertyChanged();
            }
        }

        double _kilometers;
        public double Kilometers
        {
            get { return _kilometers; }
            set
            {
                _kilometers = value;
                OnPropertyChanged();
            }
        }

        string _difficulty;
        public string Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;
                OnPropertyChanged();
            }
        }

        double _distance;
        public double Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                OnPropertyChanged();
            }
        }

        string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                OnPropertyChanged();
            }
        }

        //konstruktor przypisujący wartości domyślne dla pół
        public WalkEntryViewModel(IWalkNavService navService) : base(navService)
        {
            Title = "Nowy szlak";
            Difficulty = "Niski";
            Distance = 1.0;
        }

        Command _saveCommand;
        public Command SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new Command(async () => await ExecuteSaveCommand(), ValidateFormDetails));
            }
        }

        async Task ExecuteSaveCommand()
        {
            var newWalkItem = new WalkEntries
            {
                Title = this.Title,
                Notes = this.Notes,
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                Kilometers = this.Kilometers,
                Difficulty = this.Difficulty,
                Distance = this.Distance,
                ImageUrl = this.ImageUrl
            };

            //tu będzie kod zapisujący dane
            await NavService.PreviousPage();
        }
        // metoda sprawdzająca błędy w formularzu
        bool ValidateFormDetails()
        {
            return !string.IsNullOrWhiteSpace(Title);
        }

        public override async Task Init()
        {
            await Task.Factory.StartNew(() =>
            {
                Title = "Nowy szlak";
                Difficulty = "Niski";
                Distance = 1.0;
            });
        }
    }
}
