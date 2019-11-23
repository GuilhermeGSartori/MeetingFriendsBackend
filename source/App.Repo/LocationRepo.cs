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

        public Location GetLocation(int? Id)
        {
            Location location = _db.Locations.Find(Id);
            return location;
        }

        public void Save(Location location)
        {
            if (location.LocationId == 0) //New
            {
                _db.Locations.Add(location);
                _db.SaveChanges();
            }
            else
            {
                Location existing_location = _db.Locations.Find(location.LocationId);
                existing_location.Name = location.Name;
                existing_location.Score = location.Score;

                _db.SaveChanges();
            }
        }
    }
}
