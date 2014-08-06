using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Thermo.DAL;
using Thermo.Helpers;
using Thermo.Models;
using Thermo.Services;
using WebMatrix.WebData;
using System.Net.Http;

namespace Thermo.Services
{
    public class LocationService
    {
        ModuleEquipementContext  db = new ModuleEquipementContext();
        public async Task<IEnumerable<Location>> GetLocationAsync(int clientid)
        {
            IEnumerable<Location> locations = db.Locations.Where(equi => equi.UserID == clientid).ToList();
            return locations;
        }
    }
}