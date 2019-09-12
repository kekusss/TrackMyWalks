using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrackMyWalks.ViewModels;

namespace TrackMyWalks.Services
{
    interface IWalkNavService
    {
        //nawigacja do poprzedniej strony na stosie NavigationStack
        Task PreviousPage();
        //nawigacja do pierwszej strony na stosie
        Task BackToMainPage();
        //nawigacja do określonego MV i przekazanie parametru 
        Task NavigateToViewModel<ViewModel, TParameter>(TParameter parameter) where ViewModel : WalkBaseViewModel;

    }
}
