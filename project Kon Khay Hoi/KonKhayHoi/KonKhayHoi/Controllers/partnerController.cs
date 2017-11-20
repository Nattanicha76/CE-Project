using KonKhayHoi.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace KonKhayHoi.Controllers
{
    public class partnerController : Controller
    {
        private KonKhayHoiEntities db = new KonKhayHoiEntities();
        // GET: partner
        public ActionResult PNcheckProfit()
        {
            return View();
        }


        //PNดูข้อมูลร้านรับซื้อ
        public ActionResult PNViewstore()
        {
            string query2 = "SELECT * FROM Shop ";
            var test = db.Database.SqlQuery<Shop>(query2).ToList();
            return View(Tuple.Create(test));

        }

        //ดูข้อมูลฟาร์ม
        public ActionResult ViewPN()
        {
            string query2 = "SELECT * FROM Partner ";
            var test = db.Database.SqlQuery<Partner>(query2).ToList();
            return View(Tuple.Create(test));

        }

        //เพิ่มหุ้นส่วน
        public ActionResult addPN()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addPN(int investment)
        {
            Partner partner = new Partner();


            partner.PID = "P0002";
            partner.P_name = Request.Form["name"];
            partner.P_lastname = Request.Form["lastname"];
            partner.P_tel = Request.Form["tel"];
            partner.P_investment = investment;
            partner.P_no = Request.Form["no"];
            partner.P_pass = Request.Form["pass"];
            partner.P_sub = Request.Form["sub"];
            partner.P_subD = Request.Form["subD"];
            partner.P_ProV = Request.Form["ProV"];
            partner.AID = "A0001";


            if (ModelState.IsValid)
            {
                db.Partner.Add(partner);
                db.SaveChanges();
                ViewBag.Message = "บันทึกสำเร็จ";
            }

            return View();

        }

       
        }
    }
