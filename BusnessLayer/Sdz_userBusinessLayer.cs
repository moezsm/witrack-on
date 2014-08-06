using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Sdz_userBusinessLayer
    {
        public IEnumerable<Sdz_user> Sdz_users
        {
            get
            {
                string connectionString =
                    ConfigurationManager.ConnectionStrings["ModuleEquipementContext"].ConnectionString;

                List<Sdz_user> sdz_users = new List<Sdz_user>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllSdz_users", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Sdz_user sdz_user = new Sdz_user();
                        sdz_user.Sdz_userID = Convert.ToInt32(rdr["Sdz_userID"]);
                        sdz_user.Name = rdr["Name"].ToString();
                        sdz_user.Username = rdr["Username"].ToString();
                        sdz_user.Mail = rdr["Mail"].ToString();
                        sdz_user.Password_user = rdr["Password_user"].ToString();
                        sdz_user.Gender = rdr["Gender"].ToString();
                        sdz_user.City = rdr["City"].ToString();
                        if (!(rdr["DateOfBirth"] is DBNull))
                        {
                            sdz_user.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                        }
                        sdz_users.Add(sdz_user);
                    }
                }

                return sdz_users;
            }
        }
        public void AddSdz_user(Sdz_user sdz_user)
        {
            string connectionString =
           ConfigurationManager.ConnectionStrings["ModuleEquipementContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddSdz_user", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = sdz_user.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramUsername = new SqlParameter();
                paramUsername.ParameterName = "@Username";
                paramUsername.Value = sdz_user.Username;
                cmd.Parameters.Add(paramUsername);

                SqlParameter paramMail = new SqlParameter();
                paramMail.ParameterName = "@Mail";
                paramMail.Value = sdz_user.Mail;
                cmd.Parameters.Add(paramMail);

                SqlParameter paramPassword_user = new SqlParameter();
                paramPassword_user.ParameterName = "@Password_user";
                paramPassword_user.Value = sdz_user.Password_user;
                cmd.Parameters.Add(paramPassword_user);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = sdz_user.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = sdz_user.City;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = sdz_user.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
