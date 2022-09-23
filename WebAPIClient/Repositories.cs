using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPIClient
{
    public class Repositories
    {
        //Overrule the naming convention by adding an attribute, that allows you to follow the Pascal rules. 
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("homepage")]
        public Uri? Homepage { get; set; }

        [JsonPropertyName("watchers")]
        public int? Watchers { get; set; }

        [JsonPropertyName("pushed_at")]
        public DateTime LastPushUtc { get; set; }

        public DateTime LastPush => LastPushUtc.ToLocalTime();
    }
}
