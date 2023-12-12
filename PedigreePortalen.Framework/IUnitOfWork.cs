using System.Threading.Tasks;

namespace PedigreePortalen.Framework
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}