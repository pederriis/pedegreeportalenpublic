using System.Threading.Tasks;

namespace PedigreePortalen.Framework
{
    public interface IApplicationService
    {
        Task Handle(object command);
    }
}