using I8Beef.Neato.Nucelo.Services.GeneralInfo;
using I8Beef.Neato.Nucelo.Services.HouseCleaning;
using I8Beef.Neato.Nucelo.Services.Request;
using System;
using System.Threading.Tasks;

namespace I8Beef.Neato.Nucelo
{
    /// <summary>
    /// Robot proxy.
    /// </summary>
    public class Robot
    {
        private readonly NucleoClient _nucleoClient;

        public RobotState State { get; set; }

        /// <summary>
        /// Sends a FindMe request.
        /// </summary>
        /// <returns>A <see cref="Request"/>.</returns>
        public async Task FindMeAsync()
        {
            if (State.AvailableServices.FindMe == null)
            {
                throw new Exception("Robot does not support service findMe");
            }

            switch (State.AvailableServices.GeneralInfo)
            {
                case "basic-1":
                    await _nucleoClient.FindMeAsync();
                    break;
            }
        }

        /// <summary>
        /// Get a findMe request.
        /// </summary>
        /// <returns>A <see cref="Request"/>.</returns>
        public async Task<GetGeneralInfo> GetGeneralInfoAsync()
        {
            if (State.AvailableServices.GeneralInfo == null)
            {
                throw new Exception("Robot does not support service generalInfo");
            }

            switch (State.AvailableServices.GeneralInfo)
            {
                case "advanced-1":
                case "basic-1":
                    var response = await _nucleoClient.GetGeneralInfoAsync();
                    return response.Data;
            }

            return null;
        }

        /// <summary>
        /// Get a findMe request.
        /// </summary>
        /// <returns>A <see cref="Request"/>.</returns>
        public async Task StartCleaning()
        {
            if (State.AvailableServices.HouseCleaning == null)
            {
                throw new Exception("Robot does not support service houseCleaning");
            }

            if (State.AvailableCommands.Start)
            {
                throw new Exception("Robot does not support command startCleaning");
            }

            StartCleaningParameters parameters;
            switch (State.AvailableServices.HouseCleaning)
            {
                case "basic-1":
                    parameters = new StartCleaningParameters
                    {

                    };
                    break;
                case "minimal-2":
                    parameters = new StartCleaningParameters
                    {

                    };
                    break;
                case "minimal-3":
                    parameters = new StartCleaningParameters
                    {

                    };
                    break;
                case "basic-3":
                    parameters = new StartCleaningParameters
                    {

                    };
                    break;
                case "basic-4":
                default:
                    parameters = new StartCleaningParameters
                    {

                    };
                    break;
            }

            await _nucleoClient.StartCleaningAsync(parameters);
        }
    }
}
