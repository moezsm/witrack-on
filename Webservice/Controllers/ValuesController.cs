using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace Webservice.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            XDocument xdoc = XDocument.Load("http://192.168.1.4/details.xml");
            //var temperature = from item in xdoc.Descendants("owd_DS18S20") select item.Element("Name");
            var temperature = xdoc.Element("{http://www.embeddeddatasystems.com/schema/owserver}Devices-Detail-Response").Descendants("{http://www.embeddeddatasystems.com/schema/owserver}owd_DS18S20");
            //ViewData["temperature"] = temperature.ToString();
            int i = temperature.Count();
            Enregistrement value = new Enregistrement();
            foreach (var temp in temperature)
            {



                var val = temp.Element("{http://www.embeddeddatasystems.com/schema/owserver}Temperature").Value;
                // ViewData["temperature"] = temp.Element("{http://www.embeddeddatasystems.com/schema/owserver}Temperature").Value;
                db.Enregistrements.Add(value);
                value.Numero = temp.Element("{http://www.embeddeddatasystems.com/schema/owserver}ROMId").Value;
                value.Val = float.Parse(val, CultureInfo.InvariantCulture.NumberFormat);
                db.SaveChanges();



            }
            return Request.CreateResponse(HttpStatusCode.OK, value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}