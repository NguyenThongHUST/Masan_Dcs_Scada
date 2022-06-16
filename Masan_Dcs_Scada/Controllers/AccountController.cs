using Masan_Dcs_Scada.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Masan_Dcs_Scada.Controllers
{
    public class AccountController : Controller
    {

        DatabaseContext _db;
        public AccountController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Account account)
        {
            Account acc = (from a in _db.Accounts
                           where a.Name.Equals(account.Name)
                           && a.Password.Equals(account.Password)
                           select a).FirstOrDefault();

            if(acc != null)
            {
                TempData["headShifts"] = Newtonsoft.Json.JsonConvert.SerializeObject(_db.HeadShifts.ToList()) ;
                TempData["products"] = Newtonsoft.Json.JsonConvert.SerializeObject(_db.Products.ToList());

                return RedirectToAction("Index", "GeneralSetting");
            }
            else
            {
                ModelState.AddModelError("Error", "Tài khoản không đúng!");
                return View();
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdatePassword(string username, string oldPassword, string newPassword, string _newPassword)
        {
            if (!newPassword.Equals(_newPassword))
            {
                ModelState.AddModelError("Error", "Mật khẩu nhập lại phải trùng nhau");
            }
            else
            {
                Account acc = (from a in _db.Accounts
                               where a.Name.Equals(username)
                               && a.Password.Equals(oldPassword)
                               select a).FirstOrDefault();
                if(acc != null)
                {
                    acc.Password = newPassword;
                    int rows =  _db.SaveChanges();
                    if (rows > 0)
                    {
                        ModelState.AddModelError("Error", "Đổi mật khẩu thành công!");
                        return View("Login");
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Đổi mật khẩu không thành công!");
                    }
                }
                else
                {
                    ModelState.AddModelError("Error", "Tài khoản, mật khẩu không đúng!");
                }
            }
            return View("ChangePassword");
        }
    }
}
