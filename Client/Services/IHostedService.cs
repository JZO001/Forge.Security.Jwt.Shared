using System.Threading.Tasks;
using System.Threading;

namespace Forge.Security.Jwt.Shared.Client.Services
{

    /// <summary>Represents a hostable service</summary>
    public interface IHostedService
    {

        /// <summary>Triggered when the application host is ready to start the service.</summary>
        /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
        /// <returns>Task</returns>
        Task StartAsync(CancellationToken cancellationToken);

        /// <summary>Triggered when the application host is performing a graceful shutdown.</summary>
        /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
        /// <returns>Task</returns>
        Task StopAsync(CancellationToken cancellationToken);

    }

}
