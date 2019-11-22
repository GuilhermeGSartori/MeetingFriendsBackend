using App.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services
{
    public interface IEvent
    {
        Event GetEvent(int? Id);
        IQueryable<Event> GetEvents { get; }
        void Save(Event newEvent);
    }
}
