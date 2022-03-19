using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MiniBlog.Controllers
{
    [AllowAnonymous]
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager();
        Context c = new Context();
        // GET: Customer
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer p)
        {
            customerManager.CustomerAddOrRegister(p);
            return RedirectToAction("Index", "Blog");
        }

        [HttpGet]
        public ActionResult Profil(int id)
        {
            var mail = (string)Session["Mail"];
            var cadsoyad = c.Customers.Where(x => x.Mail == mail).Select(y => y.CustomerName).FirstOrDefault();
            var idcustomer = c.Customers.Where(x => x.Mail == mail).Select(y => y.CustomerID).FirstOrDefault();
       
            ViewBag.cadsoyad = cadsoyad;
            ViewBag.idcustomer = idcustomer;
            Customer customer = customerManager.FindCustomer(id);
            return View(customer);
           
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("CustomerLogin", "Login");

        }


        [HttpPost]
        public ActionResult Profil(Customer p)
        {
            customerManager.EditCustomer(p);
            return RedirectToAction("Index","Blog");
        }



    }
}