using System.Threading;
using System.Threading.Tasks;
using I8Beef.Neato.Nucleo.Protocol.Services.Common;
using I8Beef.Neato.Nucleo.Protocol.Services.GeneralInfo;
using I8Beef.Neato.Nucleo.Protocol.Services.HouseCleaning;
using I8Beef.Neato.Nucleo.Protocol.Services.LocalStats;
using I8Beef.Neato.Nucleo.Protocol.Services.ManualCleaning;
using I8Beef.Neato.Nucleo.Protocol.Services.Maps;
using I8Beef.Neato.Nucleo.Protocol.Services.Preferences;
using I8Beef.Neato.Nucleo.Protocol.Services.Schedule;

namespace I8Beef.Neato
{
    /// <summary>
    /// Robot proxy.
    /// </summary>
    public interface IRobot
    {
        /// <summary>
        /// Sends a DisableSchedule request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task DisableScheduleAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a DismissCurrentAlert request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task DismissCurrentAlertAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a EnableSchedule request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task EnableScheduleAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a FindMe request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task FindMeAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a generalInfo request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="GetGeneralInfo"/>.</returns>
        Task<GetGeneralInfo> GetGeneralInfoAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a GetLocalStats request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="LocalStats"/>.</returns>
        Task<LocalStats> GetLocalStatsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a GetMapBoundaries request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="MapBoundaries"/>.</returns>
        Task<MapBoundaries> GetMapBoundariesAsync(GetMapBoundaries parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a GetPreferences request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Preferences"/>.</returns>
        Task<Preferences> GetPreferencesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a GetRobotInfo request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="RobotInfo"/>.</returns>
        Task<RobotInfo> GetRobotInfoAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a GetRobotManualCleaningInfo request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="RobotManualCleaningInfo"/>.</returns>
        Task<RobotManualCleaningInfo> GetRobotManualCleaningInfoAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a GetRobotState request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="RobotState"/>.</returns>
        Task<RobotState> GetRobotStateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a GetSchedule request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Schedule"/>.</returns>
        Task<Schedule> GetScheduleAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a pauseCleaning request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task PauseCleaningAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a resumeCleaning request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task ResumeCleaningAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a sendToBase request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task SendToBaseAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a SetMapBoundaries request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task SetMapBoundariesAsync(SetMapBoundaries parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a SetPreferences request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Preferences"/>.</returns>
        Task SetPreferencesAsync(Preferences parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a SetSchedule request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task SetScheduleAsync(Schedule parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a startCleaning request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task StartCleaningAsync(StartCleaningParameters parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a StartPersistentMapExploration request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task StartPersistentMapExplorationAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a stopCleaning request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task StopCleaningAsync(CancellationToken cancellationToken = default);
    }
}