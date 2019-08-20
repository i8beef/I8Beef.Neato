using System;
using System.Threading.Tasks;
using I8Beef.Neato.Nucleo;
using I8Beef.Neato.Nucleo.Protocol;
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
    /// <inheritdoc />
    public class Robot : IRobot
    {
        private readonly INucleoClient _nucleoClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Robot"/> class.
        /// </summary>
        /// <param name="nucleoClient"><see cref="NucleoClient"/> instance.</param>
        public Robot(INucleoClient nucleoClient)
        {
            _nucleoClient = nucleoClient ?? throw new ArgumentNullException(nameof(nucleoClient));
        }

        #region Common

        /// <inheritdoc />
        public async Task<RobotInfo> GetRobotInfoAsync()
        {
            var response = await _nucleoClient.GetRobotInfoAsync();
            return response.Data;
        }

        /// <inheritdoc />
        public async Task<RobotState> GetRobotStateAsync()
        {
            var state = await _nucleoClient.GetRobotStateAsync();

            var robotState = new RobotState
            {
                Action = state.Action,
                Alert = state.Alert,
                AvailableCommands = state.AvailableCommands,
                AvailableServices = state.AvailableServices,
                Cleaning = state.Cleaning,
                Details = state.Details,
                Error = state.Error,
                MetaInformation = state.MetaInformation,
                State = state.State
            };

            return robotState;
        }

        /// <inheritdoc />
        public Task DismissCurrentAlertAsync()
        {
            return _nucleoClient.DismissCurrentAlertAsync();
        }

        #endregion

        #region FindMe

        /// <inheritdoc />
        public async Task FindMeAsync()
        {
            var state = await GetRobotStateAsync();
            if (state.AvailableServices.FindMe == null)
            {
                throw new Exception("Robot does not support service findMe");
            }

            switch (state.AvailableServices.GeneralInfo)
            {
                case "basic-1":
                    await _nucleoClient.FindMeAsync();
                    break;
            }
        }

        #endregion

        #region GenergalInfo

        /// <inheritdoc />
        public async Task<GetGeneralInfo> GetGeneralInfoAsync()
        {
            var state = await GetRobotStateAsync();
            if (state.AvailableServices.GeneralInfo == null)
            {
                throw new Exception("Robot does not support service generalInfo");
            }

            switch (state.AvailableServices.GeneralInfo)
            {
                case "advanced-1":
                case "basic-1":
                    var response = await _nucleoClient.GetGeneralInfoAsync();
                    return response.Data;
            }

            return null;
        }

        #endregion

        #region HouseCleaning and SpotCleaning

        /// <inheritdoc />
        public async Task PauseCleaningAsync()
        {
            var state = await GetRobotStateAsync();
            if (state.AvailableServices.HouseCleaning == null && state.AvailableServices.SpotCleaning == null)
            {
                throw new Exception("Robot does not support service houseCleaning or spotCleaning");
            }

            if (state.AvailableCommands.Pause)
            {
                switch (state.AvailableServices.HouseCleaning)
                {
                    case "basic-1":
                    case "minimal-2":
                    case "minimal-3":
                    case "basic-3":
                    case "basic-4":
                    default:
                        await _nucleoClient.PauseCleaningAsync();
                        break;
                }
            }
        }

        /// <inheritdoc />
        public async Task ResumeCleaningAsync()
        {
            var state = await GetRobotStateAsync();
            if (state.AvailableServices.HouseCleaning == null && state.AvailableServices.SpotCleaning == null)
            {
                throw new Exception("Robot does not support service houseCleaning or spotCleaning");
            }

            if (state.AvailableCommands.Resume)
            {
                switch (state.AvailableServices.HouseCleaning)
                {
                    case "basic-1":
                    case "minimal-2":
                    case "minimal-3":
                    case "basic-3":
                    case "basic-4":
                    default:
                        await _nucleoClient.ResumeCleaningAsync();
                        break;
                }
            }
        }

        /// <inheritdoc />
        public async Task SendToBaseAsync()
        {
            var state = await GetRobotStateAsync();
            if (state.AvailableServices.HouseCleaning == null && state.AvailableServices.SpotCleaning == null)
            {
                throw new Exception("Robot does not support service houseCleaning or spotCleaning");
            }

            if (state.AvailableCommands.GoToBase)
            {
                switch (state.AvailableServices.HouseCleaning)
                {
                    case "basic-1":
                    case "minimal-2":
                    case "minimal-3":
                    case "basic-3":
                    case "basic-4":
                    default:
                        await _nucleoClient.SendToBaseAsync();
                        break;
                }
            }
        }

        /// <inheritdoc />
        public async Task StartCleaningAsync(StartCleaningParameters parameters)
        {
            var state = await GetRobotStateAsync();
            if ((parameters.Category == CleaningCategory.HouseCleaning || parameters.Category == CleaningCategory.PersistentMap)
                && state.AvailableServices.HouseCleaning == null)
            {
                throw new Exception("Robot does not support service houseCleaning");
            }

            if (parameters.Category == CleaningCategory.SpotCleaning && state.AvailableServices.SpotCleaning == null)
            {
                throw new Exception("Robot does not support service spotCleaning");
            }

            if (state.AvailableCommands.Start)
            {
                switch (state.AvailableServices.HouseCleaning)
                {
                    case "basic-1":
                    case "minimal-2":
                    case "minimal-3":
                    case "basic-3":
                    case "basic-4":
                    default:
                        await _nucleoClient.StartCleaningAsync(parameters);
                        break;
                }
            }
        }

        /// <inheritdoc />
        public async Task StopCleaningAsync()
        {
            var state = await GetRobotStateAsync();
            if (state.AvailableServices.HouseCleaning == null && state.AvailableServices.SpotCleaning == null)
            {
                throw new Exception("Robot does not support service houseCleaning or spotCleaning");
            }

            if (state.AvailableCommands.Stop)
            {
                switch (state.AvailableServices.HouseCleaning)
                {
                    case "basic-1":
                    case "minimal-2":
                    case "minimal-3":
                    case "basic-3":
                    case "basic-4":
                    default:
                        await _nucleoClient.StopCleaningAsync();
                        break;
                }
            }
        }

        #endregion

        #region LocalStats

        /// <inheritdoc />
        public async Task<LocalStats> GetLocalStatsAsync()
        {
            var state = await GetRobotStateAsync();
            if (state.AvailableServices.LocalStats == null)
            {
                throw new Exception("Robot does not support service localStats");
            }

            switch (state.AvailableServices.LocalStats)
            {
                case "advanced-1":
                    var response = await _nucleoClient.GetLocalStatsAsync();
                    return response.Data;
            }

            return null;
        }

        #endregion

        #region ManualCleaning

        /// <inheritdoc />
        public async Task<RobotManualCleaningInfo> GetRobotManualCleaningInfoAsync()
        {
            var state = await GetRobotStateAsync();
            if (state.AvailableServices.ManualCleaning == null)
            {
                throw new Exception("Robot does not support service manualCleaning");
            }

            switch (state.AvailableServices.ManualCleaning)
            {
                case "basic-1":
                    var response = await _nucleoClient.GetRobotManualCleaningInfoAsync();
                    return response.Data;
            }

            return null;
        }

        #endregion

        #region Maps

        /// <inheritdoc />
        public async Task<MapBoundaries> GetMapBoundariesAsync(GetMapBoundaries parameters)
        {
            var state = await GetRobotStateAsync();
            if (state.AvailableServices.Maps == null)
            {
                throw new Exception("Robot does not support service maps");
            }

            switch (state.AvailableServices.Maps)
            {
                case "basic-1":
                case "basic-2":
                case "advanced-1":
                case "macro-1":
                    var response = await _nucleoClient.GetMapBoundariesAsync(parameters);
                    return response.Data;
            }

            return null;
        }

        /// <inheritdoc />
        public async Task SetMapBoundariesAsync(SetMapBoundaries parameters)
        {
            var state = await GetRobotStateAsync();
            if (state.AvailableServices.Maps == null)
            {
                throw new Exception("Robot does not support service maps");
            }

            switch (state.AvailableServices.Maps)
            {
                case "basic-1":
                case "basic-2":
                case "advanced-1":
                case "macro-1":
                    await _nucleoClient.SetMapBoundariesAsync(parameters);
                    break;
            }
        }

        /// <inheritdoc />
        public async Task StartPersistentMapExplorationAsync()
        {
            var state = await GetRobotStateAsync();
            if (state.AvailableServices.Maps == null)
            {
                throw new Exception("Robot does not support service maps");
            }

            switch (state.AvailableServices.Maps)
            {
                case "basic-1":
                case "basic-2":
                case "advanced-1":
                case "macro-1":
                    await _nucleoClient.StartPersistentMapExplorationAsync();
                    break;
            }
        }

        #endregion

        #region Preferences

        /// <inheritdoc />
        public async Task<Preferences> GetPreferencesAsync()
        {
            var state = await GetRobotStateAsync();
            if (state.AvailableServices.Preferences == null)
            {
                throw new Exception("Robot does not support service preferences");
            }

            switch (state.AvailableServices.Maps)
            {
                case "basic-1":
                case "advanced-1":
                    var response = await _nucleoClient.GetPreferencesAdvanced1Async();
                    return response.Data;
            }

            return null;
        }

        /// <inheritdoc />
        public async Task SetPreferencesAsync(Preferences parameters)
        {
            var state = await GetRobotStateAsync();
            if (state.AvailableServices.Preferences == null)
            {
                throw new Exception("Robot does not support service preferences");
            }

            switch (state.AvailableServices.Maps)
            {
                case "basic-1":
                case "advanced-1":
                default:
                    await _nucleoClient.SetPreferencesAdvanced1Async(parameters);
                    break;
            }
        }

        #endregion

        #region Schedule

        /// <inheritdoc />
        public async Task DisableScheduleAsync()
        {
            var state = await GetRobotStateAsync();
            if (state.AvailableServices.Schedule == null)
            {
                throw new Exception("Robot does not support service schedule");
            }

            switch (state.AvailableServices.Maps)
            {
                case "minimal-1":
                case "basic-1":
                case "basic-2":
                default:
                    await _nucleoClient.DisableScheduleAsync();
                    break;
            }
        }

        /// <inheritdoc />
        public async Task EnableScheduleAsync()
        {
            var state = await GetRobotStateAsync();
            if (state.AvailableServices.Schedule == null)
            {
                throw new Exception("Robot does not support service schedule");
            }

            switch (state.AvailableServices.Maps)
            {
                case "minimal-1":
                case "basic-1":
                case "basic-2":
                default:
                    await _nucleoClient.EnableScheduleAsync();
                    break;
            }
        }

        /// <inheritdoc />
        public async Task<Schedule> GetScheduleAsync()
        {
            var state = await GetRobotStateAsync();
            if (state.AvailableServices.Schedule == null)
            {
                throw new Exception("Robot does not support service schedule");
            }

            switch (state.AvailableServices.Maps)
            {
                case "minimal-1":
                case "basic-1":
                case "basic-2":
                    var response = await _nucleoClient.GetScheduleAsync();
                    return response.Data;
            }

            return null;
        }

        /// <inheritdoc />
        public async Task SetScheduleAsync(Schedule parameters)
        {
            var state = await GetRobotStateAsync();
            if (state.AvailableServices.Schedule == null)
            {
                throw new Exception("Robot does not support service schedule");
            }

            switch (state.AvailableServices.Maps)
            {
                case "minimal-1":
                case "basic-1":
                case "basic-2":
                default:
                    await _nucleoClient.SetScheduleAsync(parameters);
                    break;
            }
        }

        #endregion
    }
}
