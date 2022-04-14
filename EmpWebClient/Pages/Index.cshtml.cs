using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using EmpWebClient;
using System.Text.Json;
using Newtonsoft.Json;

namespace EmpWebClient.Pages;

public class IndexModel : PageModel
{
    public List<Employee> Employees { get; set; }
    private readonly ILogger<IndexModel> _logger;

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _config;

    public IndexModel(IHttpClientFactory httpClientFactory, ILogger<IndexModel> logger, IConfiguration config)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _config = config;
    }

    public async Task OnGet()
    {

        var httpClient = _httpClientFactory.CreateClient();

        var httpResponseMessage = await httpClient.GetAsync(_config.GetConnectionString("EmpApi"));

        httpResponseMessage.EnsureSuccessStatusCode();

        string content = await httpResponseMessage.Content.ReadAsStringAsync();


        Employees = JsonConvert.DeserializeObject<List<Employee>>(content);

    }
}
