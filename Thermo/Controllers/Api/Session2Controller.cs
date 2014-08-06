using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace Thermo.Controllers.Api
{
    public class Session2Controller : ApiController
    {
        // GET api/session2
        public IEnumerable<string> Get()
        {
            HttpContext.Current.Session["User"] = null;
            return new string[] { "value1", "value2" };
        }

        // GET api/session2/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/session2
        public Object Post([FromBody]Object value)
        {
           
            return new Object[] {1};
        }

        // PUT api/session/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/session/5
        public void Delete(int id)
        {
        }
    }
}
