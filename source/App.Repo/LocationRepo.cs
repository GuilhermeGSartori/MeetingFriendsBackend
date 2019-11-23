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

        public IQueryable<Location> GetLocations => _db.Locations;

        public Location GetLocation(string name)
        {
            Location location = _db.Locations.Find(name);
            return location;
        }

        public void Save(Location location)
        {
            Location existing_location = _db.Locations.Find(location.Name);

            if (existing_location == null) //New
            {
                _db.Locations.Add(location);
                _db.SaveChanges();
            }
            else
            {
                existing_location.Score = location.Score;

                _db.SaveChanges();
            }
        }
    }
}
