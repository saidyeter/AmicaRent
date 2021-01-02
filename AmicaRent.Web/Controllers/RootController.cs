using AmicaRent.DataAccess;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Linq.Dynamic.Core;

namespace WebApplication.Controllers
{
    public class RootController : Controller
    {
        public AmicaRentDBContext db = new AmicaRentDBContext();

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
    }
}