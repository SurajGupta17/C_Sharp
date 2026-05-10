using EmployeeAdminPortal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Manager,Employee")]
    public class ChatController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IConfiguration configuration;
        private readonly HttpClient httpClient;

        public ChatController(ApplicationDbContext dbContext, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
            this.httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost]
        public async Task<IActionResult> Chat([FromBody] string userMessage)
        {
            // tasks fetch from db
            var tasks = await dbContext.Tasks
                                       .Include(t => t.Employee)
                                       .ToListAsync();
            //Employee Fetch from db
            var employee = await dbContext.employees.ToListAsync();

            // Tasks summary
            var taskSummary = string.Join("\n", tasks.Select(t =>
                $"Task: {t.Title}, Employee: {t.Employee?.name}, Completed: {t.IsCompleted}"));

            //Employee Summary
            var EmpSummary = string.Join("\n", employee.Select(e =>
                $"Name:{e.name}, Email:{e.email},Salary:{e.salary}"));

            // Groq ko message bhejo
            var prompt = $"Here is employee data:\n{EmpSummary}\n\nHere is the task data:\n{taskSummary}\n\nUser question: {userMessage}";

            var requestBody = new
            {
                model = configuration["Groq:Model"],
                messages = new[]
                {
                    new { role = "system", content = "You are a helpful assistant that answers questions about employee tasks." },
                    new { role = "user", content = prompt }
                }
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {configuration["Groq:ApiKey"]}");

            var response = await httpClient.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);
            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<dynamic>(responseString);

            if (result?.choices == null)
                return BadRequest("Groq API error: " + responseString);

            string answer = result.choices[0].message.content.ToString();

            return Ok(answer);
        }
    }
}