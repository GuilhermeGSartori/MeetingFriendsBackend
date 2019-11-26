using App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using App.Data;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repo
{
    public class EventRepo : IEvent //using IEvent interface (service)
    {

        private readonly EventDbContext _db;
                                            //dependency injection
        public EventRepo(EventDbContext db) //If EventDbContext not public, this does not work!
        {                                   //This repeats for the next repositories classes.
            _db = db;
        }

        public IQueryable<Event> GetEvents => _db.Events;

        public async Task<Event> GetEvent(int? Id)
        {
            Event foundEvent = new Event();

            if (Id != null)
                foundEvent = await _db.Events.FindAsync(Id);

            return foundEvent;
        }

        public async Task<TAR> Save(Event newEvent)
        {
            TAR model = new TAR();

            if (newEvent.EventId == 0) //New
            {
                try
                {
                    if (newEvent.Place == null)//Place is necessary
                    {
                        model.Success = false;
                        model.Message = "Place data not present!";
                        return model;
                    }

                    await _db.Events.AddAsync(newEvent); //saves unique "Id" and increments the counter
                    await _db.SaveChangesAsync();

                    model.Id = newEvent.EventId;
                    model.Success = true;
                    model.Message = "New event created!";
                }
                catch (Exception ex)//Failed to save in db
                {
                    model.Success = false;
                    model.Message = ex.ToString();
                }
            }
            else //Updating old event
            {
                Event existing_event = await GetEvent(newEvent.EventId);
                existing_event.Date = newEvent.Date;
                existing_event.EventName = newEvent.EventName;
                existing_event.Cost = newEvent.Cost;
                existing_event.Description = newEvent.Description;
                existing_event.Place = newEvent.Place;

                try
                {
                    await _db.SaveChangesAsync();
                    model.Id = newEvent.EventId;
                    model.Success = true;
                    model.Message = "Old event updated!";
                }
                catch (Exception ex) // could not update db info
                {
                    model.Success = false;
                    model.Message = ex.ToString();
                }
            }
            return model;
        }
    }
}
