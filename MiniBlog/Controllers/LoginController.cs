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
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorLogin(Author p)
        {
            Context c = new Context();
            var userinfo = c.Authors.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);
            if (userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.Mail, false);
                Session["Mail"] = userinfo.Mail.ToString();
                return RedirectToAction("Index", "User");
            }
            else { return RedirectToAction("AuthorLogin", "Login"); }
            
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            Context c = new Context();
            var userinfo = c.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if (userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.Username, false);
                Session["Username"] = userinfo.Username.ToString();
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else { return RedirectToAction("AdminLogin", "Login"); }

        }







        [HttpGet]
        public ActionResult CustomerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin(Customer p)
        {
            Context c = new Context();
            var customerinfo = c.Customers.FirstOrDefault(x => x.Mail== p.Mail && x.Password == p.Password);
            
            if (customerinfo != null)
            {
                FormsAuthentication.SetAuthCookie(customerinfo.Mail, false);
                Session["Mail"] = customerinfo.Mail.ToString();
               
                return RedirectToAction("Index", "Blog");
            }
            else { return RedirectToAction("CustomerLogin", "Login"); }

        }
    }
}