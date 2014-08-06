using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml.Linq;
using Thermo.DAL;
using Thermo.Helpers;
using Thermo.Mailers;
using Thermo.Models;
using Thermo.Services;

namespace Thermo.Controllers
{

    
    public class Reponse
    {
        public string Value { get; set; }
    }


    public class ReceiveController : ApiController
    {
        //
        // POST : api/Receive
        ModuleEquipementContext db = new ModuleEquipementContext();
        [System.Web.Mvc.HttpPost]
        public async Task<HttpResponseMessage> PostReceive([FromBody]List<Sonde> enregs)
        {

            foreach (Sonde enreg in enregs)
            {
                
                ReceiveService receiveservice = new ReceiveService();


                
                Task<Enregistrement> setereg = receiveservice.setEnregAsync(enreg);

                Task<Value> setValue = receiveservice.setValueAsync(enreg);
                await Task.WhenAll( setValue);




            }
            Reponse reponse = new Reponse();
            reponse.Value = "OK";
            return Request.CreateResponse(HttpStatusCode.OK,reponse);
        }


        public bool FirstHight(Value valeur, int hightalarme, DateTime date, int firstalarme)
        {
            bool test = false;
            Value previous = db.Values.Find(valeur.ValueId - 1);
            if (previous.Val >= hightalarme)
            {
                TimeSpan TS = previous.DateCreation - date;
                int intervalle = TS.Minutes;
                if (intervalle >= firstalarme)
                {
                    test = true;
                }
                else
                {
                    test = FirstHight(previous, hightalarme, date, firstalarme);
                }
            }
            return test;
        }
        public bool Firstlow(Value valeur, int hightalarme, DateTime date, int firstalarme)
        {
            bool test = false;
            Value previous = db.Values.Find(valeur.ValueId - 1);
            if (previous.Val <= hightalarme)
            {
                TimeSpan TS = previous.DateCreation - date;
                int intervalle = TS.Minutes;
                if (intervalle <= firstalarme)
                {
                    test = true;
                }
                else
                {
                    test = FirstHight(previous, hightalarme, date, firstalarme);
                }
            }
            return test;
        }
    }
}
