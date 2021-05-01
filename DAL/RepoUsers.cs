using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace DAL
{
    public class RepoUsers :IRepo
    {
        private readonly string DBconnectionString = "Data Source =DESKTOP-4CELRAB; Initial Catalog = LoginUser; Integrated Security = True;";
        private SqlConnection cn;

        //inserting user
        public bool InsertUser(Users obj)
        {
            bool x = false;

            {
                cn = new SqlConnection();
                cn.ConnectionString = DBconnectionString;
                cn.Open();
                SqlCommand cmd = new SqlCommand("InsertUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //giving parameters to add a new patient
                cmd.Parameters.AddWithValue("@UserName", SqlDbType.VarChar).Value = obj.UserName;
                cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = obj.Email;
                cmd.Parameters.AddWithValue("@UserPassword", SqlDbType.VarChar).Value = obj.UserPassword;
                cmd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = obj.Gender;
                cmd.Parameters.AddWithValue("@Age", SqlDbType.Int).Value = obj.Age;
                cmd.Parameters.AddWithValue("@Phone", SqlDbType.BigInt).Value = obj.Phone;

                //Output parameters
                cmd.Parameters.AddWithValue("@ReturnInt", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

                cmd.ExecuteNonQuery();


                //Get output param values from db
                x = Convert.ToBoolean(Convert.ToInt32(cmd.Parameters["@ReturnInt"].Value.ToString()));
                cn.Close();
                if (x)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


        }

        public Users CheckLogin(LoginModel obj)
        {
            Users oBj = new Users();
            cn = new SqlConnection();
            cn.ConnectionString = DBconnectionString;
            cn.Open();
            SqlCommand cmd = new SqlCommand("CheckUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserName", SqlDbType.VarChar).Value = obj.UserName;
            cmd.Parameters.AddWithValue("@UserPassword", SqlDbType.VarChar).Value = obj.UserPassword;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    oBj.UserName = Convert.ToString(dr[0]);
                    oBj.Email = Convert.ToString(dr[1]);
                    oBj.UserPassword = Convert.ToString(dr[2]);
                    oBj.Gender = Convert.ToString(dr[3]);
                    oBj.Age = Convert.ToInt32(dr[4]);
                    oBj.Phone = Convert.ToInt32(dr[5]);



                }
            }
            else
            {
                Console.WriteLine("No Record Found");
            }

            cn.Close();
            return oBj;







        }
    }
}
