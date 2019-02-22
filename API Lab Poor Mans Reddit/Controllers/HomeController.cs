using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using API_Lab_Poor_Mans_Reddit.Models;
using Newtonsoft.Json.Linq;

namespace API_Lab_Poor_Mans_Reddit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Reddit()
        {

            HttpWebRequest request = WebRequest.CreateHttp("http://www.reddit.com/r/aww/.json");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();
            rd.Close();

            JObject redditJson = JObject.Parse(data);
            List<JToken> posts = redditJson["data"]["children"].ToList();
            List<Post> output = new List<Post>();
            for (int i = 0; i < posts.Count; i++)
            {
                Post rp = new Post();
                rp.Title = posts[i]["data"]["title"].ToString();
                rp.ImageURL = posts[i]["data"]["thumbnail"].ToString();
                rp.LinkURL = "http://reddit.com/" + posts[i]["data"]["permalink"].ToString();

                output.Add(rp);
            }
            return View(output);
        }
    }
}