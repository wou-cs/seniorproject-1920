using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AJAX_Example2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Home/Gimme/100
        public JsonResult Gimme(int? id = 100)
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

        // GET air quality data from: https://docs.openaq.org/
        public JsonResult AirQuality(string city)
        {
            
            string cityClean = city.Replace(" ", "+");
            Debug.WriteLine(cityClean);
            string uri = "https://api.openaq.org/v1/measurements?location=" + cityClean;
            Debug.WriteLine(uri);
            string data = SendRequest(uri);
            JObject obj = JObject.Parse(data);
            int count = (int)obj["meta"]["limit"];
            List<int> airQualityList = new List<int>();
            List<int> index = new List<int>();
            List<string> dates = new List<string>();
            for(int i = 0; i < count; ++i )
            {
                index.Add(i);
                airQualityList.Add((int)obj["results"][i]["value"]);
                dates.Add(((DateTime)obj["results"][i]["date"]["utc"]).ToString());
            }

            var jsonData = new
            {
                n = count,
                x = index,
                xdate = dates,
                y = airQualityList
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
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