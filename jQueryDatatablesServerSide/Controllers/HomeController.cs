using jQueryDatatablesServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jQueryDatatablesServerSide.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData(DataTableAjaxRequestModel model)
        {

            // action inside a standard controller
            int filteredResultsCount;
            int totalResultsCount;
            var res = YourCustomSearchFunc(model,
                out filteredResultsCount,
                out totalResultsCount);

            return Json(new
            {
                draw = model.draw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = res
            }, JsonRequestBehavior.AllowGet);
        }

        public IList<Person> YourCustomSearchFunc(DataTableAjaxRequestModel model,
            out int filteredResultsCount,
            out int totalResultsCount)
        {
            var searchBy = (model.search != null && model.search.value != null) 
                ? model.search.value : null;
            var take = model.length;
            var skip = model.start;

            // search the dbase taking into consideration table sorting and paging
            //var result = GetDataFromDbase(searchBy, take, skip, sortBy, sortDir, out filteredResultsCount, out totalResultsCount);

            List<Person> result = null;

            if (result == null)
            {
                // empty collection...
                result = new List<Person>();
            }

            for (int i = 1; i < 200; i++)
            {
                string name = "Pao";
                bool login = false;

                if (i % 2 == 0)
                {
                    name = "Roberto";
                    login = true;
                }
                else if (i % 3 == 0)
                {
                    name = "Maricruz";
                    login = false;
                }
                else if (i % 4 == 0)
                {
                    name = "Juan";
                    login = false;
                }

                result.Add(new Person
                {
                    Name = name,
                    Age = i,
                    DoB = "Developer",
                    Login = login
                });
            }

            if(searchBy != null)
            {
                result = result.Where(p => p.Name.ToLower().Trim().Contains(searchBy.ToLower().Trim())).ToList();
            }

            totalResultsCount = result.Count;
            filteredResultsCount = result.Count;

            return result.Skip(skip)
                .Take(take)
                .ToList(); ;
        }

    }
}