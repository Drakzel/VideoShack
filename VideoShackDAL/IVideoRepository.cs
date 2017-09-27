using System;
using System.Collections.Generic;
using System.Text;
using VideoShackDAL.Entities;

namespace VideoShackDAL
{
    public interface IVideoRepository
    {
        Movie Create(Movie movie);

        List<Movie> RetrieveByName(string name);
        Movie RetrieveById(int? id);
        List<Movie> RetrieveAllMovies();

        Movie DeleteMovie(int id);
    }
}
