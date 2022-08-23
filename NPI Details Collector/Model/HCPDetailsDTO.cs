using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPI_Details_Collector.Model
{
    internal class HCPDetailsDTO
    {
        public long UserWaveID { get; set; }
        [JsonProperty("results")]
        public List<HCPDetail>? HCPDetails { get; set; }
    }
    class HCPDetail
    {
        [JsonProperty("number")]
        public long NPI { get; set; }
        [JsonProperty("basic")]
        public UserDetail? UserDetails { get; set; }
        [JsonProperty("addresses")]
        public List<Address>? Addresses { get; set; }
        [JsonProperty("taxonomies")]
        public List<Taxonomy>? Taxonomies { get; set; }
    }
    class UserDetail
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; } = string.Empty;
        [JsonProperty("last_name")]
        public string LastName { get; set; } = string.Empty;
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; } = string.Empty;
        [JsonProperty("credential")]
        public string Credential { get; set; } = string.Empty;
        [JsonProperty("gender")]
        public string Gender { get; set; } = string.Empty;
        [JsonProperty("last_updated")]
        public DateTime CertificationDate { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;
    }
    class Address
    {
        [JsonProperty("country_code")]
        public string CountryCode { get; set; } = string.Empty;
        [JsonProperty("address_purpose")]
        public string AddressPurpose { get; set; } = string.Empty;
        [JsonProperty("country_name")]
        public string CountryName { get; set; } = string.Empty;
        [JsonProperty("address_1")]
        public string HouseAddress { get; set; } = string.Empty;
        [JsonProperty("address_2")]
        public string StreetAddress { get; set; } = string.Empty;
        [JsonProperty("city")]
        public string City { get; set; } = string.Empty;
        [JsonProperty("state")]
        public string State { get; set; } = string.Empty;
        [JsonProperty("postal_code")]
        public long PostalCode { get; set; }
    }
    class Taxonomy
    {
        [JsonProperty("desc")]
        public string Description { get; set; } = string.Empty;
        [JsonProperty("primary")]
        public bool Primary { get; set; } = false;
        [JsonProperty("state")]
        public string State { get; set; } = string.Empty;
        [JsonProperty("license")]
        public string License { get; set; } = string.Empty;
    }
}
