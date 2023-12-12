using System.Threading.Tasks;

namespace PedigreePortalen.Framework
{ 
    public interface IProjection
    {
        Task Project(object @event);
    }
}
