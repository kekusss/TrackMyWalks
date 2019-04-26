using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using TrackMyWalks.Models;
using TrackMyWalks.ViewModels;

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

            BindingContext = new WalksPageViewModel();
            //definicja szablonu elementu
            var itemTemplate = new DataTemplate(typeof(ImageCell));
            itemTemplate.SetBinding(TextCell.TextProperty, "Title");
            itemTemplate.SetBinding(TextCell.DetailProperty, "Notes");
            itemTemplate.SetBinding(ImageCell.ImageSourceProperty, "ImageUrl");

            var walksList = new ListView
            {
                HasUnevenRows = true,
                ItemTemplate = itemTemplate,
                SeparatorColor = Color.FromHex("#ddd")
            };
            //własność wiązania 
            walksList.SetBinding(ItemsView<Cell>.ItemsSourceProperty, "walkEntries");

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