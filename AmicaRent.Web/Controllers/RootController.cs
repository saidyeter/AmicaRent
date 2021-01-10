using AmicaRent.DataAccess;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class RootController : Controller
    {
        public AmicaRentDBContext db = new AmicaRentDBContext(ConfigurationManager.ConnectionStrings["AmicaRentConnectionString"].ConnectionString);

        public JsonResult BaseDatatable<TSource>(IQueryable<TSource> queryableData)
        {
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                //var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                //Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    queryableData = queryableData.OrderBy(sortColumn + " " + sortColumnDir);
                }
                else
                {
                    queryableData = queryableData.OrderBy("Db_InsertTime desc");

                }

                //total number of rows count     
                recordsTotal = queryableData.Count();
                //Paging     
                var data = queryableData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data    
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
        }


        public ActionResult BaseSelect2List<TSource>(DbSet<TSource> dbSet, Expression<Func<TSource, bool>> predicate, Expression<Func<TSource, Select2Model>> map) where TSource : class
        {
            var list = dbSet.Where(predicate).Select(map).Take(5).ToList();
            return Json(new { items = list }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CariList(string q = "")
        {
            return BaseSelect2List(db.Cari, x => x.Cari_AdSoyad.Contains(q) , c => new Select2Model { id = c.Cari_ID.ToString(), text = c.Cari_AdSoyad });
        }

        public ActionResult ModelList(string q = "", int markaId = 0)
        {
            return BaseSelect2List(db.AracModel, x => x.AracMarka_ID == markaId && x.AracModel_Adi.Contains(q), c => new Select2Model { id = c.AracModel_ID.ToString(), text = c.AracModel_Adi });
        }
    }
    public class Select2Model
    {
        public string id { get; set; }
        public string text { get; set; }
    }
}