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