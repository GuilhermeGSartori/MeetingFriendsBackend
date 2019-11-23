using App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using App.Data;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<Location> GetLocation(string name)
        {
            Location location = new Location();

            if (name != null)
                location = await _db.Locations.FindAsync(name);

            return location;
        }

        public async Task<LocationTAR> Save(Location location)
        {
            LocationTAR model = new LocationTAR();
            Location existing_location = await GetLocation(location.LocationName);

            if (existing_location == null) //New
            {

                try
                {
                    await _db.Locations.AddAsync(location); //does add deals with the Id?
                    await _db.SaveChangesAsync();

                    model.Name = location.LocationName;
                    model.Success = true;
                    model.Message = "New location created!";
                }
                catch (Exception ex)
                {
                    model.Success = false;
                    model.Message = ex.ToString();
                }
            }
            else
            {

                existing_location.Score = location.Score;

                try
                {
                    await _db.SaveChangesAsync();
                    model.Name = location.LocationName;
                    model.Success = true;
                    model.Message = "Old location updated!";
                }
                catch (Exception ex)
                {
                    model.Success = false;
                    model.Message = ex.ToString();
                }
            }
            return model;
        }
    }
}
