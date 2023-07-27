namespace SearchKernelProject.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.Extensions.Options;
using SearchKernelProject.Configuration;

[ApiController]
[Route("[controller]")]
public class QuestionController : ControllerBase
{
    private readonly ILogger<QuestionController> _logger;
    private readonly IOptions<OpenAPI> _openApi;

    public QuestionController(ILogger<QuestionController> logger,
        IOptions<OpenAPI> openApi)
    {
        _logger = logger;
        _openApi = openApi;
    }

    [HttpGet]
    [Route("/ask")]
    public IActionResult Get(
        [FromQuery] QuestionModel model)
    {
        var key = _openApi.Value.OpenApiKey;
        return Ok();
    }
}