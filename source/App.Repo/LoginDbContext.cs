using App.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Repo
{
    public class LoginDbContext : DbContext
    {
        //constructor (creates connection with the entityframeworkcore (in-memory Db) 
        //Login Table available in the database. Code First.
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options) { }

        public DbSet<User> Login { get; set; }

    }
}
