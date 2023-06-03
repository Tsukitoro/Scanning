using System.Collections.Generic;
using System.Net.Http;

namespace AttackDetection.Services
{
    internal class ScanningService
    {
        private string url = "";
        private static readonly HttpClient client = new HttpClient();

        private static readonly List<string> files = new List<string>()
        {
            "styles.css",
            "blabla.js",
            "passwords.json",
            "yolo.js",
            "tabs.js",
        };

        internal void ChangeUrl(string url)
        {
            this.url = url;
        }

        internal async void StartScan(Form4 sender)
        {
            var result = new List<List<string>>();
            foreach (var file in files)
            {
                var castedUrl = url.Substring(0, url.LastIndexOf('/'));
                var response = await client.GetAsync($"{castedUrl}/{file}");
                if (response != null && response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var row = new List<string>
                    {
                        $"{castedUrl}/{file}",
                        responseString
                    };

                    result.Add(row);
                }
            }

            sender.Update_Result(result);

            var asd = "";
        }
    }
}
