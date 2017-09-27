using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoShackBLL.BusinessObjects;
using VideoShackBLL.Converters;
using VideoShackDAL;
using VideoShackDAL.Entities;

namespace VideoShackBLL.Services
{
    class VideoService : IVideoService
    {
        DALFacade facade;
        MovieConverter conv = new MovieConverter();

        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public MovieBO Create(MovieBO movie)
        {
            using(var uow = facade.UnitOfWork)
            {
                var newMovie = uow.VideoRepository.Create(conv.Convert(movie));
                uow.Complete();
                return conv.Convert(newMovie);
            }
        }

        public MovieBO DeleteMovie(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newMovie = uow.VideoRepository.DeleteMovie(id);
                uow.Complete();
                return conv.Convert(newMovie);
            }
        }

        public List<MovieBO> RetrieveAllMovies()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.RetrieveAllMovies().Select(conv.Convert).ToList();
            }
        }

        public MovieBO RetrieveById(int? id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.VideoRepository.RetrieveById(id));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns empty list, if name doesn't exist</returns>
        public List<MovieBO> RetrieveByName(string name)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.RetrieveByName(name).Select(conv.Convert).ToList();
            }
        }


        public MovieBO Update(MovieBO movie)
        {
            using(var uow = facade.UnitOfWork)
            {
                var movieFromDb = uow.VideoRepository.RetrieveById(movie.Id);
                if (movieFromDb == null)
                {
                    throw new InvalidOperationException("Movie not found");
                }
                movieFromDb.Name = movie.Name;
                movieFromDb.Genre = movie.Genre;
                movieFromDb.Id = movie.Id;
                uow.Complete();
                return conv.Convert(movieFromDb);
            }
        }
    }
}
