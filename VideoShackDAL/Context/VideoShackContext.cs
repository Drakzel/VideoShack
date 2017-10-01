using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideoShackDAL.Entities;

namespace VideoShackDAL.Context
{
    class VideoShackContext : DbContext
    {
        static DbContextOptions<VideoShackContext> options = 
            new DbContextOptionsBuilder<VideoShackContext>()
            .UseInMemoryDatabase("TheDB")
            .Options;

        //Options that we want in Memory
        public VideoShackContext() : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Collection> Collections { get; set; }
    }
}
