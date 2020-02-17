using Newtonsoft.Json;
using System;

namespace Imetter
{
    class ThreadConfiguration
    {
        [JsonProperty(PropertyName = "keyword")]
        public string Keyword
        { get; set; } = "";

        [JsonProperty(PropertyName = "save_directories")]
        public string[] SaveDirectories
        { get; set; } = Array.Empty<string>();

        [JsonProperty(PropertyName = "")]
        public string SaveFileNamePattern
        { get; set; } = "<YYYYMMDDHHNN>?U?I";
    }
}
