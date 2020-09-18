using Authenticator.Core.Repositories;
using System;

namespace Authenticator.Core.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }       

        void Commit();
    }
}
