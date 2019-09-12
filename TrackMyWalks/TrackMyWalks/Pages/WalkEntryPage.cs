using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using TrackMyWalks.Models;
using TrackMyWalks.ViewModels;

namespace TrackMyWalks.Pages
{
	public class WalkEntryPage : ContentPage
	{
		public WalkEntryPage ()
		{
            //Tytuł strony
            Title = "Nowy wpis";

            BindingContext = new WalkEntryViewModel();

            //Pola do wypełnienia
            var walkTitle = new EntryCell
            {
                Label = "Tytuł:",
                Placeholder = "Nazwa szlaku"
            };
            walkTitle.SetBinding(EntryCell.TextProperty, "Title", BindingMode.TwoWay);

            var walkNotes = new EntryCell
            {
                Label = "Uwagi",
                Placeholder = "Opis"
            };
            walkNotes.SetBinding(EntryCell.TextProperty, "Uwagi", BindingMode.TwoWay);

            var walkLatitude = new EntryCell
            {
                Label = "Szerokość geograficza",
                Placeholder = "Szerokość",
                Keyboard = Keyboard.Numeric
            };
            walkLatitude.SetBinding(EntryCell.TextProperty, "Szerokość geograficzna", BindingMode.TwoWay);

            var walkLongitude = new EntryCell
            {
                Label = "Długość geo",
                Placeholder = "Długość",
                Keyboard = Keyboard.Numeric
            };
            walkLongitude.SetBinding(Entry.TextProperty, "Długość geograficzna", BindingMode.TwoWay);

            var walkKilometers = new EntryCell
            {
                Label = "Liczba kilometrów",
                Placeholder = "Liczba kilometrów",
                Keyboard = Keyboard.Numeric
            };
            walkKilometers.SetBinding(Entry.TextProperty, "Dystans", BindingMode.TwoWay);

            var walkDifficulty = new EntryCell
            {
                Label = "Poziom trudności",
                Placeholder = "Trudność"
            };
            walkDifficulty.SetBinding(Entry.TextProperty, "Trudność", BindingMode.TwoWay);

            var walkImageUrl = new EntryCell
            {
                Label = "Url Obrazu",
                Placeholder = "Url"
            };
            walkImageUrl.SetBinding(Entry.TextProperty, "Url Obrazu", BindingMode.TwoWay);

            //generowanie widoku
            Content = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection()
                    {
                        walkTitle,
                        walkNotes,
                        walkLatitude,
                        walkLongitude,
                        walkKilometers,
                        walkDifficulty,
                        walkImageUrl
                    }
                }
            };

            var saveWalkItem = new ToolbarItem
            {
                Text = "Zapisz"
            };
            saveWalkItem.SetBinding(MenuItem.CommandProperty, "SaveCommand");

            ToolbarItems.Add(saveWalkItem);

            saveWalkItem.Clicked += (sender, e) =>
            {
                Navigation.PopToRootAsync(true);
            };

        }
	}
}