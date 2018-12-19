using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {

            string soSim;

            soSim = Request.Cookies["soSim"].Value.ToString();

            if (soSim != null)
            {

               using (var dbContext = new Model1())
                {

                     HoaDonDK hoaDonDK = dbContext.HoaDonDK.FirstOrDefault(i => i.Sim.SoSim == soSim);

                    int maKhachHang = hoaDonDK.MaKH;

                    KhachHang khachHang = dbContext.KhachHang.FirstOrDefault(i=>i.MaKH==maKhachHang);

                    var model = khachHang;

                    return View(model);
                }


            }
            else
            {
                Model.KhachHang khachHang = null;

                var model = khachHang;

                return View(model);
            }

        }
    }
}