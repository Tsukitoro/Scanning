using AttackDetection.Models;
using AttackDetection.Services.ScanServices;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AttackDetection.Services
{
    internal class ScanningService
    {
        private string url = "";

        internal void ChangeUrl(string url)
        {
            this.url = url;
        }

        internal async void StartScan(Form4 sender)
        {
            var service = new ScanFileAccesService();
            await service.ScanAccessInternalFilesAsync(url);

            var result = service.GetCollectedData();
            sender.Update_Result(result);
        }
    }
}
