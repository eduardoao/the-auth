using Authenticator.Core.Repositories;
using Authenticator.Core.UOW;
using Authenticator.Data.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Authenticator.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private IUserRepository _userRepository;        

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_transaction)); }
        }

        public UnitOfWork(IConfiguration config)
        {
            _connection = new SqlConnection(config.GetConnectionString("Principal"));
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private void ResetRepositories()
        {
            _userRepository = null;           
        }
    }
}
