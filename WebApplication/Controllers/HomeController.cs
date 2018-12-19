using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        //get trang index thong tin tai khoan

        [HttpGet]
        public ActionResult Index(string soSim)
        {
          
            if (soSim != null)
            {
                
                Response.Cookies["soSim"].Value = soSim;
               

                using (var dbContext = new Model1())
                {
                    IEnumerable<Model.CuocGoi> cuocGoiList = dbContext.CuocGoi.Where(i => i.Sim.SoSim == soSim).ToList();

                    var model = cuocGoiList;

                    return View(model);
                }

              
            }
            else
            {
                IEnumerable<Model.CuocGoi> cuoiGoiList = null;

                var model = cuoiGoiList;

                return View(model);
            }
        }

        //trang index 
        //trang thong tin tai khoan 
       // trang lich su cuoc goi
       //trang than toa n


    }
}