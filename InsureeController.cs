// File Name: InsureeController.cs
// Extension: .cs (C# file)

using YourNamespace.Models; 
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;

public class InsureeController : Controller
{
    // GET: Insuree/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Insuree/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Insuree insuree)
    {
        decimal monthlyQuote = 50; // Base price

        if (insuree.Age <= 18)
            monthlyQuote += 100;
        else if (insuree.Age >= 19 && insuree.Age <= 25)
            monthlyQuote += 50;
        else
            monthlyQuote += 25;

        if (insuree.CarYear < 2000 || insuree.CarYear > 2015)
            monthlyQuote += 25;

        if (insuree.CarMake == "Porsche")
        {
            monthlyQuote += 25;
            if (insuree.CarModel == "911 Carrera")
                monthlyQuote += 25;
        }

        monthlyQuote += 10 * insuree.SpeedingTickets;

        if (insuree.HasDUI)
            monthlyQuote *= 1.25m;

        if (insuree.IsFullCoverage)
            monthlyQuote *= 1.5m;

        ViewBag.MonthlyQuote = monthlyQuote;

        return View();
    }
}
