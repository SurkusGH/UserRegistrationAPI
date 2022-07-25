using System;
using System.Threading.Tasks;
using UserRegistrationAPI.Models;

namespace UserRegistrationAPI.Repositories.IRepository
{
    public interface IUnitOfWork
    {
        public interface IUnitOfWork : IDisposable
        {
            IGenericRepository<User> Users { get; }
            IGenericRepository<DataSheet> InfoSheets { get; }
            IGenericRepository<Address> Addresses { get; }
            Task Save();
        }
    }
}
