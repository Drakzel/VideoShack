using System.Collections.Generic;
using VideoShackBLL.BusinessObjects;

namespace VideoShackBLL
{
    public interface IVideoService
    {
        MovieBO Create(MovieBO movie);

        List<MovieBO> RetrieveByName(string name);
        MovieBO RetrieveById(int? id);
        List<MovieBO> RetrieveAllMovies();

        MovieBO DeleteMovie(int id);
        
        MovieBO Update(MovieBO newMovie);
    }
}
