using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleCRUDOperations.Models;
using System.Data;


namespace VehicleCRUDOperations.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle
        DataAccessLayer.db dblayer = new DataAccessLayer.db();
        public ActionResult Show_data()
        {
            DataSet ds = dblayer.Show_Data();
            ViewBag.veh = ds.Tables[0];

            return View();
        }
        public ActionResult Add_record()
        {
       
            return View();

        }
        [HttpPost]

        public ActionResult Add_record(FormCollection fc)
        {
            Vehicle vehicle1 = new Vehicle();
            vehicle1.vrn = fc["VRN"];
            vehicle1.vehicletypeid = fc["VehicleTypeId"];
            vehicle1.make = fc["Make"];
            vehicle1.model= fc["Model"];
            vehicle1.fueltypeid= fc["FuelTypeId"];
            vehicle1.enginesize= fc["EngineSize"];
            vehicle1.statusid= fc["StatusId"];
            dblayer.Add_record(vehicle1);
            TempData["msg"] = "Inserted";
            return View();


        }
        public ActionResult Update_record(int id)
        {
            DataSet ds = dblayer.Show_record_byid(id);
            ViewBag.vehrecord = ds.Tables[0];
            return View();

        }
        [HttpPost]
        public ActionResult Update_record( int id, FormCollection fc)
        {
            Vehicle vehicle1 = new Vehicle();
            vehicle1.id  = id;
            vehicle1.vrn = fc["VRN"];
            vehicle1.vehicletypeid = fc["VehicleTypeId"];
            vehicle1.make = fc["Make"];
            vehicle1.model = fc["Model"];
            vehicle1.fueltypeid = fc["FuelTypeId"];
            vehicle1.enginesize = fc["EngineSize"];
            vehicle1.statusid = fc["StatusId"];
            dblayer.Update_record(vehicle1);
            TempData["msg"] = "Updated";
            
            return RedirectToAction("Show_data");

        }
        public ActionResult Delete_record(int id)
        {
            dblayer.delete_record(id);
            TempData["msg"] = "Deleted";
            return RedirectToAction("Show_data");

        }

    }
}