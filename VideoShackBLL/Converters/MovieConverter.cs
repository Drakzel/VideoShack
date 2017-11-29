using System;
using System.Collections.Generic;
using System.Text;
using VideoShackBLL.BusinessObjects;
using VideoShackDAL.Entities;

namespace VideoShackBLL.Converters
{
    class MovieConverter
    {
        internal Movie Convert(MovieBO movie)
        {
            if (movie == null) { return null; }
            return new Movie()
            {
                Id = movie.Id,
                Name = movie.Name,
                Genre = movie.Genre
            };
        }

        internal MovieBO Convert(Movie movie)
        {
            if (movie == null) { return null; }
            return new MovieBO()
            {
                Id = movie.Id,
                Name = movie.Name,
                Genre = movie.Genre
            };
        }
    }
}
