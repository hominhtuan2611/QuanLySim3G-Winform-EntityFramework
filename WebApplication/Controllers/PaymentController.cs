using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index(int ?thangSuDung)
        {
            string soSim;

            soSim = Request.Cookies["soSim"].Value.ToString();

            if (soSim != null)
            {
                if (thangSuDung != null)
                {
                    using (var dbContext = new Model1())
                    {
                        if (thangSuDung > 0)
                        {

                            IEnumerable<HoaDonThanhToan> hoaDonThanhToanList = dbContext.HoaDonThanhToan.Where(i => i.Sim.SoSim == soSim && i.NgayHD.Month == thangSuDung).ToList();

                            var model = hoaDonThanhToanList;

                            return View(model);
                          }
                        else
                        {
                            IEnumerable<HoaDonThanhToan> hoaDonThanhToanList = dbContext.HoaDonThanhToan.Where(i => i.Sim.SoSim == soSim).ToList();

                            var model = hoaDonThanhToanList;

                            return View(model);
                        }
                      
                    }
                } 
                else
                {
                    using (var dbContext = new Model1())
                    {

                        IEnumerable<HoaDonThanhToan> hoaDonThanhToanList = dbContext.HoaDonThanhToan.Where(i => i.Sim.SoSim == soSim).ToList();

                        var model = hoaDonThanhToanList;

                        return View(model);
                    }
                }
            }
            else
            {
                IEnumerable<HoaDonThanhToan> hoaDonThanhToanList = null;

                var model = hoaDonThanhToanList;

                return View(model);
            }

        }
    }
    
}