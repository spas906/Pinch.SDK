﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Pinch.SDK.WebSample.Controllers
{
    public class PayersController : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var api = new PinchApi("4ahSs0HKAiMj1Jx5pFhDKoN8R9Zuzpuy", "cl_bentest1", true);

            var payers = await api.Payer.GetPayers();

            return View(payers);
        }
    }
}
