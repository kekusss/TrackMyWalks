using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrackMyWalks.ViewModels;
using TrackMyWalks.Services;
using Xamarin.Forms;
using System.Reflection;
using System.Linq;

[assembly: Dependency(typeof(WalkNavService))]
namespace TrackMyWalks.Services
{
    class WalkNavService : IWalkNavService
    {
        public INavigation navigation { get; set; }

        readonly IDictionary<Type, Type> _viewMapping = new Dictionary<Type, Type>();
        //rejestracja modelu widoku i widoku w słowniku
        public void RegisterViewMapping(Type viewModel, Type view)
        {
            _viewMapping.Add(viewModel, view);
        }
        //implementacja metody umożliwiającej powrót do poprzedniej strony
        public async Task PreviousPage()
        {
            //sprawdzenei czy można wrócić
            if(navigation.NavigationStack != null && navigation.NavigationStack.Count > 0)
            {
                await navigation.PopAsync(true);
            }
        }
        //implementacja metody umożliwiającej powrót do strony głównej
        public async Task BackToMainPage()
        {
            await navigation.PopToRootAsync(true);
        }
        public async Task NavigateToViewModel<ViewModel, WalkParam>(WalkParam parameter) where ViewModel : WalkBaseViewModel
        {
            Type viewType;

            if(_viewMapping.TryGetValue(typeof(ViewModel), out viewType))
            {
                var constructor = viewType.GetTypeInfo().DeclaredConstructors.FirstOrDefault(dc => dc.GetParameters().Count() <= 0);
                var view = constructor.Invoke(null) as Page;
                await navigation.PushAsync(view, true);
            }

            if(navigation.NavigationStack.Last().BindingContext is WalkBaseViewModel<WalkParam>)
            {
                await ((WalkBaseViewModel<WalkParam>)(navigation.NavigationStack.Last().BindingContext)).Init(parameter);
            }
        }

    }
}
