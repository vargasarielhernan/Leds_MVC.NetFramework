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
using System.Configuration;
using Newtonsoft.Json;

namespace jobs.Controllers
{
    public class MantenedorController : Controller
    {
        IFirebaseClient firebaseClient;

        public MantenedorController()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = ConfigurationManager.AppSettings["keyAPI"],
                BasePath = ConfigurationManager.AppSettings["DBUrl"]
            };

            firebaseClient = new FirebaseClient(config);

        }


        // GET: Mantenedor
        public ActionResult Index()
        {
            Dictionary<string, Sector> lista = new Dictionary<string, Sector>();
            FirebaseResponse response = firebaseClient.Get("Sector");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                lista = JsonConvert.DeserializeObject<Dictionary<string, Sector>>(response.Body);
            List<Sector> sectors = new List<Sector>();
            foreach (KeyValuePair<string, Sector> elemento in lista)
            {
                sectors.Add(new Sector()
                {
                    IdSector = elemento.Key,
                    Name = elemento.Value.Name,
                    led = elemento.Value.led,
                    nave = elemento.Value.nave,
                    columna = elemento.Value.columna,
                });
            }
            return View(sectors);
        }
        public ActionResult Delete(string id)
        {
            FirebaseResponse response = firebaseClient.Delete("Sector/" + id);
            return RedirectToAction("Index", "mantenedor");
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
            nave.NameNave = sector.nave.ToString();
            nave.IdNave = IdNave.ToString();
            nave.ColumnaNumber = sector.columna.ToString();

            string IdColumna = Guid.NewGuid().ToString("N");
            Columna columna = new Columna();
            columna.IdColumna = IdColumna;
            columna.ColumnaNumber = sector.columna.ToString();
            columna.LedPosicion = sector.led;

            string IdLed = Guid.NewGuid().ToString("N");
            Leds led = new Leds();
            led.IdLed = IdLed;
            led.LedPosicion = sector.led.ToString();
            Sector sector1 = new Sector();
            //List<Nave> naves = new List<Nave>();
            //naves.Add(nave);
            sector1.nave = nave.ToString();
            sector1.Name = sector.Name;
            sector1.columna = columna.ToString();
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
        public ActionResult UpdateSector(string id)
        {
            FirebaseResponse response = firebaseClient.Get("Sector/" + id);
            Sector sector = response.ResultAs<Sector>();
            sector.IdSector = id;
            return View(sector);
        }
        [HttpPost]
        public ActionResult UpdateSector(Sector sector)
        {
            string IdSector = sector.IdSector;
            sector.IdSector = null;

            FirebaseResponse response = firebaseClient.Update("Sector/" + IdSector, sector);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("Index", "mantenedor");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult NaveLeds()
        {
            return View();
        }
    }
}