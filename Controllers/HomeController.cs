using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.AccessControl;
using System;
using Microsoft.AspNetCore.Mvc;
using LanguageFeatures.Models;
using System.Collections.Generic;
using System.Linq;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ViewResult> Index() {
            // return View(new string[] { 'C#', 'Language', 'Features' });
            // return View("Index", "C#");

            /* return View("Index", Product.GetProducts()
                .Where(p => p != null)
                .Select(p => String.Format(
                    "Name: {0}, Price: {1}, Related Product: {2}",
                    p.Name,
                    p.Price,
                    p.Related?.Name ?? "<None>"
                    ))
                .ToList()); */
                // long? result = await TryGetRemoteData();
            // if (result != null)
            string result = await TryGetRemoteData();
            if (result != null)
            {
                return View("Index", new List<string>(){result.ToString()});
            }
            return View("Index", new List<string>());
        }

        // public Task<bool> TryGetRemoteData(out string data) {
        //     HttpClient client = new HttpClient();
        //     var httpTask = client.GetAsync(@"http://apress.com");
        //     return httpTask. ContinueWith<bool>((Task<HttpResponseMessage> response) => {
        //         try
        //         {
        //             data = response.Result.Content.Headers.ContentLength.ToString();
        //             return true;
        //         }
        //         catch (System.Exception)
        //         {
        //             return false;
        //         }
        //     });
        // }

        // public Task<long?> TryGetRemoteData() {
        public Task<string> TryGetRemoteData() {
                HttpClient client = new HttpClient();
                var httpTask = client.GetAsync(@"http://apress.com");
                return httpTask.ContinueWith(async (Task<HttpResponseMessage> response) => {
                    // return response.Result.Content.Headers.ContentLength;
                    string result = await await response.Result.Content.ReadAsStringAsync();
                    return result;
                });
        }
    }
}