using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using TrackMyWalks.Models;

namespace TrackMyWalks.Pages
{
    public class DistanceTravelledPage : ContentPage
    {
        public DistanceTravelledPage(WalkEntries walkItem)
        {
            Title = "Przebyty dystans";

            //tworzenie obiektu mapy

            var trailMap = new Map();
            //wbicie szpilki w mapę dla wybranego szlaku
            trailMap.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = walkItem.Title,
                Position = new Position(walkItem.Latitude, walkItem.Longitude),
            });
            //Wyśrodkowanie mapy na początku szlaku / szpilce
            trailMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(walkItem.Latitude, walkItem.Longitude), Distance.FromKilometers(1.0)));

            var trailNameLabel = new Label()
            {
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                Text = walkItem.Title
            };
            var TrailDistanceTravelledLabel = new Label()
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                Text = "Przebyty dystans",
                HorizontalTextAlignment = TextAlignment.Center
            };
            var totalDistanceTaken = new Label()
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                Text = $"{ walkItem.Distance }",
                HorizontalTextAlignment = TextAlignment.Center
            };
            var totalTimeTakenLabel = new Label()
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                Text = "Czas",
                HorizontalTextAlignment = TextAlignment.Center
            };
            var totalTimeTaken = new Label()
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                Text = "0 h 0 m 0 s",
                HorizontalTextAlignment = TextAlignment.Center
            };
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
                        totalDistanceTaken,
                        totalTimeTakenLabel,
                        totalTimeTaken,
                        walksHomeButton
                    }
                }
            };
        }
    }
}