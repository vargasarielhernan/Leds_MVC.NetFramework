using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Newtonsoft;
using jobs.Models;
using FireSharp.Response;

namespace jobs.Controllers
{
    public class MantenedorController : Controller
    {
        IFirebaseClient firebaseClient;

        public MantenedorController()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "jvvMEAlj2bdHwVFj83iX45qRECF04YP9KUlfqnl1",
                BasePath = "https://prueba-repuesto-default-rtdb.firebaseio.com/"
            };

            firebaseClient = new FirebaseClient(config);

        }


        // GET: Mantenedor
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(Users user)
        {
            string IdUser = Guid.NewGuid().ToString("N");
            SetResponse response = firebaseClient.Set("Users/" + IdUser, user);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View();
            }
            else
            {
                return View();
            }
        }
        public ActionResult CreateSector()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSector(Sector sector)
        {
            string IdSector = Guid.NewGuid().ToString("N");

            string IdNave = Guid.NewGuid().ToString("N");
            Nave nave = new Nave();
            nave.NameNave= sector.nave.ToString();
            nave.IdNave = IdNave.ToString();
            nave.ColumnaNumber= sector.columna.ToString();

            string IdColumna = Guid.NewGuid().ToString("N");
            Columna columna = new Columna();
            columna.IdColumna = IdColumna;
            columna.ColumnaNumber = sector.columna.ToString();
            columna.LedPosicion = sector.led;

            string IdLed = Guid.NewGuid().ToString("N");
            Leds led = new Leds();
            led.IdLed= IdLed;
            led.LedPosicion=sector.led.ToString();
            Sector sector1 = new Sector();
            List<Nave> naves = new List<Nave>();
            naves.Add(nave);
            sector1.nave = naves;
            sector1.Name=sector.Name;
            sector1.columna= columna.ToString();
            sector1.led = led.ToString();

            SetResponse response = firebaseClient.Set("Sector/" + IdSector, sector1);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View();
            }
            else
            {
                return View();
            }
        }
        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult Update()
        {
            return View();
        }
    } 
}