using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using TrackMyWalks.Models;

namespace TrackMyWalks.Pages
{
	public class WalkEntryPage : ContentPage
	{
		public WalkEntryPage ()
		{
            //Tytuł strony
            Title = "Nowy wpis";

            //Pola do wypełnienia
            var walkTitle = new EntryCell
            {
                Label = "Tytuł:",
                Placeholder = "Nazwa szlaku"
            };

            var walkNotes = new EntryCell
            {
                Label = "Uwagi",
                Placeholder = "Opis"
            };

            var walkLatitude = new EntryCell
            {
                Label = "Szerokość geo",
                Placeholder = "Szerokość",
                Keyboard = Keyboard.Numeric
            };

            var walkLongitude = new EntryCell
            {
                Label = "Długość geo",
                Placeholder = "Długość",
                Keyboard = Keyboard.Numeric
            };

            var walkKilometers = new EntryCell
            {
                Label = "Liczba kilometrów",
                Placeholder = "Liczba kilometrów",
                Keyboard = Keyboard.Numeric
            };

            var walkDifficulty = new EntryCell
            {
                Label = "Poziom trudności",
                Placeholder = "Trudność"
            };

            var walkImageUrl = new EntryCell
            {
                Label = "Url Obrazu",
                Placeholder = "Url"
            };

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

            saveWalkItem.Clicked += (sender, e) =>
            {
                Navigation.PopToRootAsync(true);
            };

            ToolbarItems.Add(saveWalkItem);
        }
	}
}