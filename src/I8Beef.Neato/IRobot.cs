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
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task DisableScheduleAsync();

        /// <summary>
        /// Sends a DismissCurrentAlert request.
        /// </summary>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task DismissCurrentAlertAsync();

        /// <summary>
        /// Sends a EnableSchedule request.
        /// </summary>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task EnableScheduleAsync();

        /// <summary>
        /// Sends a FindMe request.
        /// </summary>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task FindMeAsync();

        /// <summary>
        /// Sends a generalInfo request.
        /// </summary>
        /// <returns>A <see cref="GetGeneralInfo"/>.</returns>
        Task<GetGeneralInfo> GetGeneralInfoAsync();

        /// <summary>
        /// Sends a GetLocalStats request.
        /// </summary>
        /// <returns>A <see cref="LocalStats"/>.</returns>
        Task<LocalStats> GetLocalStatsAsync();

        /// <summary>
        /// Sends a GetMapBoundaries request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <returns>A <see cref="MapBoundaries"/>.</returns>
        Task<MapBoundaries> GetMapBoundariesAsync(GetMapBoundaries parameters);

        /// <summary>
        /// Sends a GetPreferences request.
        /// </summary>
        /// <returns>A <see cref="Preferences"/>.</returns>
        Task<Preferences> GetPreferencesAsync();

        /// <summary>
        /// Sends a GetRobotInfo request.
        /// </summary>
        /// <returns>A <see cref="RobotInfo"/>.</returns>
        Task<RobotInfo> GetRobotInfoAsync();

        /// <summary>
        /// Sends a GetRobotManualCleaningInfo request.
        /// </summary>
        /// <returns>A <see cref="RobotManualCleaningInfo"/>.</returns>
        Task<RobotManualCleaningInfo> GetRobotManualCleaningInfoAsync();

        /// <summary>
        /// Sends a GetRobotState request.
        /// </summary>
        /// <returns>A <see cref="RobotState"/>.</returns>
        Task<RobotState> GetRobotStateAsync();

        /// <summary>
        /// Sends a GetSchedule request.
        /// </summary>
        /// <returns>A <see cref="Schedule"/>.</returns>
        Task<Schedule> GetScheduleAsync();

        /// <summary>
        /// Sends a pauseCleaning request.
        /// </summary>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task PauseCleaningAsync();

        /// <summary>
        /// Sends a resumeCleaning request.
        /// </summary>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task ResumeCleaningAsync();

        /// <summary>
        /// Sends a sendToBase request.
        /// </summary>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task SendToBaseAsync();

        /// <summary>
        /// Sends a SetMapBoundaries request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task SetMapBoundariesAsync(SetMapBoundaries parameters);

        /// <summary>
        /// Sends a SetPreferences request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <returns>A <see cref="Preferences"/>.</returns>
        Task SetPreferencesAsync(Preferences parameters);

        /// <summary>
        /// Sends a SetSchedule request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task SetScheduleAsync(Schedule parameters);

        /// <summary>
        /// Sends a startCleaning request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task StartCleaningAsync(StartCleaningParameters parameters);

        /// <summary>
        /// Sends a StartPersistentMapExploration request.
        /// </summary>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task StartPersistentMapExplorationAsync();

        /// <summary>
        /// Sends a stopCleaning request.
        /// </summary>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task StopCleaningAsync();
    }
}