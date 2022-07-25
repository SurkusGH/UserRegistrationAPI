using System;
using System.Threading.Tasks;
using UserRegistrationAPI.Models;

namespace UserRegistrationAPI.Repositories.IRepository
{

    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<DataSheet> DataSheets { get; }
        IGenericRepository<Address> Addresses { get; }
        Task Save();
    }

}
