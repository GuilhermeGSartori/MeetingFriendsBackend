//necessary package to use in-memory SQL Server database. Version 1.1.1, installed using Visual Studio NuGet
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
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        //with this command, the User Table is already available in the database
        //code first, not db first

        //Generate for the User class the Users table
        public DbSet<User>Users { get; set; }

    }
}
