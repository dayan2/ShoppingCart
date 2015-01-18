using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyShop_MVC.Controllers
{
    public class ShopController : Controller
    {
        //
        // GET: /Shop/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(Models.User user)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(user.username, user.password))
                {
                    Session["user"] = user.username;
                    FormsAuthentication.SetAuthCookie(user.username, false);
                    return RedirectToAction("Index", "Shop");
                }
                else
                    ModelState.AddModelError("", "Login details are incorrect");
            }
            return View(user);

        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Models.User user)
        {
            if (ModelState.IsValid)
            {
                using (var con = new Context())
                {
                    var crypto = new SimpleCrypto.PBKDF2();
                    var pwd = crypto.Compute(user.password);
                    var sysuser = con.Users.Create();

                    sysuser.Email = user.username;
                    sysuser.Password = pwd;
                    sysuser.PasswordSalt = crypto.Salt;
                    sysuser.Id = Guid.NewGuid();

                    con.Users.Add(sysuser);
                    con.SaveChanges();

                    return RedirectToAction("Index", "Shop");
                }
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["list"] = Session["user"] = null;
            return RedirectToAction("Index", "Shop");
        }
        public ActionResult Products()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddToCart(Models.ShoppingCart cart)
        {
            List<Models.Product> list;
            Context con = new Context();
            Entities.Product pro = con.Products.Find(cart.ProductID);
            Models.Product modelPro = new Models.Product()
            {
                ID = pro.ID,
                Name = pro.Name,
                Price = pro.Price
            };
            if(Session["list"] == null)
            {
                list = new List<Models.Product>();
                //list.Add(modelPro);
            }
            else 
            {
                list = (List<Models.Product>)Session["list"];
                //list.Add(modelPro);
            }
            list.Add(modelPro);
            Session["list"] = list;
            return View(list);
        }
        public ActionResult checkout()
        {
            List<Models.Product> list = (List<Models.Product>)Session["list"];
            return View(list);
        }




        #region private methods
        private bool IsValid(string email, string pwd)
        {
            var cryto = new SimpleCrypto.PBKDF2();
            bool isvalid = false;

            using (var con = new Context())
            {
                Entities.User user = con.Users.FirstOrDefault(e => e.Email == email);

                if (user != null)
                {
                    if (user.Password == cryto.Compute(pwd, user.PasswordSalt))
                        isvalid = true;
                }
            }

            return isvalid;
        }
        #endregion

    }
}
