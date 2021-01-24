using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CabAutomationSystem.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace CabAutomationSystem.Controllers
{
    public class RoutesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api"); 
        HttpClient client;

        private readonly CabDbContext _context;

        public RoutesController(CabDbContext context)
        {
            _context = context;

            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        // GET: Routes
        public IActionResult Index()
        {
            List<Route> modelList = new List<Route>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Routes/GetRoutes").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<Route>>(data);
            }

            return View(modelList.ToList());
        }

        // GET: Routes/Details/5
        public IActionResult Details(int? id)
        {
            Route model = new Route();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Routes/GetRouteById?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                string datamodel = data.Replace("[", string.Empty).Replace("]", string.Empty);
                model = JsonConvert.DeserializeObject<Route>(datamodel);
            }
            return View(model);
        }

        // GET: Routes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Routes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RouteId,RouteName,RouteNumber")] Route route)
        {
            string data = JsonConvert.SerializeObject(route);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Routes/PostRoute", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Routes/Edit/5
        public IActionResult Edit(int? id)
        {
            Route model = new Route();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Routes/GetRouteById?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                string datamodel = data.Replace("[", string.Empty).Replace("]", string.Empty);
                model = JsonConvert.DeserializeObject<Route>(datamodel);
            }
            return View(model);
        }

        // POST: Routes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("RouteId,RouteName,RouteNumber")] Route route)
        {
            string data = JsonConvert.SerializeObject(route);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/Routes/PutRoute", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(route);
        }

        // GET: Routes/Delete/5
        public IActionResult Delete(int? id)
        {
            Route model = new Route();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Routes/GetRouteById?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                string datamodel = data.Replace("[", string.Empty).Replace("]", string.Empty);
                model = JsonConvert.DeserializeObject<Route>(datamodel);
            }

            return View(model);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Routes/DeleteRoute?Id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        private bool RouteExists(int id)
        {
            return _context.Route.Any(e => e.RouteId == id);
        }
    }
}
