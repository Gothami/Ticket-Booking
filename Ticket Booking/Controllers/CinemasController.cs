using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Ticket_Booking.Models;

namespace Ticket_Booking.Controllers
{
    public class CinemasController : Controller
    {
        // GET: Cinemas
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddScreenLayout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddScreenLayout(string[] DynamicTextBox, HttpPostedFileBase uploadFile,UploadScreenLayoutModel model)
        {
            var content = new MultipartFormDataContent();
            byte[] Bytes = new byte[uploadFile.ContentLength + 1];
            uploadFile.InputStream.Read(Bytes, 0, Bytes.Length);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:47058/api/screen");

            model.screenLayout = Bytes;
            model.seatZones = DynamicTextBox;
            var myContent = JsonConvert.SerializeObject(model);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseTask = client.PostAsync(client.BaseAddress, byteContent).Result;
            
            if (responseTask.StatusCode == HttpStatusCode.Created)
            {
                var readTask = responseTask.Content.ReadAsAsync<IList<string>>().Result;
            }
            return View();
        }

        [HttpGet]
        public FileContentResult ShowZone(string movieName, string screenName)
                    //public ActionResult ShowZone()

        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:47058/api/screen?screenName=" + screenName);
            HttpResponseMessage responseTask = client.GetAsync(client.BaseAddress).Result;
            byte[] imgContent = responseTask.Content.ReadAsByteArrayAsync().Result;
            
            return new FileContentResult(imgContent, "image/bmp");
        }




    }
}