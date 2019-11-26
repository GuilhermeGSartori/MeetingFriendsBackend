using App.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Repo
{
    public class UserDbContext:DbContext
    {
        //constructor (creates connection with the entityframeworkcore (in-memory Db) 
        //Users Table available in the database. Code First.
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User>Users { get; set; }

    }
}
