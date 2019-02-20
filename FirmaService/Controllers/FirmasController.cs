using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PersonelDataAccsess;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web;

namespace FirmaService.Controllers
{
    public class FirmasController : ApiController
    {
        // GET api/values
        public List<Firma> Get()
        {

            NovapmEntities db = new NovapmEntities();
            return db.Firma.ToList();


        }

        public ActionResult GetPersonel(int firmaid)
        {
            NovapmEntities db = new NovapmEntities();
                 var a=db.Personel.Where(w => w.Firma_ID == firmaid).ToList();
                 return new JsonResult()
                 {
                     Data = a,
                     JsonRequestBehavior = JsonRequestBehavior.AllowGet
                 };
        }
        public ActionResult UPDATE(Firma model)
        {
            NovapmEntities db = new NovapmEntities();
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return new JsonResult()
                {
                    Data = true,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            return new JsonResult()
            {
                Data = true,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public Firma GetFirma(int firmaid)
        {
            NovapmEntities db = new NovapmEntities();
            return db.Firma.FirstOrDefault(w => w.ID == firmaid);
        }
        public ActionResult Firmasil(int perid)
        {
            NovapmEntities db = new NovapmEntities();
            var sil = db.Firma.Where(w => w.ID == perid).FirstOrDefault();
            db.Firma.Remove(sil);
            db.SaveChanges();
            return new JsonResult()
            {
                Data = true,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public ActionResult Kydt(Firma form)
        {
            NovapmEntities db = new NovapmEntities();
            db.Firma.Add(form);
            db.SaveChanges();
            return new JsonResult()
            {
                Data = true,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

    }
}
