using App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using App.Data;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repo
{
    public class EventRepo : IEvent
    {

        private readonly EventDbContext _db;
        //private readonly LocationDbContext _l_db;

        public EventRepo(EventDbContext db)
        {
            _db = db;
            //_l_db = l_db;
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
            //EventTable instance = new EventTable();

            if (newEvent.EventId == 0) //New
            {
                try
                {
                    if (newEvent.Place == null)
                    {
                        model.Success = false;
                        model.Message = "Place data not present!";
                        return model;
                    }

                    await _db.Events.AddAsync(newEvent); //does add deals with the Id?
                    await _db.SaveChangesAsync();

                    model.Id = newEvent.EventId;
                    model.Success = true;
                    model.Message = "New event created!";
                }
                catch (Exception ex)
                {
                    model.Success = false;
                    model.Message = ex.ToString();
                }
            }
            else
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
