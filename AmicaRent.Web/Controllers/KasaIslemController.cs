using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class KasaIslemController : RootController
    {
        // GET: KasaIslem
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoadDt()
        {
            try
            {
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

                IQueryable<AmicaRent.DataAccess.KasaIslem> data = db.KasaIslem;


                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    data = data.Where(m => m.KasaIslem_Aciklama.Contains(searchValue));
                }

                return BaseDatatable(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
