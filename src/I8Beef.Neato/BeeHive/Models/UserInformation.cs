using Newtonsoft.Json;

namespace I8Beef.Neato.BeeHive.Models
{
    /// <summary>
    /// User information.
    /// </summary>
    public class UserInformation
    {
        /// <summary>
        /// City.
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        /// <summary>
        /// Company.
        /// </summary>
        [JsonProperty(PropertyName = "company")]
        public string Company { get; set; }

        /// <summary>
        /// Country code.
        /// </summary>
        [JsonProperty(PropertyName = "country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Locale.
        /// </summary>
        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Phone number.
        /// </summary>
        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Post code.
        /// </summary>
        [JsonProperty(PropertyName = "post_code")]
        public string PostCode { get; set; }

        /// <summary>
        /// Province.
        /// </summary>
        [JsonProperty(PropertyName = "province")]
        public string Province { get; set; }

        /// <summary>
        /// State or region.
        /// </summary>
        [JsonProperty(PropertyName = "state_region")]
        public string StateRegion { get; set; }

        /// <summary>
        /// Street 1.
        /// </summary>
        [JsonProperty(PropertyName = "street_1")]
        public string Street1 { get; set; }

        /// <summary>
        /// Street 2.
        /// </summary>
        [JsonProperty(PropertyName = "street_2")]
        public string Street2 { get; set; }
    }
}
