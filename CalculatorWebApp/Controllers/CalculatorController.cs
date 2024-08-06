using CalculatorWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Humanizer;
using System;
using System.Collections.Generic;

namespace CalculatorWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                model.Result = model.Operation switch
                {
                    "Add" => model.Number1 + model.Number2,
                    "Subtract" => model.Number1 - model.Number2,
                    "Multiply" => model.Number1 * model.Number2,
                    "Divide" => model.Number2 != 0 ? (double)model.Number1 / model.Number2 : throw new DivideByZeroException("Division by zero is not allowed."),
                    _ => throw new InvalidOperationException("Invalid operation")
                };
            }

            return View(model);
        }

        public IActionResult HumanizerDemo()
        {
            //Humanize examples

            // Example 1: 
            int number = 12345;
            ViewBag.NumberHumanized = number.ToWords();

            // Example 2: 
            DateTime date = DateTime.Now.AddDays(-5);
            ViewBag.DateHumanized = date.Humanize();

            // Example 3: 
            TimeSpan timespan = TimeSpan.FromHours(36);
            ViewBag.TimespanHumanized = timespan.Humanize();

            // Example 4: 
            long bytes = 123456789;
            ViewBag.BytesHumanized = ((double)bytes).Bytes().Humanize();

            // Example 5: 
            var collection = new List<int> { 1, 2, 3, 4, 5 };
            ViewBag.CollectionHumanized = collection.Count.ToWords();

            return View();
        }
    }
}
