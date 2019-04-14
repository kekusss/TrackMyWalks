using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TrackMyWalks.Models;
using TrackMyWalks.Pages;
using System.Threading.Tasks;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TrackMyWalks
{
    public partial class App : Application
    {
        public App()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                MainPage = new SplashPage();
            }
            else
            {
                var navPage = new NavigationPage(new TrackMyWalks.Pages.WalksPage()
                {
                    Title = "Track My Walks"
                });
                MainPage = navPage;
            }
        }

        protected override void OnStart()
        {
            base.OnStart();

            //3 sekundowe opoznienie
            //await Task.Delay(3000);

            //utworzenie navigationPage i przypisanie do MainPage
            var navPage = new NavigationPage(new WalksPage()
            {
                Title = " Track My Walks"
            });
            Application.Current.MainPage = navPage;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        /*
        protected override async void OnStart()
        {
            base.OnStart();

            //3 sekundowe opoznienie
            //await Task.Delay(3000);

            //utworzenie navigationPage i przypisanie do MainPage
            var navPage = new NavigationPage(new WalksPage()
            {
                Title = " Track My Walks"
            });
            Application.Current.MainPage = navPage;
        }*/
    }
}
