﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestFluentValidation.Frontend.Models.ViewModel;

namespace TestFluentValidation.Frontend.Controllers;

public class CountryController : Controller
{
    private readonly HttpClient _httpClient;
    public CountryController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("TestFluentValidationApi");
    }

    private async Task<List<Country>> GetCountriesFromApi()
    {
        var response = await _httpClient.GetAsync("Country");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var countries = JsonConvert.DeserializeObject<List<Country>>(content);
            return countries;
        }
        return new List<Country>();
    }
    public async Task<IActionResult> Index()
    {
        var countries = await GetCountriesFromApi();
        return View(countries);
    }
    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        if (id == 0)
            return View(new Country());
        else
        {
            var response = await _httpClient.GetAsync($"Country/{id}");
            if (response.IsSuccessStatusCode)
            {
                var country = await response.Content.ReadFromJsonAsync<Country>();
                return View(country);
            }
            else
            {
                return NotFound();
            }
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(int id, Country country)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                //save data
                var response = await _httpClient.PostAsJsonAsync("Country", country);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create the country.");
                    return View(country);
                }
            }
            else
            {
                //update Data
                if (id != country.Id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var response = await _httpClient.PutAsJsonAsync($"Country/{id}", country);

                    if (response.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to update the country.");
                        return View(country);
                    }
                }
                return View(country);
            }
        }

        return View(new Country());
    }
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"Country/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return NotFound();
        }
    }
}
