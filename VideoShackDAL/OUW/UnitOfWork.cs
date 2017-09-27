using System;
using System.Collections.Generic;
using System.Text;
using VideoShackDAL.Context;
using VideoShackDAL.Repositories;

namespace VideoShackDAL.OUW
{
    class UnitOfWork : IUnitOfWork
    {
        public IVideoRepository VideoRepository { get; internal set; }
        public IOrderRepository OrderRepository { get; internal set; }
        private VideoShackContext context;

        public UnitOfWork()
        {
            context = new VideoShackContext();
            VideoRepository = new VideoRepositoryEFMemory(context);
            OrderRepository = new OrderRepository(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
