using System;
using System.Threading.Tasks;
using UserRegistrationAPI.Data.Data;

namespace UserRegistrationAPI.Core.Repositories.IRepository
{

    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<DataSheet> DataSheets { get; }
        IGenericRepository<Address> Addresses { get; }
        Task Save();
    }

}
