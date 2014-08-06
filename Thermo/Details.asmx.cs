using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Services;
using System.Xml.Linq;
using Thermo.DAL;
using Thermo.Models;
using System.Web.Http;
using System.Web.Mvc;

namespace Thermo
{
    /// <summary>
    /// Summary description for Details
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Details : System.Web.Services.WebService
    {
        ModuleEquipementContext db = new ModuleEquipementContext();
        //
        // POST: 
        [WebMethod]
        public HttpResponseMessage Receive() 
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
                value.Sondeid = temp.Element("{http://www.embeddeddatasystems.com/schema/owserver}ROMId").Value;
                value.Value = float.Parse(val, CultureInfo.InvariantCulture.NumberFormat);
                db.SaveChanges();



            }
            HttpRequestMessage request = new HttpRequestMessage();

            return request.CreateResponse(HttpStatusCode.OK, value);
        }
    }
}
