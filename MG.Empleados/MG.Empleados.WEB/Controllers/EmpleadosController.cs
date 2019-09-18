using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MG.Empleados.DT;
using Newtonsoft.Json;

namespace MG.Empleados.WEB.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Index()
        {
            return View();
        }

        // GET: Empleados/Details/5
        public ActionResult Consulta(int id)
        {
            return View();
        }

        public JsonResult ConsultarEmpleados(int Request)
        {
            List<DTEmpleado> objRespuestaApiEmpleado = new List<DTEmpleado>();

            try
            {
                //DTEmpleado _DTEmpleado = JsonConvert.DeserializeObject<DTEmpleado>(Request);

                    Task<string> taskEmpleados = Task.Run(async () => await APis.WEBCallApi.ConsultarDataGET(Request));
                    taskEmpleados.Wait();

                objRespuestaApiEmpleado = JsonConvert.DeserializeObject<List<DTEmpleado>>(taskEmpleados.Result);
            }
            catch (Exception ex)
            {

            }
           
            return Json(objRespuestaApiEmpleado);
        }

        // POST: Empleados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empleados/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}