using System.Collections.Generic;
using Newtonsoft.Json;

namespace I8Beef.Neato.Nucelo.Protocol.Services.Preferences
{
    /// <summary>
    /// Preferences.
    /// </summary>
    public class Preferences
    {
        /// <summary>
        /// Play Robot sounds.
        /// </summary>
        [JsonProperty(PropertyName = "robotSounds")]
        public bool RobotSounds { get; set; }

        /// <summary>
        /// Show dirt bin alert.
        /// </summary>
        [JsonProperty(PropertyName = "dirtbinAlert")]
        public bool DirtbinAlert { get; set; }

        /// <summary>
        /// Show generic robot alerts.
        /// </summary>
        [JsonProperty(PropertyName = "allAlerts")]
        public bool AllAlerts { get; set; }

        /// <summary>
        /// Turn on leds
        /// </summary>
        [JsonProperty(PropertyName = "leds")]
        public bool Leds { get; set; }

        /// <summary>
        /// Turn on button clicks
        /// </summary>
        [JsonProperty(PropertyName = "buttonClicks")]
        public bool ButtonClicks { get; set; }

        /// <summary>
        /// Define the dirt bin alert frequency (expressed in minutes). The accepted range is 30-150.
        /// </summary>
        [JsonProperty(PropertyName = "dirtbinAlertReminderInterval")]
        public int DirtbinAlertReminderInterval { get; set; }

        /// <summary>
        /// Define the filter change reminder frequency (expressed in minutes). The accepted range is 43200-129600 (1-3 months).
        /// </summary>
        [JsonProperty(PropertyName = "filterChangeReminderInterval")]
        public int FilterChangeReminderInterval { get; set; }

        /// <summary>
        /// Define the brush change reminder frequency (expressed in minutes). The accepted range is 172800-345600 (4-8 months).
        /// </summary>
        [JsonProperty(PropertyName = "brushChangeReminderInterval")]
        public int BrushChangeReminderInterval { get; set; }

        /// <summary>
        /// Sets the clock to 24h (true) or 12h (false) format.
        /// </summary>
        [JsonProperty(PropertyName = "clock24h")]
        public bool Clock24h { get; set; }

        /// <summary>
        /// The locale code.
        /// </summary>
        [JsonProperty(PropertyName = "locale")]
        public bool Locale { get; set; }

        /// <summary>
        /// Available locale codes.
        /// </summary>
        [JsonProperty(PropertyName = "availableLocales")]
        public IList<string> AvailableLocales { get; set; }
    }
}
