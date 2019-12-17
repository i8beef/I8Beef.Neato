using System.Threading;
using System.Threading.Tasks;
using I8Beef.Neato.Nucleo.Protocol;
using I8Beef.Neato.Nucleo.Protocol.Services.Common;
using I8Beef.Neato.Nucleo.Protocol.Services.GeneralInfo;
using I8Beef.Neato.Nucleo.Protocol.Services.HouseCleaning;
using I8Beef.Neato.Nucleo.Protocol.Services.LocalStats;
using I8Beef.Neato.Nucleo.Protocol.Services.ManualCleaning;
using I8Beef.Neato.Nucleo.Protocol.Services.Maps;
using I8Beef.Neato.Nucleo.Protocol.Services.Preferences;
using I8Beef.Neato.Nucleo.Protocol.Services.Schedule;

namespace I8Beef.Neato.Nucleo
{
    /// <summary>
    /// Nucleo client.
    /// </summary>
    public interface INucleoClient
    {
        /// <summary>
        /// Send DisableSchedule request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StandardResponse{Schedule}"/>.</returns>
        Task<StandardResponse<EmptyResponse>> DisableScheduleAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send DismissCurrentAlert request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/></returns>
        Task<StandardResponse<EmptyResponse>> DismissCurrentAlertAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send EnableSchedule request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/>.</returns>
        Task<StandardResponse<EmptyResponse>> EnableScheduleAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send FindMe request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/></returns>
        Task<StandardResponse<EmptyResponse>> FindMeAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send GetGeneralInfo request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StandardResponse{GetGeneralInfo}"/>.</returns>
        Task<StandardResponse<GetGeneralInfo>> GetGeneralInfoAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send GetLocalStats request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StandardResponse{LocalStats}"/>.</returns>
        Task<StandardResponse<LocalStats>> GetLocalStatsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send GetMapBoundaries request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StandardResponse{MapBoundaries}"/>.</returns>
        Task<StandardResponse<MapBoundaries>> GetMapBoundariesAsync(GetMapBoundaries parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send GetPreferences request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StandardResponse{Preferences}"/>.</returns>
        Task<StandardResponse<Preferences>> GetPreferencesAdvanced1Async(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send GetRobotInfo request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StandardResponse{RobotInfo}"/></returns>
        Task<StandardResponse<RobotInfo>> GetRobotInfoAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send GetRobotManualCleaningInfo request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StandardResponse{RobotManualCleaningInfo}"/>.</returns>
        Task<StandardResponse<RobotManualCleaningInfo>> GetRobotManualCleaningInfoAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send GetRobotState request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/></returns>
        Task<StateResponse<EmptyResponse>> GetRobotStateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send GetSchedule request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StandardResponse{Schedule}"/>.</returns>
        Task<StandardResponse<Schedule>> GetScheduleAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send PauseCleaning request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/>.</returns>
        Task<StateResponse<EmptyResponse>> PauseCleaningAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send ResumeCleaning request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/>.</returns>
        Task<StateResponse<EmptyResponse>> ResumeCleaningAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send SendToBase request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/>.</returns>
        Task<StateResponse<EmptyResponse>> SendToBaseAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send SetMapBoundaries request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/>.</returns>
        Task<StandardResponse<EmptyResponse>> SetMapBoundariesAsync(SetMapBoundaries parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send SetPreferences request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/>.</returns>
        Task<StandardResponse<EmptyResponse>> SetPreferencesAdvanced1Async(Preferences parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send SetSchedule request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/>.</returns>
        Task<StandardResponse<EmptyResponse>> SetScheduleAsync(Schedule parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send StartCleaning request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/>.</returns>
        Task<StateResponse<EmptyResponse>> StartCleaningAsync(StartCleaningParameters parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send StartPersistentMapExploration request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/>.</returns>
        Task<StandardResponse<EmptyResponse>> StartPersistentMapExplorationAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send StopCleaning request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/>.</returns>
        Task<StateResponse<EmptyResponse>> StopCleaningAsync(CancellationToken cancellationToken = default);
    }
}