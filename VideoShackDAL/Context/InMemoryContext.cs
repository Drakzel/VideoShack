using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideoShackDAL.Entites;

namespace VideoShackDAL.Context
{
    class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options = 
            new DbContextOptionsBuilder<InMemoryContext>()
            .UseInMemoryDatabase("TheDB")
            .Options;

        //Options that we want in Memory
        public InMemoryContext() : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
