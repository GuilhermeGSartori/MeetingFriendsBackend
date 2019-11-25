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
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options) { }
        //with this command, the User Table is already available in the database
        //code first, not db first

        //Generate for the User class the Users table
        public DbSet<User> Login { get; set; }

    }
}
