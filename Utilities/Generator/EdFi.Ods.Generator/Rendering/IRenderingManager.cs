using System.Threading;
using System.Threading.Tasks;

namespace EdFi.Ods.Generator.Rendering
{
    public interface IRenderingManager
    {
        Task<bool> RenderAllAsync(CancellationToken cancellationToken);
    }
}