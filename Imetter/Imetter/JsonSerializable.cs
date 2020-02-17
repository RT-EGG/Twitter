using System.IO;
using Newtonsoft.Json;

namespace Imetter
{
    class JsonSerializable
    {
        public void ExportToFile(string inPath)
        {
            string raw = JsonConvert.SerializeObject(this);
            using (StreamWriter output = new StreamWriter(new FileStream(inPath, FileMode.Create, FileAccess.Write))) {
                output.WriteLine(raw);
            }

            return;
        }

        public static T LoadFromFile<T>(string inPath) where T : JsonSerializable
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
