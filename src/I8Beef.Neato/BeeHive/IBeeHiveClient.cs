using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using I8Beef.Neato.BeeHive.Protocol;

namespace I8Beef.Neato.BeeHive
{
    /// <summary>
    /// BeeHive client.
    /// </summary>
    public interface IBeeHiveClient
    {
        /// <summary>
        /// Authorize.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Access token.</returns>
        Task<string> AuthorizeAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send GetMaps request.
        /// </summary>
        /// <param name="serialNumber">Serial number.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="MapsInformation"/>.</returns>
        Task<MapsInformation> GetMapsAsync(string serialNumber, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send GetPersistentMaps request.
        /// </summary>
        /// <param name="serialNumber">Serial number.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="IList{PersistentMapInformation}"/>.</returns>
        Task<IList<PersistentMapInformation>> GetPersistentMapsAsync(string serialNumber, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send GetRobots request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="IList{RobotInformation}"/>.</returns>
        Task<IList<RobotInformation>> GetRobotsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send GetUser request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="UserInformation"/>.</returns>
        Task<UserInformation> GetUserAsync(CancellationToken cancellationToken = default);
    }
}