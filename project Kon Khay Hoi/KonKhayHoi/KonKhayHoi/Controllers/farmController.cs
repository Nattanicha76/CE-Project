using KonKhayHoi.Models;
using System;
using System.Linq;
using System.Web.Mvc;



namespace KonKhayHoi.Controllers
{
    public class farmController : Controller
    {
        private KonKhayHoiEntities db = new KonKhayHoiEntities();
        // GET: farm
       

        public ActionResult dataFarm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult dataFarm(admin pro)
        {


            Farm farm= new Farm ();

            

            farm.Invest = 1;
            farm.F_name = Request.Form["name"];
            farm.F_tel = Request.Form["tel"];
            farm.dateStart = Request.Form["dateStart"];
            farm.MonthOfSale = Request.Form["MonthOfSale"];
            farm.F_no = Request.Form["no"];
            farm.F_subD = Request.Form["subD"];
            farm.F_sub = Request.Form["sub"];
            farm.F_ProV = Request.Form["proV"];
            farm.AID = "A0001";

            if (ModelState.IsValid)
            {
                db.Farm.Add(farm);
                db.SaveChanges();
                ViewBag.Message = "บันทึกสำเร็จ";
            }

            return View();
         }


        public ActionResult addRevenue()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addRevenue(int weight,int amount)
        {
            Revenues revenue = new Revenues();


            revenue.Weight = weight;
            revenue.amount = amount;
            revenue.R_list = Request.Form["date"];
            revenue.R_list = Request.Form["list"];
            revenue.Shop = Request.Form["shop"];
            revenue.payee = Request.Form["payee"];
            


            if (ModelState.IsValid)
            {
                db.Revenues.Add(revenue);
                db.SaveChanges();
                ViewBag.Message = "บันทึกสำเร็จ";
                

            }
            
            return View();

        }

        public ActionResult addFarm()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addFarm( int investment)
        {
            admin addfarm = new admin();

            addfarm.AID = "A0001";
            addfarm.A_Investment = investment;
            addfarm.A_name = Request.Form["name"];
            addfarm.A_lastname = Request.Form["lastname"];
            addfarm.A_no = Request.Form["no"];
            addfarm.A_subD = Request.Form["subD"];
            addfarm.A_sub = Request.Form["sub"];
            addfarm.A_ProV = Request.Form["proV"];
            addfarm.A_tel = Request.Form["tel"];
            addfarm.A_pass = Request.Form["pass"];

            if (ModelState.IsValid)
            {
                db.admin.Add(addfarm);
                db.SaveChanges();
                ViewBag.Message = "สมัครสมาชิกสำเร็จ";


            }
            return View();
        }

        public ActionResult addExpenditure()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addExpenditure(int amount)
        {
            Expenditure expenditure = new Expenditure();


            expenditure.amount = amount;
         
            expenditure.E_list = Request.Form["date"];
            expenditure.E_list = Request.Form["list"];
            expenditure.payor = Request.Form["payor"];
            expenditure.note = Request.Form["note"];
            expenditure.CID = 1;


            if (ModelState.IsValid)
            {
                db.Expenditure.Add(expenditure);
                db.SaveChanges();
                ViewBag.Message = "บันทึกสำเร็จ";


            }

            return View();

        }



        public ActionResult viewExpenditure()
        {
            Expenditure listiview = new Expenditure();
               
            return View(listiview.ToString());
        }

    }
}