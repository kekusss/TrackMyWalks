using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using TrackMyWalks.Models;

namespace TrackMyWalks.Pages
{
	public class WalksPage : ContentPage
	{
        public WalksPage()
        {
            var newWalkItem = new ToolbarItem
            {
                Text = "Dodaj szlak"
            };
            //Przejście do dodawania nowego szlaku
            newWalkItem.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new WalkEntryPage());
            };

            ToolbarItems.Add(newWalkItem);

            //Dodanie "na sztywno 2 szlaków"
            var walkItems = new List<WalkEntries>
            {
                new WalkEntries
                {
                    Title =" Tytuł",
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
                    Title =" Tytuł2",
                    Notes = " Notatka222222222NotatkaNotatkaNotatkaNotatkaNotatkaNotatka NotatkaNotatka Notatka",
                    Latitude = -33.9727604,
                    Longitude = 115.0861599,
                    Kilometers = 5,
                    Distance = 2,
                    Difficulty = "Średnio2",
                    ImageUrl = "https://i2.wp.com/palitechnika.com/wp-content/uploads/2019/03/nwrto.png?w=1000&ssl=1"
                },
            };

            var itemTemplate = new DataTemplate(typeof(ImageCell));
            itemTemplate.SetBinding(TextCell.TextProperty, "Title");
            itemTemplate.SetBinding(TextCell.DetailProperty, "Notes");
            itemTemplate.SetBinding(ImageCell.ImageSourceProperty, "ImageUrl");

            var walksList = new ListView
            {
                HasUnevenRows = true,
                ItemTemplate = itemTemplate,
                ItemsSource = walkItems,
                SeparatorColor = Color.FromHex("#ddd")
            };

            //konfiguracja procedury obsługi zdarzeń
            walksList.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                var item = (WalkEntries)e.Item;
                if (item == null) return;
                Navigation.PushAsync(new WalkTrailPage(item));
                item = null;
            };

            //dodanie stworzonej zawartości do strony
            Content = walksList;
		}
	}
}