using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoShackDAL.Context;
using VideoShackDAL.Entities;

namespace VideoShackDAL.Repositories
{
    class VideoRepositoryEFMemory : IVideoRepository
    {
        VideoShackContext context;

        public VideoRepositoryEFMemory(VideoShackContext context)
        {
            this.context = context;
        }

        public Movie Create(Movie movie)
        {
            context.Movies.Add(movie);
            return movie;
        }

        public Movie DeleteMovie(int id)
        {
            var movie = RetrieveById(id);
            context.Movies.Remove(movie);
            return movie;
        }

        public List<Movie> RetrieveAllMovies()
        {
            return context.Movies.ToList();
        }

        public Movie RetrieveById(int? id)
        {
            return context.Movies.FirstOrDefault(x => x.Id == id);
        }

        public List<Movie> RetrieveByName(string name)
        {
            return context.Movies.Where(x => x.Name == name).ToList();
        }
    }
}
