using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Linq;
using System.Web;
using System.Net;
using System.Data.Objects.SqlClient;
using System.Data.SqlClient;

using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class UserInfoController : Controller
    {
        private ReportSupEntities db = new ReportSupEntities();
     

        //
        // GET: /UserInfo/
        public ActionResult Index(string data)
        {
            string dept = "1";
            string[] dialog = { "" };
           // string fecha =  "2015-09-4";
         //   List<horas> result3 = (from u in db.Userinfoes  select new horas { }).ToList();
      
            List<horas> test = (from u in db.TB_Info() select new horas { Name = u.Name, UserID = u.Userid, Genero = u.Sex, Deptid = u.Deptid, cardnum = u.Cardnum }).ToList();
           var query = Request.QueryString[""];
        
                //  if (dialog[0]! = "")
                //{
                try
                {
                    dialog = HttpContext.Request.Form.GetValues(0);
         
                }
               catch
                { 
                  
                }
                  
               Console.Write(query);
           
                //  List<CharmanderLaMeraPija> result4 = (from e in db.EmployesUnleash(dialog[0], dept) select new CharmanderLaMeraPija { Nombre = e.Name, Horas = e.horaTrabajada, Fecha = e.horaEntrada }).ToList();



                //}
            List<CharmanderLaMeraPija> result4 = (from e in db.EmployesUnleash(data, dept) select new CharmanderLaMeraPija { Nombre = e.Name, Horas = e.horaTrabajada, Fecha = e.horaEntrada }).ToList();
           
           
          
            return View(result4);

            

        }

        //
        // GET: /UserInfo/Search/date
        [System.Web.Services.WebMethod]
        public string Search(string data)
        {




            return data;



        }
  
        //
        // GET: /UserInfo/Details/5

        public ActionResult Details(bool id = false)
        {
            Userinfo userinfo = db.Userinfoes.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        //
        // GET: /UserInfo/Create

        public ActionResult Create()
        {
        
            return View();
        }

        //
        // POST: /UserInfo/Create

        [HttpPost]
        public ActionResult Create(Userinfo userinfo)
        {
            if (ModelState.IsValid)
            {
                db.Userinfoes.Add(userinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userinfo);
        }

        //
        // GET: /UserInfo/Edit/5

        public ActionResult Edit(bool id = false)
        {
            Userinfo userinfo = db.Userinfoes.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        //
        // POST: /UserInfo/Edit/5

        [HttpPost]
        public ActionResult Edit(Userinfo userinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userinfo);
        }

        //
        // GET: /UserInfo/Delete/5

        public ActionResult Delete(bool id = false)
        {
            Userinfo userinfo = db.Userinfoes.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        //
        // POST: /UserInfo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(bool id)
        {
            Userinfo userinfo = db.Userinfoes.Find(id);
            db.Userinfoes.Remove(userinfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        public class CharmanderLaMeraPija {
            public string Nombre { get; set; }
            public DateTime? Fecha { get; set; }
            public Decimal? Horas { get; set; }
            

        }

        public class horas {
            public string UserID { get; set; }
            public string Name { get; set; }
            public string Genero { get; set; }
            public int? Deptid { get; set; }
            public string  cardnum { get; set; }
            


        }


    }
}