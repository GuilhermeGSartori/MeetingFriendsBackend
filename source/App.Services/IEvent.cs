using App.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public interface IEvent
    {
        Task<Event> GetEvent(int? Id);
        IQueryable<Event> GetEvents { get; }
        Task<TAR> Save(Event newEvent);
    }
}
