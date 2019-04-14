using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TrackMyWalks.Pages
{
	public class SplashPage : ContentPage
	{
		public SplashPage ()
		{
            AbsoluteLayout splashLayout = new AbsoluteLayout
            {
                HeightRequest = 600
            };
            var image = new Image()
            {
                Source = ImageSource.FromFile("icon.png"),
                Aspect = Aspect.AspectFill,
            };

            AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(image, new Rectangle(0f, 0f, 1f, 1f));

            splashLayout.Children.Add(image);


            Content = new StackLayout {
                Children = {
                    splashLayout
				}
			};
		}
	}
}