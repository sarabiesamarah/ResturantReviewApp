using Microsoft.AspNetCore.Mvc;
using ResturantReviewApp.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace ResturantReviewApp.Controllers
{
    public class ResturantController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        // Constructor to inject IHttpClientFactory and configuration
        public ResturantController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiBaseUrl = configuration.GetValue<string>("ApiBaseUrl"); // Reads base URL from appsettings.json
        }

        // GET: Resturant
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Restaurant");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var restaurants = JsonSerializer.Deserialize<List<Restaurant>>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return View(restaurants);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching restaurants: {ex.Message}");
            }

            ViewBag.ErrorMessage = "Unable to load restaurants. Please try again later.";
            return View(new List<Restaurant>());
        }

        // GET: Resturant/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Restaurant/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var restaurant = JsonSerializer.Deserialize<Restaurant>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return View(restaurant);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching restaurant details: {ex.Message}");
            }

            return NotFound();
        }

        // GET: Resturant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resturant/Create
        [HttpPost]
        public async Task<IActionResult> Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var jsonData = JsonSerializer.Serialize(restaurant);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync($"{_apiBaseUrl}/api/Restaurant", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating restaurant: {ex.Message}");
                }

                ModelState.AddModelError("", "Unable to create restaurant. Please try again.");
            }

            return View(restaurant);
        }

        // GET: Resturant/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Restaurant/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var restaurant = JsonSerializer.Deserialize<Restaurant>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return View(restaurant);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching restaurant for edit: {ex.Message}");
            }

            return NotFound();
        }

        // POST: Resturant/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var jsonData = JsonSerializer.Serialize(restaurant);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PutAsync($"{_apiBaseUrl}/api/Restaurant/{restaurant.Id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating restaurant: {ex.Message}");
                }

                ModelState.AddModelError("", "Unable to update restaurant. Please try again.");
            }

            return View(restaurant);
        }

        // GET: Resturant/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/Restaurant/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var restaurant = JsonSerializer.Deserialize<Restaurant>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return View(restaurant);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching restaurant for delete: {ex.Message}");
            }

            return NotFound();
        }

        // POST: Resturant/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/api/Restaurant/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting restaurant: {ex.Message}");
            }

            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}
