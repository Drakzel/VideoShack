using System;
using System.Collections.Generic;
using System.Text;
using VideoShackBLL.Services;
using VideoShackDAL;

namespace VideoShackBLL
{
    public class BLLFacade
    {
        public IVideoService GetVideoService
        {
            get { return new VideoService(new DALFacade()); }
        }

        public ICollectionService GetCollectionService
        {
            get { return new CollectionService(new DALFacade()); }
        }
    }
}
