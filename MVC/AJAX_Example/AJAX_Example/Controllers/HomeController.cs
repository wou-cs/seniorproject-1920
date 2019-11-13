using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AJAX_Example.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult RandomNumbers(int? id = 100)
        {
            Random gen = new Random();
            var data = new
            {
                message = "Random Numbers API",
                num = (int)id,
                numbers1 = Enumerable.Range(1, (int)id),
                numbers = Enumerable.Range(1, (int)id).Select(x => gen.Next(1000))
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Earthquakes()
        {
            string json = SendRequest("https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/2.5_day.geojson");

            JObject geo = JObject.Parse(json);
            int count = (int)geo["metadata"]["count"];
            List<string> output = new List<string>();
            for(int i = 0; i < count; i++)
            {
                double mag = (double)geo["features"][i]["properties"]["mag"];
                string location = (string)geo["features"][i]["properties"]["place"];
                output.Add($"{location}: {mag}");
            }
            Debug.WriteLine($"{count},{output}");
            string jsonString = JsonConvert.SerializeObject(output, Formatting.Indented);
            return new ContentResult
            {
                Content = jsonString,
                ContentType = "application/json",
                ContentEncoding = System.Text.Encoding.UTF8
            };
        }

        private string SendRequest(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Accept = "application/json";

            string jsonString = null;
            // TODO: You should handle exceptions here
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }
    }
}