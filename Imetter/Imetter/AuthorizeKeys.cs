using Newtonsoft.Json;

namespace Imetter
{
    class AuthorizeKeys : JsonSerializable
    {
        public class ApplicationKeys : AuthorizeKeys
        {
            [JsonProperty("ConsumerKey")]
            public string ConsumerKey
            { get; set; } = "";

            [JsonProperty("ConsumerSecret")]
            public string ConsumerSecret
            { get; set; } = "";
        }

        public class AccessKeys : AuthorizeKeys
        {
            [JsonProperty("AccessToken")]
            public string AccessToken
            { get; set; } = "";

            [JsonProperty("AccessSecret")]
            public string AccessSecret
            { get; set; } = "";
        }
    }
}
