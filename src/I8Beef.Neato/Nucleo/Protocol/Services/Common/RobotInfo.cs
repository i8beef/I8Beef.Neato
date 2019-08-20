using System;
using Newtonsoft.Json;

namespace I8Beef.Neato.Nucleo.Protocol.Services.Common
{
    /// <summary>
    /// Robot information.
    /// </summary>
    public class RobotInfo
    {
        /// <summary>
        /// Model name.
        /// </summary>
        [JsonProperty(PropertyName = "modelName")]
        public string ModelNameType { get; set; }

        /// <summary>
        /// CPU MAC ID.
        /// </summary>
        [JsonProperty(PropertyName = "CPUMACID")]
        public string CpuMacId { get; set; }

        /// <summary>
        /// Main board manfacturing date.
        /// </summary>
        [JsonProperty(PropertyName = "MainBrdMfgDate")]
        public string MainBrdMfgDate { get; set; }

        /// <summary>
        /// Robot manfacturing date.
        /// </summary>
        [JsonProperty(PropertyName = "RobotMfgDate")]
        public string RobotMfgDate { get; set; }

        /// <summary>
        /// Robot manfacturing date.
        /// </summary>
        [JsonProperty(PropertyName = "BoardRev")]
        public int BoardRev { get; set; }

        /// <summary>
        /// Chassis revision.
        /// </summary>
        [JsonProperty(PropertyName = "ChassisRev")]
        public int ChassisRev { get; set; }

        /// <summary>
        /// Battery type.
        /// </summary>
        [JsonProperty(PropertyName = "BatteryType")]
        public int BatteryType { get; set; }

        /// <summary>
        /// Wheel pod type.
        /// </summary>
        [JsonProperty(PropertyName = "WheelPodType")]
        public int WheelPodType { get; set; }

        /// <summary>
        /// Drop sensor type.
        /// </summary>
        [JsonProperty(PropertyName = "DropSensorType")]
        public int DropSensorType { get; set; }

        /// <summary>
        /// Mag sensor type.
        /// </summary>
        [JsonProperty(PropertyName = "MagSensorType")]
        public int MagSensorType { get; set; }

        /// <summary>
        /// Wall sensor type.
        /// </summary>
        [JsonProperty(PropertyName = "WallSensorType")]
        public int WallSensorType { get; set; }

        /// <summary>
        /// LDS Motor type.
        /// </summary>
        [JsonProperty(PropertyName = "LDSMotorType")]
        public int LDSMotorType { get; set; }

        /// <summary>
        /// Locale.
        /// </summary>
        [JsonProperty(PropertyName = "Locale")]
        public int Locale { get; set; }

        /// <summary>
        /// US mode.
        /// </summary>
        [JsonProperty(PropertyName = "USMode")]
        public int USMode { get; set; }

        /// <summary>
        /// Model name.
        /// </summary>
        [JsonProperty(PropertyName = "ModelName")]
        public string ModelName { get; set; }

        /// <summary>
        /// Neato server.
        /// </summary>
        [JsonProperty(PropertyName = "NeatoServer")]
        public int? NeatoServer { get; set; }

        /// <summary>
        /// Cart ID.
        /// </summary>
        [JsonProperty(PropertyName = "CartID")]
        public int CartID { get; set; }

        /// <summary>
        /// Brush speed.
        /// </summary>
        [JsonProperty(PropertyName = "brushSpeed")]
        public int BrushSpeed { get; set; }

        /// <summary>
        /// Brush Speed Eco.
        /// </summary>
        [JsonProperty(PropertyName = "brushSpeedEco")]
        public int BrushSpeedEco { get; set; }

        /// <summary>
        /// Vacuum speed.
        /// </summary>
        [JsonProperty(PropertyName = "vacuumSpeed")]
        public int VacuumSpeed { get; set; }

        /// <summary>
        /// Vacuum power Percent.
        /// </summary>
        [JsonProperty(PropertyName = "vacuumPwrPercent")]
        public int VacuumPwrPercent { get; set; }

        /// <summary>
        /// Vacuum Power Percent Eco.
        /// </summary>
        [JsonProperty(PropertyName = "vacuumPwrPercentEco")]
        public int VacuumPwrPercentEco { get; set; }

        /// <summary>
        /// Run time.
        /// </summary>
        [JsonProperty(PropertyName = "runTime")]
        public int RunTime { get; set; }

        /// <summary>
        /// Brush Present.
        /// </summary>
        [JsonProperty(PropertyName = "BrushPresent")]
        public int BrushPresent { get; set; }

