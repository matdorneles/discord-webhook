

using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace DiscordWebhook

{
    internal class Logs
    {
        public static void Main()
        {
            string webhook = ""; // paste your discord webhook url

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            WebRequest wr = (HttpWebRequest)WebRequest.Create(webhook);

            wr.ContentType = "application/json";
            wr.Method = "POST";
            using (var sw = new StreamWriter(wr.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    username = "",
                    avatar_url = "",
                    content = "here we can write up to 2000 characters",
                    embeds = new[]
                    {
                        new
                        {
                            title = "New Vehicle Spawned!",
                            description = "**userName** has spawned a new **vehicleModel**",
                            fields = new []
                            {
                                new
                                {
                                    name = "Steam Hex: ",
                                    value = "steamHexId",
                                    inline = true
                                }
                            }
                        }
                    }
                });

                sw.Write(json);
            }

            _ = (HttpWebResponse)wr.GetResponse();
        }
    }
}
