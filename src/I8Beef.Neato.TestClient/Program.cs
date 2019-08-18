using I8Beef.Neato.BeeHive;
using I8Beef.Neato.Nucleo;
using I8Beef.Neato.Nucleo.Protocol;
using I8Beef.Neato.Nucleo.Protocol.Services.HouseCleaning;
using I8Beef.Neato.Nucleo.Protocol.Services.Maps;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace I8Beef.Neato.TestClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        public static async Task MainAsync(string[] args)
        {
            var email = "";
            var password = "";

            if (string.IsNullOrEmpty(email))
            {
                Console.Write("Email: ");
                email = Console.ReadLine();
            }

            if (string.IsNullOrEmpty(password))
            {
                Console.Write("Password: ");
                password = Console.ReadLine();
            }

            var beeHiveClient = new BeeHiveClient(email, password);
            var robots = await beeHiveClient.GetRobotsAsync();

            Console.WriteLine();
            Console.WriteLine("Robots");
            Console.WriteLine("======");
            for  (var i = 0; i < robots.Count; i++)
            {
                Console.WriteLine(i + " - " + robots[i].Serial + " " + robots[i].SecretKey);
            }

            Console.WriteLine();
            Console.Write("Robot number to control: ");

            if (int.TryParse(Console.ReadLine(), out int robotId))
            {
                var serialNumber = robots[robotId].Serial;
                var secretKey = robots[robotId].SecretKey; ;

                var nucleoClient = new NucleoClient(serialNumber, secretKey);
                var robot = new Robot(nucleoClient);

                var exit = false;
                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine("Commands");
                    Console.WriteLine("========");
                    foreach (int commandType in Enum.GetValues(typeof(CommandType)))
                    {
                        Console.WriteLine(Enum.GetName(typeof(CommandType), commandType));
                    }
                    Console.WriteLine("Exit");

                    Console.WriteLine();
                    Console.Write("Command: ");
                    var command = Console.ReadLine();

                    Console.Clear();

                    switch (command)
                    {
                        case "DismissCurrentAlert":
                            await robot.DismissCurrentAlertAsync();
                            break;
                        case "FindMe":
                            await robot.FindMeAsync();
                            break;
                        case "GetGeneralInfo":
                            Console.WriteLine(JsonConvert.SerializeObject(await robot.GetGeneralInfoAsync(), Formatting.Indented));
                            Console.ReadKey();
                            break;
                        case "GetRobotInfo":
                            Console.WriteLine(JsonConvert.SerializeObject(await robot.GetRobotInfoAsync(), Formatting.Indented));
                            Console.ReadKey();
                            break;
                        case "StartCleaning":
                            await robot.StartCleaningAsync(new StartCleaningParameters
                            {
                                Category = CleaningCategory.SpotCleaning
                            });
                            break;
                        case "StopCleaning":
                            await robot.StopCleaningAsync();
                            break;
                        case "PauseCleaning":
                            await robot.PauseCleaningAsync();
                            break;
                        case "ResumeCleaning":
                            await robot.ResumeCleaningAsync();
                            break;
                        case "SendToBase":
                            await robot.SendToBaseAsync();
                            break;
                        case "GetLocalStats":
                            Console.WriteLine(JsonConvert.SerializeObject(await robot.GetLocalStatsAsync(), Formatting.Indented));
                            Console.ReadKey();
                            break;
                        case "GetRobotManualCleaningInfo":
                            Console.WriteLine(JsonConvert.SerializeObject(await robot.GetRobotManualCleaningInfoAsync(), Formatting.Indented));
                            Console.ReadKey();
                            break;
                        case "GetMapBoundaries":
                            Console.WriteLine(JsonConvert.SerializeObject(await robot.GetMapBoundariesAsync(new GetMapBoundaries { MapId = "" }), Formatting.Indented));
                            Console.ReadKey();
                            break;
                        case "SetMapBoundaries":
                            Console.WriteLine("Not supported in test app");
                            Console.ReadKey();
                            break;
                        case "StartPersistentMapExploration":
                            await robot.StartPersistentMapExplorationAsync();
                            break;
                        case "SetPreferences":
                            Console.WriteLine("Not supported in test app");
                            Console.ReadKey();
                            break;
                        case "GetPreferences":
                            Console.WriteLine(JsonConvert.SerializeObject(await robot.GetPreferencesAsync(), Formatting.Indented));
                            Console.ReadKey();
                            break;
                        case "SetSchedule":
                            Console.WriteLine("Not supported in test app");
                            Console.ReadKey();
                            break;
                        case "GetSchedule":
                            Console.WriteLine(JsonConvert.SerializeObject(await robot.GetScheduleAsync(), Formatting.Indented));
                            Console.ReadKey();
                            break;
                        case "EnableSchedule":
                            await robot.EnableScheduleAsync();
                            break;
                        case "DisableSchedule":
                            await robot.DisableScheduleAsync();
                            break;
                        case "Exit":
                            exit = true;
                            break;
                        case "GetRobotState":
                        default:
                            Console.WriteLine(JsonConvert.SerializeObject(await robot.GetRobotStateAsync(), Formatting.Indented));
                            Console.ReadKey();
                            break;
                    }
                }
            }
        }
    }
}
