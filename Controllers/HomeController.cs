using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoApp2.Models;
using System.Data.SQLite;
using System.Data.SQLite.Generic;

namespace TodoApp2.Controllers;

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public void Insert(Todo todo)
    {
        using (var connection =
            new SQLiteConnection("Data Source=db.sqlite"))
        {
            using (var tableCmd = connection.CreateCommand())
            {
                connection.Open();
                tableCmd.CommandText = $"INSERT INTO Todo (name) VALUES ('{todo.Name}')";
                try
                {
                    tableCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
