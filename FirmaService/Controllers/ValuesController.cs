using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PersonelDataAccsess;
namespace FirmaService.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public Personel Get(int id)
        {
            NovapmEntities db = new NovapmEntities();
           var a= db.Personel.FirstOrDefault(w=>w.ID==id);
            return a;
        }

        // GET api/values/5
        public string Get()
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
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
