using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public interface IRepo
   {
        bool InsertUser(Users obj);
        Users CheckLogin(LoginModel obj);

   }
}
