﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webapp.DataModels;
using webapp.DB;
using webapp.Models;

namespace webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBC _dbc;

        public HomeController(DBC dbc)
        {
            _dbc = dbc;
        }

        public IActionResult Szolgaltatasok()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        
       public IActionResult Contact()
        {
            return View();
        }

        [Route("/details/{nev}")]
        public IActionResult Details(string nev)
        {
            return Ok(_dbc.UserDatas.Where(m=>m.uname==nev));
        }        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}