        /// <summary>
        /// Vacuum present.
        /// </summary>
        [JsonProperty(PropertyName = "VacuumPresent")]
        public int VacuumPresent { get; set; }

        /// <summary>
        /// PAD present.
        /// </summary>
        [JsonProperty(PropertyName = "PadPresent")]
        public int PadPresent { get; set; }

        /// <summary>
        /// Platen present
        /// </summary>
        [JsonProperty(PropertyName = "PlatenPresent")]
        public int PlatenPresent { get; set; }

        /// <summary>
        /// Brush direction.
        /// </summary>
        [JsonProperty(PropertyName = "BrushDirection")]
        public int BrushDirection { get; set; }

        /// <summary>
        /// Vacuum direction.
        /// </summary>
        [JsonProperty(PropertyName = "VacuumDirection")]
        public int VacuumDirection { get; set; }

        /// <summary>
        /// Pad direction.
        /// </summary>
        [JsonProperty(PropertyName = "PadDirection")]
        public int PadDirection { get; set; }

        /// <summary>
        /// Cumulative cartridge time in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "CumulativeCartridgeTimeInSecs")]
        public int CumulativeCartridgeTimeInSecs { get; set; }

        /// <summary>
        /// N cleanings started where dust bin was full.
        /// </summary>
        [JsonProperty(PropertyName = "nCleaningsStartedWhereDustBinWasFull")]
        public int NCleaningsStartedWhereDustBinWasFull { get; set; }

        /// <summary>
        /// Blower type.
        /// </summary>
        [JsonProperty(PropertyName = "BlowerType")]
        public int BlowerType { get; set; }

        /// <summary>
        /// Brush motor type.
        /// </summary>
        [JsonProperty(PropertyName = "BrushMotorType")]
        public int BrushMotorType { get; set; }

        /// <summary>
        /// Side brush type.
        /// </summary>
        [JsonProperty(PropertyName = "SideBrushType")]
        public int SideBrushType { get; set; }

        /// <summary>
        /// Side brush power.
        /// </summary>
        [JsonProperty(PropertyName = "SideBrushPower")]
        public int SideBrushPower { get; set; }

        /// <summary>
        /// N auto cycle cleanings started.
        /// </summary>
        [JsonProperty(PropertyName = "nAutoCycleCleaningsStarted")]
        public int NAutoCycleCleaningsStarted { get; set; }

        /// <summary>
        /// Hardware version major.
        /// </summary>
        [JsonProperty(PropertyName = "hardware_version_major")]
        public int HardwareVersionMajor { get; set; }

        /// <summary>
        /// Hardware version minor.
        /// </summary>
        [JsonProperty(PropertyName = "hardware_version_minor")]
        public int HardwareVersionMinor { get; set; }

        /// <summary>
        /// Software version major.
        /// </summary>
        [JsonProperty(PropertyName = "software_version_major")]
        public int SoftwareVersionMajor { get; set; }

        /// <summary>
        /// Software version minor.
        /// </summary>
        [JsonProperty(PropertyName = "software_version_minor")]
        public int SoftwareVersionMinor { get; set; }

        /// <summary>
        /// Max voltage.
        /// </summary>
        [JsonProperty(PropertyName = "max_voltage")]
        public int MaxVoltage { get; set; }

        /// <summary>
        /// Max current.
        /// </summary>
        [JsonProperty(PropertyName = "max_current")]
        public int MaxCurrent { get; set; }

        /// <summary>
        /// Voltage multiplier.
        /// </summary>
        [JsonProperty(PropertyName = "voltage_multiplier")]
        public int VoltageMultiplier { get; set; }

        /// <summary>
        /// Crrent multiplier.
        /// </summary>
        [JsonProperty(PropertyName = "current_multiplier")]
        public int CurrentMultiplier { get; set; }

        /// <summary>
        /// Capacity mode.
        /// </summary>
        [JsonProperty(PropertyName = "capacity_mode")]
        public int CapacityMode { get; set; }

        /// <summary>
        /// Design capacity
        /// </summary>
        [JsonProperty(PropertyName = "design_capacity")]
        public int DesignCapacity { get; set; }

        /// <summary>
        /// Design voltage.
        /// </summary>
        [JsonProperty(PropertyName = "design_voltage")]
        public int DesignVoltage { get; set; }

        /// <summary>
        /// Manufacturing day.
        /// </summary>
        [JsonProperty(PropertyName = "mfg_day")]
        public int ManufacturingDay { get; set; }

        /// <summary>
        /// Manufacturing month.
        /// </summary>
        [JsonProperty(PropertyName = "mfg_month")]
        public int ManufacturingMonth { get; set; }

