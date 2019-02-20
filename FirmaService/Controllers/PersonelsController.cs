using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PersonelDataAccsess;
using System.Web.Mvc;
namespace FirmaService.Controllers
{
    public class PersonelsController : ApiController
    {
        // GET api/values
        public List<Personel> Get()
        {
         
               NovapmEntities db = new NovapmEntities();
               return db.Personel.ToList();
       
            
        }
      
        public ActionResult Personelsil(int perid)
        {
            NovapmEntities db = new NovapmEntities();
            var sil = db.Personel.Where(w => w.ID == perid).FirstOrDefault();
            db.Personel.Remove(sil);
            db.SaveChanges();
            return new JsonResult()
            {
                Data = true,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult PersonelKayitet(Personel form)
        {
            NovapmEntities db = new NovapmEntities();
            db.Personel.Add(form);
            db.SaveChanges();
            return new JsonResult()
            {
                Data = true,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
   

      
    }
}
