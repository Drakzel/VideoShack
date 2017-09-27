using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoShackDAL.Entities;

namespace VideoShackDAL.Repositories
{
    class VideoRepositoryFakeDB : IVideoRepository
    {
        private static int Id = 1;
        private static List<Movie> Movies = new List<Movie>();

        public Movie Create(Movie movie)
        {
            Movie newMovie;
            Movies.Add(newMovie = new Movie()
            {
                Id = Id++,
                Name = movie.Name,
                Genre = movie.Genre
            });
            return newMovie;
        }

        public Movie DeleteMovie(int id)
        {
            var movie = RetrieveById(id);
            Movies.Remove(movie);
            return movie;
        }

        public List<Movie> RetrieveAllMovies()
        {
            return new List<Movie>(Movies);
        }

        public Movie RetrieveById(int? id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }

        public List<Movie> RetrieveByName(string name)
        {
            return new List<Movie>(Movies.Where(x => x.Name == name));
        }
    }
}
