using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_rabtsevich.Models;

namespace wt_lab4_4mvc_rabtsevich.Controllers;

public class FlightController : Controller
{
    // Данные хранятся в памяти (БД нет по условию)
    private static readonly List<Flight> _flights = new()
    {
        new Flight { Id = 1, FlightNumber = "SU-100", Departure = "Москва",
            Destination = "Санкт-Петербург", DepartureTime = new DateTime(2025,5,10,8,30,0),
            TicketPrice = 4500, SeatsAvailable = 120, IsActive = true },
        new Flight { Id = 2, FlightNumber = "SU-205", Departure = "Москва",
            Destination = "Сочи", DepartureTime = new DateTime(2025,5,11,14,0,0),
            TicketPrice = 7800, SeatsAvailable = 45, IsActive = true },
        new Flight { Id = 3, FlightNumber = "SU-310", Departure = "Казань",
            Destination = "Новосибирск", DepartureTime = new DateTime(2025,5,12,6,15,0),
            TicketPrice = 6200, SeatsAvailable = 0, IsActive = false },
        new Flight { Id = 4, FlightNumber = "SU-412", Departure = "Москва",
            Destination = "Екатеринбург", DepartureTime = new DateTime(2025,5,13,18,45,0),
            TicketPrice = 5300, SeatsAvailable = 78, IsActive = true },
        new Flight { Id = 5, FlightNumber = "SU-518", Departure = "Сочи",
            Destination = "Москва", DepartureTime = new DateTime(2025,5,14,21,10,0),
            TicketPrice = 8100, SeatsAvailable = 12, IsActive = true },
    };

    private static int _nextId = 6;

    // GET: /Flight
    public IActionResult Index(string? search)
    {
        var list = string.IsNullOrWhiteSpace(search)
            ? _flights
            : _flights.Where(f => f.Destination.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

        ViewBag.Search = search;
        ViewBag.TotalActivePrice = _flights.Where(f => f.IsActive).Sum(f => f.TicketPrice);
        return View(list);
    }

    // GET: /Flight/Details/1
    public IActionResult Details(int id)
    {
        var flight = _flights.FirstOrDefault(f => f.Id == id);
        if (flight is null) return NotFound();
        return View(flight);
    }

    // GET: /Flight/Create
    public IActionResult Create() => View();

    // POST: /Flight/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Flight flight)
    {
        if (!ModelState.IsValid) return View(flight);

        flight.Id = _nextId++;
        _flights.Add(flight);
        return RedirectToAction(nameof(Index));
    }

    // GET: /Flight/Edit/1
    public IActionResult Edit(int id)
    {
        var flight = _flights.FirstOrDefault(f => f.Id == id);
        if (flight is null) return NotFound();
        return View(flight);
    }

    // POST: /Flight/Edit/1
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Flight flight)
    {
        if (id != flight.Id) return BadRequest();
        if (!ModelState.IsValid) return View(flight);

        var existing = _flights.FirstOrDefault(f => f.Id == id);
        if (existing is null) return NotFound();

        existing.FlightNumber = flight.FlightNumber;
        existing.Departure = flight.Departure;
        existing.Destination = flight.Destination;
        existing.DepartureTime = flight.DepartureTime;
        existing.TicketPrice = flight.TicketPrice;
        existing.SeatsAvailable = flight.SeatsAvailable;
        existing.IsActive = flight.IsActive;

        return RedirectToAction(nameof(Index));
    }

    // POST: /Flight/Delete/1
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var flight = _flights.FirstOrDefault(f => f.Id == id);
        if (flight is not null) _flights.Remove(flight);
        return RedirectToAction(nameof(Index));
    }
}