using System.Threading.Tasks;

namespace SporSalonuYonetim.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
