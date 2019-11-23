using App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using App.Data;
using System.Linq;

namespace App.Repo
{
    public class EventRepo : IEvent
    {

        private readonly EventDbContext _db;

        public EventRepo(EventDbContext db)
        {
            _db = db;
        }

        public IQueryable<Event> GetEvents => _db.Events;

        public Event GetEvent(int? Id)
        {
            Event foundEvent = _db.Events.Find(Id);
            return foundEvent;
        }

        public void Save(Event newEvent)
        {
            if (newEvent.EventId == 0) //New
            {
                _db.Events.Add(newEvent);
                _db.SaveChanges();
            }
            else
            {
                Event existing_event = _db.Events.Find(newEvent.EventId);
                existing_event.Date = newEvent.Date;
                existing_event.Name = newEvent.Name;
                existing_event.Cost = newEvent.Cost;
                existing_event.Description = newEvent.Description;
                existing_event.Place = newEvent.Place;

                _db.SaveChanges();
            }
        }
    }
}
