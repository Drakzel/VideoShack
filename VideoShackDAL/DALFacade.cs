using System;
using System.Collections.Generic;
using System.Text;
using VideoShackDAL.OUW;
using VideoShackDAL.Repositories;

namespace VideoShackDAL
{
    public class DALFacade
    {
        public IVideoRepository VideoRepository
        {
            //get { return new VideoRepositoryFakeDB(); }

            get
            {
                return new VideoRepositoryEFMemory(
                    new Context.InMemoryContext());
            }
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWorkMemory();
            }
        }
    }
}
