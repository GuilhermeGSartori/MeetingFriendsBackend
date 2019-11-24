using App.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public interface ILocation
    {
        Task<Location> GetLocation(string name);
        IQueryable<Location> GetLocations { get; }
        Task<LocationTAR> Save(Location location);
    }
}