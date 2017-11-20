using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KonKhayHoi.Models;
using System.Data.Entity.Validation;

namespace KonKhayHoi.Controllers
{

    public class loginController : Controller
    {
        KonKhayHoiEntities db = new KonKhayHoiEntities();
        // GET: login


        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(admin Pro)
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];

            if (ModelState.IsValid)
            {
                var checkA = db.admin.Where(a => a.AID.Equals(username) && a.A_pass.Equals(password)).FirstOrDefault();
                var checkP = db.Partner.Where(a => a.PID.Equals(username) && a.P_pass.Equals(password)).FirstOrDefault();
                var checkS = db.Shop.Where(a => a.SID.Equals(username) && a.S_pass.Equals(password)).FirstOrDefault();
                if (checkA != null)
                {
                    var cookie_AID = new HttpCookie("AID");
                    cookie_AID.Value = checkA.AID;
                    Response.Cookies.Add(cookie_AID);

                    return RedirectToAction("dataFarm", "farm");
                }
                else if (checkP != null)
                {
                    var cookie_PID = new HttpCookie("PID");
                    cookie_PID.Value = checkP.PID;
                    Response.Cookies.Add(cookie_PID);

                    return RedirectToAction("PNcheckProfit", "partner");
                }
                else if (checkS != null)
                {
                    var cookie_SID = new HttpCookie("SID");
                    cookie_SID.Value = checkS.SID;
                    Response.Cookies.Add(cookie_SID);

                    return RedirectToAction("STdatastore", "shop");
                }
                else
                {
                    ViewBag.Message = "รหัสผ่าน หรือ ชื่อผู้ใช้ไม่ถูกต้อง";
                }


            }

            return View();
        }

    }




}