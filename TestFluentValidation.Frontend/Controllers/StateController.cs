using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TestFluentValidation.Frontend.Models.ViewModel;

namespace TestFluentValidation.Frontend.Controllers;

public class StateController : Controller
{
    private readonly HttpClient _httpClient;
    public StateController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("TestFluentValidationApi");
    }

    private async Task<List<State>> GetStateAll()
    {
        var response = await _httpClient.GetAsync("State");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<State>>(content);
        }
        return new List<State>();
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var listState = await GetStateAll();
        return View(listState);
    }


    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        var response = await _httpClient.GetAsync("Country");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var stateList = JsonConvert.DeserializeObject<List<Country>>(content);
            ViewData["CountryId"] = new SelectList(stateList, "Id", "Name");
        }
        if (id == 0) return View(new State());
        

        else
        {
            var stateresponse = await _httpClient.GetAsync($"State/{id}");
            if (stateresponse.IsSuccessStatusCode)
            {
                var satedata = await stateresponse.Content.ReadFromJsonAsync<State>();
                return View(satedata);
            }
            else
            {
                return NotFound();
            }
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(int id, State state)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                //save data
                var response = await _httpClient.PostAsJsonAsync("State", state);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create the State.");
                    return View(state);
                }
            }
            else
            {
                //update Data
                if (id != state.Id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var response = await _httpClient.PutAsJsonAsync($"State/{id}", state);

                    if (response.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to update the State.");
                        return View(state);
                    }
                }
                return View(state);
            }
        }

        return View(new State());
    }


    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"State/{id}");
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
