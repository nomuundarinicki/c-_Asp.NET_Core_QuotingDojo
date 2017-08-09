using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        private DbConnector cnx;
        
        public HomeController(){
            cnx = new DbConnector();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string query = "SELECT * FROM quotes";
            var allQuotes = DbConnector.Query(query);
            ViewBag.allQuotes = allQuotes;
            return View();
        }
        [HttpPost]
        [Route("add")]
        public IActionResult addquote(string name, string quote){

            ViewBag.Name = name;
            ViewBag.Quote = quote;

            System.Console.WriteLine(name);
            System.Console.WriteLine(quote);
            string query = $"INSERT INTO quotes (name, quote, CreatedAt, UpdatedAt) VALUES ('{name}', '{quote}',NOW(),NOW())";
            DbConnector.Execute(query);
            return RedirectToAction("showall");
            
        }
        [HttpGet]
        [Route("show")]
        public IActionResult showall(){
            string query = "SELECT * FROM quotes ORDER BY CreatedAt DESC";
            
            ViewBag.allQuotes = DbConnector.Query(query);
            return View("result");
        }
        
    }
}
