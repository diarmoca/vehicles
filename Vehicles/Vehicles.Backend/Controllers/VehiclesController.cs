using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vehicles.Backend.Models;
using Vehicles.Common.Models;
using Vehicles.Backend.Helpers;

namespace Vehicles.Backend.Controllers
{
    public class VehiclesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Vehicles
        public async Task<ActionResult> Index()
        {
            return View(await db.Vehicles.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // public async Task<ActionResult> Create([Bind(Include = "id,Marca,Tipo,Color,Modelo,NoPlacas,NoSerie,Depositarios,Cargo,Adscripcion,NoAveriguacion,NoExpediente,Origen,FechaInicio,FechaFinal,ImagePath")] Vehicle vehicle)
        public async Task<ActionResult> Create(VehicleView view)
        {
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/Vehicles";

                if (view.ImageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
                    pic = $"{ folder}/{ pic}";
                }

                var vehicle = this.ToVehicle(view, pic);

                db.Vehicles.Add(vehicle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(view);
        }

        private Vehicle ToVehicle(VehicleView view, string pic)
        {
            return new Vehicle
            {
                id = view.id,
                Marca = view.Marca,
                Tipo = view.Tipo,
                Color = view.Color,
                Modelo = view.Modelo,
                NoPlacas = view.NoPlacas,
                NoSerie = view.NoSerie,
                Depositarios = view.Depositarios,
                Cargo = view.Cargo,
                Adscripcion = view.Adscripcion,
                NoAveriguacion = view.NoAveriguacion,
                NoExpediente = view.NoExpediente,
                Origen = view.Origen,
                FechaInicio = view.FechaInicio,
                FechaFinal = view.FechaFinal,
                ImagePath = pic,
                


            };
        }

        // GET: Vehicles/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var vehicle = await db.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "id,Marca,Tipo,Color,Modelo,NoPlacas,NoSerie,Depositarios,Cargo,Adscripcion,NoAveriguacion,NoExpediente,Origen,FechaInicio,FechaFinal,ImagePath")] Vehicle vehicle)
        public async Task<ActionResult> Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var vehicle = await db.Vehicles.FindAsync(id);
            db.Vehicles.Remove(vehicle);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
