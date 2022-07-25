using System;
using System.Threading.Tasks;
using UserRegistrationAPI.Models;
using UserRegistrationAPI.Repositories.IRepository;

namespace UserRegistrationAPI.Repositories.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<User> _users;
        private IGenericRepository<DataSheet> _sheets;
        private IGenericRepository<Address> _addresses;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);
        public IGenericRepository<DataSheet> DataSheets => _sheets ??= new GenericRepository<DataSheet>(_context);
        public IGenericRepository<Address> Addresses => _addresses ??= new GenericRepository<Address>(_context);


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
