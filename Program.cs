// Insuree Model
public class Insuree
{
    // Existing properties
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    // New properties
    public int Age { get; set; }
    public int CarYear { get; set; }
    public string CarMake { get; set; }
    public string CarModel { get; set; }
    public int SpeedingTickets { get; set; }
    public bool HasDUI { get; set; }
    public bool IsFullCoverage { get; set; }
}

// Insuree Controller
public class InsureeController : Controller
{
    // GET: Insuree/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Insuree/Create
    [HttpPost]
    public ActionResult Create(Insuree insuree)
    {
        decimal monthlyQuote = 50;

        if (insuree.Age <= 18)
            monthlyQuote += 100;
        else if (insuree.Age >= 19 && insuree.Age <= 25)
            monthlyQuote += 50;
        else
            monthlyQuote += 25;

        if (insuree.CarYear < 2000)
            monthlyQuote += 25;
        else if (insuree.CarYear > 2015)
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

        // Save insuree and quote to database

        return View();
    }
}

// Create View
@model Insuree

@using (Html.BeginForm())
{
    @Html.LabelFor(model => model.FirstName)
    @Html.EditorFor(model => model.FirstName)
    <br />
    <!-- Add other fields here -->
    <input type="submit" value="Submit" />
}

// Admin View
@model IEnumerable<Insuree>

<table>
    <tr>
        <th>First Name</th>
        <th>Last Name</th>
        <th>Email</th>
        <th>Monthly Quote</th>
    </tr>
    @foreach (var insuree in Model)
    {
        <tr>
            <td>@insuree.FirstName</td>
            <td>@insuree.LastName</td>
            <td>@insuree.Email</td>
            <td>@insuree.MonthlyQuote</td>
        </tr>
    }
</table>
