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

        public IQueryable<Event> GetEvents => throw new NotImplementedException();

        public Event GetEvent(int? Id)
        {
            throw new NotImplementedException();
        }

        public void Save(Event newEvent)
        {
            throw new NotImplementedException();
        }
    }
}
