using KonKhayHoi.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace KonKhayHoi.Controllers
{
    public class shopController : Controller
    {
        private KonKhayHoiEntities db = new KonKhayHoiEntities();

        // ดูข้อมูลร้ารรับซื้อ 
        public ActionResult STdatastore()
        {
            string query2 = "SELECT * FROM Shop ";
            var test = db.Database.SqlQuery<Shop>(query2).ToList();
            return View(Tuple.Create(test));

        }

        //ดูข้อมูลฟาร์ม
        public ActionResult STselectdatafarm()
        {
            string query2 = "SELECT * FROM Farm ";
            var test = db.Database.SqlQuery<Farm>(query2).ToList();
            return View(Tuple.Create(test));

        }


        //ดูร้านรับซื้อ
        public ActionResult Viewstore()
        {
            string query2 = "SELECT * FROM Shop ";
            var test = db.Database.SqlQuery<Shop>(query2).ToList();
            return View(Tuple.Create(test));

        }

        //แก้ไขข้อมูลร้าน
        public ActionResult STchangdatastore()

        {
            Shop shop = new Shop();

            string SID_update = Request.Form["username_update"];
            string Name_update = Request.Form["Name_update"];
            string S_name_update = Request.Form["name_update"];
            string S_lastname_update = Request.Form["lastname_update"];
            string S_tel_update = Request.Form["tel_update"];
            string purchasedAmount_update = Request.Form["purchasedAmount_update"];
            string S_no_update = Request.Form["no_update"];
            string S_subD_update = Request.Form["subD_update"];
            string S_sub_update = Request.Form["sub_update"];
            string S_ProV_update = Request.Form["ProV_update"];
            string state_update = Request.Form["state_update"];

            if (ModelState.IsValid)
            {
                if (SID_update != null)
                {

                    var checkUP = db.Shop.Where(a => a.SID.Equals(SID_update)).FirstOrDefault();

                    int A = Convert.ToInt32(purchasedAmount_update);
                    int B = Convert.ToInt32(state_update);

                    checkUP.purchasedAmount = A;
                    checkUP.state = B;
                    checkUP.Name = Name_update;
                    checkUP.S_name = S_name_update;
                    checkUP.S_lastname = S_lastname_update;
                    checkUP.S_tel = S_tel_update;
                    checkUP.S_no = S_no_update;
                    checkUP.S_subD = S_subD_update;
                    checkUP.S_sub = S_sub_update;
                    checkUP.S_ProV = S_ProV_update;



                    db.SaveChanges();

                    Session["Suser"] = checkUP.SID;

                    Session["name"] = checkUP.Name;

                    Session["Sname"] = checkUP.S_name;

                    Session["Slastname"] = checkUP.S_lastname;

                    Session["Stel"] = checkUP.S_tel;

                    Session["Sno"] = checkUP.S_no;

                    Session["SsubD"] = checkUP.S_subD;

                    Session["Ssub"] = checkUP.S_sub;

                    Session["SProV"] = checkUP.S_ProV;

                    Session["SpurchasedAmount"] = checkUP.purchasedAmount;

                    Session["Sstate"] = checkUP.state;

                    return RedirectToAction("STchangdatastore", "Shop");



                }

            }
            return View();
        }




        //สมัครสมาชิกร้านรับซื้อ
        public ActionResult addshop()
        {
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addshop(admin pro)
        {
            Shop shop = new Shop();


            shop.SID = "S0004";
            shop.Name = Request.Form["nameS"];
            shop.S_name = Request.Form["name"];
            shop.S_lastname = Request.Form["lastname"];
            shop.S_tel = Request.Form["tel"];
            shop.purchasedAmount = 0;
            shop.S_pass = Request.Form["Pass"];
            shop.S_no = Request.Form["no"];
            shop.S_subD = Request.Form["subD"];
            shop.S_sub = Request.Form["sub"];
            shop.S_ProV = Request.Form["ProV"];
            shop.state = 1;


            if (ModelState.IsValid)
            {
                db.Shop.Add(shop);
                db.SaveChanges();
                ViewBag.Message = "บันทึกสำเร็จ";


            }

            return View();

        }

        public ActionResult STchangPassword()
        {
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult STchangPassword(admin pro)
        {
            string password = Request.Form["password"];
            string newPass = Request.Form["newPass"];
            string cfnewPass = Request.Form["cfnewPass"];
            var CSID = Request.Cookies["SID"].Value;

            var checkeA = db.Shop.Where(a => a.SID.Equals(CSID)).FirstOrDefault();

            if (password != null)
            {
                var check_username = db.Shop.Where(a => a.SID.Equals(CSID)).FirstOrDefault<Shop>();
                if (check_username.S_pass == password)
                {
                    if (newPass == cfnewPass)
                    {
                        check_username.S_pass = newPass;
                        db.SaveChanges();
                        ViewBag.Error1 = "เปลี่ยนรหัสผ่านสำเร็จ";
                        return View();
                    }
                    else
                    {
                        ViewBag.Error1 = "กรอกรหัสผ่านไม่ตรงกัน";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Error2 = "รหัสผ่านผิด";
                    return View();
                }
            }

            return View();
        }
    }

}