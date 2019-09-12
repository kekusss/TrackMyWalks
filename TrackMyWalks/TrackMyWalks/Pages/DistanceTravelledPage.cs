using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using TrackMyWalks.Models;
using TrackMyWalks.ViewModels;

namespace TrackMyWalks.Pages
{
    public class DistanceTravelledPage : ContentPage
    {
        DistTravelledViewModel _viewModel
        {
            get { return BindingContext as DistTravelledViewModel; }
        }
        public DistanceTravelledPage(WalkEntries walkItem)
        {
            Title = "Przebyty dystans";

            //deklaracja i inicjalizacja kontekstu wiązania modelu
            BindingContext = new DistTravelledViewModel(walkItem);

            //tworzenie obiektu mapy

            var trailMap = new Map();
            //wbicie szpilki w mapę dla wybranego szlaku
            trailMap.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = _viewModel.WalkEntry.Title,
                Position = new Position(_viewModel.WalkEntry.Latitude, _viewModel.WalkEntry.Longitude),
            });
            //Wyśrodkowanie mapy na początku szlaku / szpilce
            trailMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(_viewModel.WalkEntry.Latitude, _viewModel.WalkEntry.Longitude), Distance.FromKilometers(1.0)));

            var trailNameLabel = new Label()
            {
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center
            };
            trailNameLabel.SetBinding(Label.TextProperty, "WalkEntry.Title");

            var TrailDistanceTravelledLabel = new Label()
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center
            };
            TrailDistanceTravelledLabel.SetBinding(Label.TextProperty, "Travelled", stringFormat: "Przebyty dystans: {0} km");

            var totalTimeTakenLabel = new Label()
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center
            };
            totalTimeTakenLabel.SetBinding(Label.TextProperty, "TimeTaken", stringFormat: "Czas: {0}");

            //przycisk
            var walksHomeButton = new Button()
            {
                BackgroundColor = Color.FromHex("#008080"),
                TextColor = Color.White,
                Text = "zakończ ten szlak"
            };
            //procedura obsługi kliknięcia w przycisk wróć do domowej
            walksHomeButton.Clicked += (sender, e) =>
            {
                if (walkItem == null) return;
                Navigation.PopToRootAsync(true);
                walkItem = null;
            };

            //kontrolka do przewijania
            this.Content = new ScrollView
            {
                Padding = 10,
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Children =
                    {
                        trailMap,
                        trailNameLabel,
                        TrailDistanceTravelledLabel,
                        totalTimeTakenLabel,
                        walksHomeButton
                    }
                }
            };
        }
    }
}