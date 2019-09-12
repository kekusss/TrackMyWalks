using System;
using System.Collections.Generic;
using System.Text;
using TrackMyWalks.Models;

namespace TrackMyWalks.ViewModels
{
    class WalksTrailViewModel : WalkBaseViewModel
    {
        WalkEntries _walkEntry;
        public WalkEntries WalkEntry {
            get { return _walkEntry; }
            set { _walkEntry = value; OnPropertyChanged(); }
        }

        public WalksTrailViewModel(WalkEntries walkEntry) {
            WalkEntry = walkEntry;
        }
    }
}
