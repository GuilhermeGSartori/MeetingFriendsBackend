using App.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Repo
{
    public class EventDbContext : DbContext
    {
        //constructor (creates connection with the entityframeworkcore (in-memory Db) 
        //Events Table available in the database. Code First.
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }

    }
}
