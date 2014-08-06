using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Thermo.Helpers;
using Thermo.Models;

namespace Thermo.Controllers
{
    public class UploadController : Controller
    {
        //
        // GET: /Upload/

        public ActionResult Index()
        {
            
           /* List<Sonde> ListeSonde = new List<Sonde>();
            HttpClient client = new HttpClient();

            Sonde son = new Sonde()
            {
                Sondeid = "fqdf",
                Value = 65,
                DateTimeValue = DateTime.Now
            };
            ListeSonde.Add(son);
            client.BaseAddress = new Uri("http://localhost/Witrack/");



            client.DefaultRequestHeaders.Accept.Add(

               new MediaTypeWithQualityHeaderValue("application/json"));


            var response = client.PostAsJsonAsync("api/Receive", ListeSonde).Result;*/

            return View();
        }

        //
        // Post: /Upload/
        [HttpPost]
        public async Task<ActionResult> Index(IEnumerable<HttpPostedFileBase> details)
        {
            //IEnumerable<HttpPostedFileBase> details
             HttpPostedFileBase file = Request.Files["owServerData"];
             if (file.ContentLength > 0)
             {
                 var fileName = Path.GetFileName(file.FileName);
                 var fileExtension = Path.GetExtension(file.FileName);
                 var path = Path.Combine(Server.MapPath("~/uploads"), DateTime.Now.ToString("yyyy-mm-dd-HH-MM-ss") + fileExtension);
                 file.SaveAs(path);
                 
                 Task<List<Sonde>> read = Readxml(file);
                 await Task.WhenAll(read);
                 System.IO.File.Delete(path);
             }


            return RedirectToAction("Index");
        }

        public async Task<List<Sonde>> Readxml(HttpPostedFileBase file)
        {
              
            List<Sonde> ListeSonde = new List<Sonde>();
            string responseString = "";
            StreamReader streamReader = new StreamReader(file.InputStream);
            responseString = streamReader.ReadToEnd();
            file.InputStream.Close();
               if (responseString.Length > 0)
          {
                XmlDocument xmlDocument = new XmlDocument();

                xmlDocument.LoadXml(responseString);
                foreach (XmlNode xmlNode1 in xmlDocument.DocumentElement.ChildNodes)
                {
                    if (xmlNode1.LocalName == "owd_DS18S20")
                    {
                        Sonde sonde = new Sonde();
                        foreach (XmlNode xmlNode2 in xmlNode1.ChildNodes)
                        {
                            
                            
                            if (xmlNode2.LocalName == "Temperature")
                            {
                                Decimal num = Convert.ToDecimal((xmlNode2.InnerText).Replace('.', ',')); 
                                sonde.Value = (float) num;
                            }
                            if (xmlNode2.LocalName == "ROMId")
                                sonde.Sondeid = ((object)xmlNode2.InnerText).ToString();
                        }
                        sonde.DateTimeValue = DateTime.Now.ToUniversalTime().AddHours(1);
                        ListeSonde.Add(sonde);
                    }
                    if (xmlNode1.LocalName == "owd_EDS0065")
                    {
                        Sonde sonde = new Sonde();
                        foreach (XmlNode xmlNode2 in xmlNode1.ChildNodes)
                        {
                            if (xmlNode2.LocalName == "Humidity")
                            {
                                Decimal num = Convert.ToDecimal((xmlNode2.InnerText).Replace('.', ','));
                                sonde.Humidity = num;
                            }

                            if (xmlNode2.LocalName == "Temperature")
                            {
                                Decimal num = Convert.ToDecimal((xmlNode2.InnerText).Replace('.', ','));
                                sonde.Value = (float)num;
                            }
                            if (xmlNode2.LocalName == "ROMId")
                                sonde.Sondeid = ((object)xmlNode2.InnerText).ToString();
                        }
                        sonde.DateTimeValue = DateTime.Now.ToUniversalTime().AddHours(1);
                        ListeSonde.Add(sonde);
                    }
                }
                HttpClient client = new HttpClient();


                // client.BaseAddress = new Uri("http://maysoft2-001-site1.smarterasp.net/");
                client.BaseAddress = new Uri("http://localhost/Witrack/");



                client.DefaultRequestHeaders.Accept.Add(

                   new MediaTypeWithQualityHeaderValue("application/json"));


                var response = client.PostAsJsonAsync("api/Receive", ListeSonde).Result;
               }
               /*
                string responseString = "";
                 HttpClientHandler handler = new HttpClientHandler();
                 using (HttpClient httpClient = new HttpClient((HttpMessageHandler)handler))
                 {
                     httpClient.Timeout = TimeSpan.FromSeconds(10.0);
                     HttpContent content = (HttpContent)new StringContent("");
                     content.Headers.Add("Keep-Alive", "true");
                     content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                     try
                     {
                         HttpResponseMessage response = await httpClient.PostAsync(file, content);
                         Stream stream = await response.Content.ReadAsStreamAsync();
                         StreamReader streamReader = new StreamReader(stream);
                         responseString = streamReader.ReadToEnd();
                         stream.Close();
                     }
                     finally
                     {
                     }
                 }
                * HttpClient client = new HttpClient();

               Sonde son = new Sonde()
               {
                   Sondeid = "fqdf",
                   Value = 65,
                   DateTimeValue = DateTime.Now
               };
               ListeSonde.Add(son);
               client.BaseAddress = new Uri("http://localhost/Witrack/");



               client.DefaultRequestHeaders.Accept.Add(

                  new MediaTypeWithQualityHeaderValue("application/json"));


               var response = client.PostAsJsonAsync("api/Receive", ListeSonde).Result;*/

               return ListeSonde;
        }
    }
}
