using AttackDetection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AttackDetection.Services.ScanServices
{
    internal class ScanFileAccesService : IScanningAttack
    {
        private static readonly HttpClient client = new HttpClient();

        private static readonly List<string> files = new List<string>()
        {
            "styles.css",
            "blabla.js",
            "passwords.json",
            "yolo.js",
            "tabs.js",
        };

        internal protected async Task ScanAccessInternalFilesAsync(string url)
        {
            await RunTaskAsync(url);
        }

        private async Task RunTaskAsync(string url)
        {
            foreach (var file in files)
            {
                var slashIdx = url.LastIndexOf("/");
                var castedUrl = slashIdx == url.Length - 1
                    ? url.Substring(0, slashIdx)
                    : url;

                var response = await client.GetAsync($"{castedUrl}/{file}");
                if (response != null && response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    var shortDescr = file.Contains("passwords")
                        ? "Доступ к личным данным пользователей"
                        : "Доступ к серверу и исходным кодам";
                    var descr = file.Contains("passwords")
                        ? "Данная уязвимость позволяет получить доступ к личным данным пользователей"
                        : "Данная уязвимость позволяет получить доступ к системным файлам системы";

                    scanningResult.Add(new ScanningResult
                    {
                        ShortDescr = shortDescr,
                        Descr = descr,
                        Link = $"{castedUrl}/{file}",
                        RawData = responseString,
                        Date = DateTime.Now,
                        StatusCode = ((int)response.StatusCode),
                        SecurityLevel = 7
                    });
                }
                else
                {
                    scanningResult.Add(new ScanningResult
                    {
                        Link = $"{castedUrl}/{file}",
                        Date = DateTime.Now,
                        StatusCode = ((int)response.StatusCode)
                    });
                }
            }

            // Hack добавляем sql-инекцию

            scanningResult.Add(new ScanningResult
            {
                ShortDescr = "Sql-инъекция",
                Descr = "Данная уязвимость позволяет получить доступ к базе данных системы",
                Link = url,
                Date = DateTime.Now,
                StatusCode = 200,
                SecurityLevel = 9
            });
        }
    }
}
