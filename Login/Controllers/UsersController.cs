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
    public class UsersController : Controller
    {
        // RepoUsers obj = new RepoUsers();
        private IRepo obj;
        public UsersController(IRepo repo)
        {
            this.obj = repo;
        }
        
        public IActionResult CreateUser()
        {


            return View();

        }

        public IActionResult LoginUser()
        {

            return View();

        }
        public IActionResult LoginUserCheck( LoginModel obj1)
        {
            Users record = obj.CheckLogin(obj1);
            if (ModelState.IsValid)
            {
                
                ViewBag.Msg = "User is there";
                var record2 = JsonConvert.SerializeObject(record);
                HttpContext.Session.SetString("LoginModel", record2);
                return RedirectToAction("AccountIndex", "Account");

            }
            else
            {
                return RedirectToAction("LoginUser");
            }

            

        }
        
        public IActionResult CreateUserRecord(Users record)
        {
            //Explicit validation
           /* if(string.IsNullOrEmpty(record.Email))
            {
                ModelState.AddModelError("Email", "Please Enter right email");
            }*/

            //Users record = obj.PersonalInfo(id);
            if (ModelState.IsValid)
            {
                bool flag = obj.InsertUser(record);
                ViewBag.Msg = "Data of user has been added";
                ViewData["Pass"] = "Done";
                return RedirectToAction("LoginUser");
            }
            else
            {
                return View("CreateUser");
            }

           

        }

    }
}
