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
        /// <returns>A <see cref="StandardResponse{Schedule}"/>.</returns>
        Task<StandardResponse<EmptyResponse>> DisableScheduleAsync();

        /// <summary>
        /// Send DismissCurrentAlert request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/></returns>
        Task<StandardResponse<EmptyResponse>> DismissCurrentAlertAsync();

        /// <summary>
        /// Send EnableSchedule request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/>.</returns>
        Task<StandardResponse<EmptyResponse>> EnableScheduleAsync();

        /// <summary>
        /// Send FindMe request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/></returns>
        Task<StandardResponse<EmptyResponse>> FindMeAsync();

        /// <summary>
        /// Send GetGeneralInfo request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{GetGeneralInfo}"/>.</returns>
        Task<StandardResponse<GetGeneralInfo>> GetGeneralInfoAsync();

        /// <summary>
        /// Send GetLocalStats request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{LocalStats}"/>.</returns>
        Task<StandardResponse<LocalStats>> GetLocalStatsAsync();

        /// <summary>
        /// Send GetMapBoundaries request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <returns>A <see cref="StandardResponse{MapBoundaries}"/>.</returns>
        Task<StandardResponse<MapBoundaries>> GetMapBoundariesAsync(GetMapBoundaries parameters);

        /// <summary>
        /// Send GetPreferences request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{Preferences}"/>.</returns>
        Task<StandardResponse<Preferences>> GetPreferencesAdvanced1Async();

        /// <summary>
        /// Send GetRobotInfo request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{RobotInfo}"/></returns>
        Task<StandardResponse<RobotInfo>> GetRobotInfoAsync();

        /// <summary>
        /// Send GetRobotManualCleaningInfo request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{RobotManualCleaningInfo}"/>.</returns>
        Task<StandardResponse<RobotManualCleaningInfo>> GetRobotManualCleaningInfoAsync();

        /// <summary>
        /// Send GetRobotState request.
        /// </summary>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/></returns>
        Task<StateResponse<EmptyResponse>> GetRobotStateAsync();

        /// <summary>
        /// Send GetSchedule request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{Schedule}"/>.</returns>
        Task<StandardResponse<Schedule>> GetScheduleAsync();

        /// <summary>
        /// Send PauseCleaning request.
        /// </summary>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/>.</returns>
        Task<StateResponse<EmptyResponse>> PauseCleaningAsync();

        /// <summary>
        /// Send ResumeCleaning request.
        /// </summary>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/>.</returns>
        Task<StateResponse<EmptyResponse>> ResumeCleaningAsync();

        /// <summary>
        /// Send SendToBase request.
        /// </summary>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/>.</returns>
        Task<StateResponse<EmptyResponse>> SendToBaseAsync();

        /// <summary>
        /// Send SetMapBoundaries request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/>.</returns>
        Task<StandardResponse<EmptyResponse>> SetMapBoundariesAsync(SetMapBoundaries parameters);

        /// <summary>
        /// Send SetPreferences request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/>.</returns>
        Task<StandardResponse<EmptyResponse>> SetPreferencesAdvanced1Async(Preferences parameters);

        /// <summary>
        /// Send SetSchedule request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/>.</returns>
        Task<StandardResponse<EmptyResponse>> SetScheduleAsync(Schedule parameters);

        /// <summary>
        /// Send StartCleaning request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/>.</returns>
        Task<StateResponse<EmptyResponse>> StartCleaningAsync(StartCleaningParameters parameters);

        /// <summary>
        /// Send StartPersistentMapExploration request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/>.</returns>
        Task<StandardResponse<EmptyResponse>> StartPersistentMapExplorationAsync();

        /// <summary>
        /// Send StopCleaning request.
        /// </summary>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/>.</returns>
        Task<StateResponse<EmptyResponse>> StopCleaningAsync();
    }
}