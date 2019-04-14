using System;
using System.Collections.Generic;
using System.Text;

namespace TrackMyWalks.Models
{
    /// <summary>
    /// Model pojedynczego wpisu - szlaku
    /// </summary>
    public class WalkEntries
    {
        public string Title{ get; set; }
        public string Notes { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Kilometers { get; set; }
        public string Difficulty { get; set; }
        public double Distance { get; set; }
        public string ImageUrl { get; set; }


    }
}
