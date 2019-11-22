using App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using App.Data;
using System.Linq;

namespace App.Repo
{
    public class LocationRepo : ILocation
    {

        private readonly LocationDbContext _db;

        public LocationRepo(LocationDbContext db)
        {
            _db = db;
        }

        public IQueryable<Location> GetLocations => throw new NotImplementedException();

        public Location GetLocation(int? Id)
        {
            throw new NotImplementedException();
        }

        public void Save(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
