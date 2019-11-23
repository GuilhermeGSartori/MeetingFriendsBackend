using App.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services
{
    public interface ILocation
    {
        Location GetLocation(string name);
        IQueryable<Location> GetLocations { get; }
        void Save(Location location);
    }
}
