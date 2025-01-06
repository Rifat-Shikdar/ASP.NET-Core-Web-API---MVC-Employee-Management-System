using EmployeeMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;


namespace EmployeeMVC.Controllers
{
    

    public class EmployeeController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "http://localhost:5094/api/Employee";

        public EmployeeController()
        {
            _httpClient = new HttpClient();
        }

        // ----------------Display list ----------------------
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync(ApiBaseUrl);
                if (!response.IsSuccessStatusCode)
                {
                    return Content("Failed to load data from API. Status Code: " + response.StatusCode);
                }

                var data = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(data))
                {
                    return Content("No data found.");
                }

                var employees = JsonConvert.DeserializeObject<List<Employee>>(data);
                return View(employees);
            }
            catch (Exception ex)
            {
                return Content("An error occurred: " + ex.Message);
            }
        }

        // --------------------Create ------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                // Log the model state errors
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage); // Log the error messages
                }
                return Json(new { success = false, message = "Invalid model state." });
            }
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(employee);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(ApiBaseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true });
                }

                // Log the response content for debugging
                var errorContent = await response.Content.ReadAsStringAsync();
                return Json(new { success = false, message = errorContent });
            }
            return Json(new { success = false, message = "Invalid model state." });
        }

        // ------------------edit -----------------
        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"{ApiBaseUrl}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var data = await response.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<Employee>(data);
            return View(employee);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(employee);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{ApiBaseUrl}/{employee.EmployeeId}", content);

                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true });
                }

                return Json(new { success = false, message = "Failed to update employee." });
            }
            return Json(new { success = false, message = "Invalid model state." });
        }
    

    // --------------------------Delete-------------------------
    public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                ViewBag.ErrorMessage = "Failed to delete employee.";
                return View("Error");
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "An error occurred while deleting the employee.";
                return View("Error");
            }
        }


        public async Task<IActionResult> ProductList()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://www.pqstec.com/InvoiceApps/values/GetProductListAll");

                if (!response.IsSuccessStatusCode)
                {
                    return Content("Failed to load data from API. Status Code: " + response.StatusCode);
                }

                var data = await response.Content.ReadAsStringAsync();

              
                if (string.IsNullOrEmpty(data))
                {
                    return Content("No data found.");
                }

               
                var productList = JsonConvert.DeserializeObject<List<Product>>(data);

                
                return View(productList);
            }
            catch (Exception ex)
            {
                return Content("An error occurred: " + ex.Message);
            }
        }



    }
}
