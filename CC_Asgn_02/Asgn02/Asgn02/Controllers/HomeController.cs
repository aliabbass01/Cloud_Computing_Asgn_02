using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Asgn02.Models;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Asgn02.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewData()
        {
                //We will make a GET request to a really cool website...

                string baseUrl = "http://52.201.152.108/news?id=bcsf17a502";
                //The 'using' will help to prevent memory leaks.
                //Create a new instance of HttpClient
                using (HttpClient client = new HttpClient())

                //Setting up the response...         

                using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                using (HttpContent content = res.Content)
                {

                    dynamic data = null;
                    data = await content.ReadAsStringAsync();
                    object result = JsonSerializer.Deserialize<List<DataModel>>(data);
                    if (data != null)
                    {
                        return View(result);
                        //Console.WriteLine(data);
                    }
                }

                return View();
        }

        public IActionResult Load()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

