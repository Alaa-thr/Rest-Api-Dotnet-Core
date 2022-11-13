using Microsoft.EntityFrameworkCore;
using rest_api_dotnet_core.Models;
using System;
//install Microsoft.EntityFrameworkCore

namespace rest_api_dotnet_core.Data
{
    //this class wil be the respensible of the communication between the app & the database
    public class ApiDbContext: DbContext // ApiDbContext extends DbContext(represents a session with the database and can be used to
    //     query and save instances of your tables)
    {
        //DbContextOptions instance carries configuration information such as the connection string, database provider to use
        public ApiDbContext(DbContextOptions options) : base(options)// base(options) => pass the param to the DbContext Class to do its works
        {
        }

        public DbSet<Comment> Comments { get; set; } // property to create a table in DB called "Comments", DbSet<Comment> used to query and save instences of Comments

        protected override void OnModelCreating(ModelBuilder modelBuilder)// to insert some data into the tables in DB
        {
            base.OnModelCreating(modelBuilder);

            //seed Comment table
            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = Guid.NewGuid(), Text = "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en page" }
            );
            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = Guid.NewGuid(), Text = "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée" }
            );
        }
    }
}
