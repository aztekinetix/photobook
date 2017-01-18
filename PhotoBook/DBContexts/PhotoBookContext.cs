using PhotoBook.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;



namespace PhotoBook.DBContexts
{
    public class PhotoBookContext : DbContext
    {
        public PhotoBookContext() : base("DefaultConnection")
        {

        }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<PublisherPic> PublisherPics { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }

    }
}