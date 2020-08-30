using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using VehicleCRUDOperations.Models;
using System.Data.SqlClient;

namespace VehicleCRUDOperations.DataAccessLayer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public void Add_record(Vehicle vehicle)
        {
            SqlCommand com = new SqlCommand("sp_Vehicle_Add", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@VRN ",vehicle.vrn);
            com.Parameters.AddWithValue("@VehicleTypeId", Convert.ToInt16(vehicle.vehicletypeid));
            com.Parameters.AddWithValue("@Make",vehicle.make);
            com.Parameters.AddWithValue("@Model",vehicle.model);
            com.Parameters.AddWithValue("@FuelTypeId",vehicle.fueltypeid);
            com.Parameters.AddWithValue("@EngineSize",vehicle.enginesize);
            com.Parameters.AddWithValue("@StatusId",vehicle.statusid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        public void Update_record(Vehicle vehicle)
        {
            SqlCommand com = new SqlCommand("sp_Vehicle_Update",con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id ",vehicle.id);
            com.Parameters.AddWithValue("@VRN ",vehicle.vrn);
            com.Parameters.AddWithValue("@VehicleTypeId",Convert.ToInt16(vehicle.vehicletypeid));
            com.Parameters.AddWithValue("@Make",vehicle.make);
            com.Parameters.AddWithValue("@Model",vehicle.model);
            com.Parameters.AddWithValue("@FuelTypeId",vehicle.fueltypeid);
            com.Parameters.AddWithValue("@EngineSize",vehicle.enginesize);
            com.Parameters.AddWithValue("@StatusId",vehicle.statusid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        public DataSet Show_record_byid(int id)
        {
            SqlCommand com = new SqlCommand("sp_Vehicle_id", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }
        public DataSet Show_Data()
        {
            SqlCommand com = new SqlCommand("sp_Vehicle_All", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }
        public void delete_record(int id)
        {
            SqlCommand com = new SqlCommand("sp_Vehicle_Delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }

    }
}