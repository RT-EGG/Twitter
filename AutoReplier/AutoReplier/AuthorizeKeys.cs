﻿using Newtonsoft.Json;
using System.IO;

namespace AutoReplier
{
    class AuthorizeKeys
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

        public void ExportToFile(string inPath)
        {
            string raw = JsonConvert.SerializeObject(this);
            using (StreamWriter output = new StreamWriter(new FileStream(inPath, FileMode.Create, FileAccess.Write))) {
                output.WriteLine(raw);
            }

            return;
        }

        public static T LoadFromFile<T>(string inPath) where T : AuthorizeKeys
        {
            if (!File.Exists(inPath))
                return null;

            using (StreamReader input = new StreamReader(new FileStream(inPath, FileMode.Open, FileAccess.Read))) {
                string text = input.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(text);
            }
        }
    }
}