        /// <summary>
        /// Manufacturing year.
        /// </summary>
        [JsonProperty(PropertyName = "mfg_year")]
        public int ManufacturingYear { get; set; }

        /// <summary>
        /// Serial number.
        /// </summary>
        [JsonProperty(PropertyName = "serial_number")]
        public int SerialNumber { get; set; }

        /// <summary>
        /// Software version.
        /// </summary>
        [JsonProperty(PropertyName = "sw_ver")]
        public int SoftwareVersion { get; set; }

        /// <summary>
        /// Data version.
        /// </summary>
        [JsonProperty(PropertyName = "data_ver")]
        public int DataVersion { get; set; }

        /// <summary>
        /// Manufacturing access.
        /// </summary>
        [JsonProperty(PropertyName = "mfg_access")]
        public int ManufacturingAccess { get; set; }

        /// <summary>
        /// Manufacturing name.
        /// </summary>
        [JsonProperty(PropertyName = "mfg_name")]
        public string ManufacturingName { get; set; }

        /// <summary>
        /// Device name.
        /// </summary>
        [JsonProperty(PropertyName = "device_name")]
        public string DeviceName { get; set; }

        /// <summary>
        /// Chemistry name.
        /// </summary>
        [JsonProperty(PropertyName = "chemistry_name")]
        public string ChemistryName { get; set; }

        /// <summary>
        /// Major version.
        /// </summary>
        [JsonProperty(PropertyName = "Major")]
        public int Major { get; set; }

        /// <summary>
        /// Minor version.
        /// </summary>
        [JsonProperty(PropertyName = "Minor")]
        public int Minor { get; set; }

        /// <summary>
        /// Build version.
        /// </summary>
        [JsonProperty(PropertyName = "Build")]
        public int Build { get; set; }

        /// <summary>
        /// LDS version.
        /// </summary>
        [JsonProperty(PropertyName = "ldsVer")]
        public string LdsVer { get; set; }

        /// <summary>
        /// LDS Serial.
        /// </summary>
        [JsonProperty(PropertyName = "ldsSerial")]
        public string LdsSerial { get; set; }

        /// <summary>
        /// LDS CPU.
        /// </summary>
        [JsonProperty(PropertyName = "ldsCPU")]
        public string LdsCPU { get; set; }

        /// <summary>
        /// LDS build number.
        /// </summary>
        [JsonProperty(PropertyName = "ldsBuildNum")]
        public string LdsBuildNum { get; set; }

        /// <summary>
        /// Bootloader version.
        /// </summary>
        [JsonProperty(PropertyName = "bootLoaderVersion")]
        public int BootLoaderVersion { get; set; }

        /// <summary>
        /// UI board software version.
        /// </summary>
        [JsonProperty(PropertyName = "uiBoardSWVer")]
        public int UiBoardSoftwareVer { get; set; }

        /// <summary>
        /// UI board hardware version.
        /// </summary>
        [JsonProperty(PropertyName = "uiBoardHWVer")]
        public int UiBoardHardwareVer { get; set; }

        /// <summary>
        /// QA state.
        /// </summary>
        [JsonProperty(PropertyName = "qaState")]
        public int QaState { get; set; }

        /// <summary>
        /// Manufacturer
        /// </summary>
        [JsonProperty(PropertyName = "manufacturer")]
        public int Manufacturer { get; set; }

        /// <summary>
        /// Driver version.
        /// </summary>
        [JsonProperty(PropertyName = "driverVersion")]
        public int DriverVersion { get; set; }

        /// <summary>
        /// Driver ID.
        /// </summary>
        [JsonProperty(PropertyName = "driverID")]
        public int DriverID { get; set; }

        /// <summary>
        /// Ultrasonic software version.
        /// </summary>
        [JsonProperty(PropertyName = "ultrasonicSW")]
        public int UltrasonicSoftware { get; set; }

        /// <summary>
        /// Ultrasonic hardware version.
        /// </summary>
        [JsonProperty(PropertyName = "ultrasonicHW")]
        public int UltrasonicHardware { get; set; }

        /// <summary>
        /// Blower hardware version.
        /// </summary>
        [JsonProperty(PropertyName = "blowerHW")]
        public int BlowerHardware { get; set; }

        /// <summary>
        /// Blower software version major number.
        /// </summary>
        [JsonProperty(PropertyName = "blowerSWMajor")]
        public int BlowerSoftwareMajor { get; set; }

        /// <summary>
        /// Blower software version minor number.
        /// </summary>
        [JsonProperty(PropertyName = "blowerSWMinor")]
        public int BlowerSoftwareMinor { get; set; }
    }
}
