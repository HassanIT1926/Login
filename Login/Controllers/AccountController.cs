using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccountIndex()
        {
            string StdModel = HttpContext.Session.GetString("LoginModel");

            Users record = JsonConvert.DeserializeObject<Users>(StdModel);
            if (record.UserName != null)
            {
                ViewData["Msg3"] = record.UserName;
                ViewData["Msg4"] = record.Email;
                ViewData["Msg5"] = record.UserPassword;
                ViewData["Msg6"] = record.Gender;
                ViewData["Msg7"] = record.Age;
                ViewData["Msg8"] = record.Phone;
            }
            return View();
        }
    }
}
