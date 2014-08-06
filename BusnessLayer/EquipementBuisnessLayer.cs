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
    public class EquipementBuisnessLayer
    {
        public IEnumerable<Equipement> Equipements
        {
            get
            {
                string connectionString =
                    ConfigurationManager.ConnectionStrings["ModuleEquipementContext"].ConnectionString;

                List<Equipement> Equipements = new List<Equipement>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEquipements", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Equipement Equipement = new Equipement();
                        Equipement.EquipementID = Convert.ToInt32(rdr["EquipementID"]);
                        Equipement.Name = rdr["Name"].ToString();
                        Equipement.ZoneID = Convert.ToInt32(rdr["ZoneID"]);
                        Equipement.SensorID = Convert.ToInt32(rdr["SensorID"]);
                        Equipement.HighAlarm = Convert.ToInt32(rdr["HighAlarm"]);
                        Equipement.DateCreation = Convert.ToDateTime(rdr["DateCreation"]);

                        Equipements.Add(Equipement);
                    }
                }

                return Equipements;
            }
        }
    }
}
