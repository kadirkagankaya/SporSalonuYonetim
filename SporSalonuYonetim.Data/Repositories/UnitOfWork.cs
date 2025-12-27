using System.Threading.Tasks;
using SporSalonuYonetim.Core.Interfaces;
using SporSalonuYonetim.Data.Context;

namespace SporSalonuYonetim.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SporSalonuContext _context;

        public UnitOfWork(SporSalonuContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
