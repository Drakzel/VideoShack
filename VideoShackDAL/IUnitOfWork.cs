using System;
using System.Collections.Generic;
using System.Text;

namespace VideoShackDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }
        ICollectionRepository CollectionRepository { get; }

        int Complete();
    }
}
