using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TestFluentValidation.Frontend.Models.ViewModel;

namespace TestFluentValidation.Frontend.Controllers;

public class StudentController : Controller
{
    private readonly HttpClient _httpClient;
    public StudentController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("TestFluentValidationApi");
    }

    private async Task<List<Student>> GetAlllEmployee()
    {
        var response = await _httpClient.GetAsync("Student");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var citylist = JsonConvert.DeserializeObject<List<Student>>(content);
            return citylist;
        }
        return new List<Student>();
    }
    public async Task<IActionResult> Index()
    {
        var listEmp = await GetAlllEmployee();
        return View(listEmp);
    }

    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        var response = await _httpClient.GetAsync("State");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var stateList = JsonConvert.DeserializeObject<List<State>>(content);
            ViewData["StateId"] = new SelectList(stateList, "Id", "Name");
        }
        var studentResponse = await _httpClient.GetAsync("Country");
        if (studentResponse.IsSuccessStatusCode)
        {
            var content = await studentResponse.Content.ReadAsStringAsync();
            var stateList = JsonConvert.DeserializeObject<List<Country>>(content);
            ViewData["countryId"] = new SelectList(stateList, "Id", "Name");
        }

        var cityresponse = await _httpClient.GetAsync("City");
        if (cityresponse.IsSuccessStatusCode)
        {
            var content = await cityresponse.Content.ReadAsStringAsync();
            var citylist = JsonConvert.DeserializeObject<List<City>>(content);
            ViewData["CityId"] = new SelectList(citylist, "Id", "Name");

        }
        if (id == 0)return View(new Student());
        else
        {
            
            var studenres = await _httpClient.GetAsync($"Student/{id}");
            if (studenres.IsSuccessStatusCode)
            {
                var student = await studenres.Content.ReadFromJsonAsync<Student>();
                return View(student);
            }
            else  return NotFound();
            
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(int id, Student student, IFormFile pictureFile)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {

                if (pictureFile != null && pictureFile.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        pictureFile.CopyTo(stream);
                    }
                    student.Picture = $"{pictureFile.FileName}";
                }
                var response = await _httpClient.PostAsJsonAsync("Student", student);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create the Student.");
                    return View(student);
                }
            }
            else
            {
                //update Data
                if (id != student.Id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureFile.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        student.Picture = $"{pictureFile.FileName}";
                    }
                    var response = await _httpClient.PutAsJsonAsync($"Student/{id}", student);

                    if (response.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to update the country.");
                        return View(student);
                    }
                }
                return View(student);
            }
        }

        return View(new Student());
    }

    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"Student/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return NotFound();
        }
    }
    public async Task<ActionResult> StateDropdownData(int countryId)
    {
        var response = await _httpClient.GetAsync("State");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var stateList = JsonConvert.DeserializeObject<List<State>>(content);
            List<State> filteredStates = stateList.Where(state => state.CountryId == countryId).ToList();
            return Json(filteredStates);
        }
        return NotFound();
    }


    public async Task<ActionResult> CityDropdownData(int stateId)
    {
        var response = await _httpClient.GetAsync("City");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var CityList = JsonConvert.DeserializeObject<List<City>>(content);
            List<City> filteredStates = CityList.Where(state => state.StateId == stateId).ToList();
            return Json(filteredStates);
        }
        return NotFound();
    }
}
