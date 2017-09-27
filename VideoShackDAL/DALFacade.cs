using System;
using System.Collections.Generic;
using System.Text;
using VideoShackDAL.OUW;
using VideoShackDAL.Repositories;

namespace VideoShackDAL
{
    public class DALFacade
    {
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWork();
            }
        }
    }
}
