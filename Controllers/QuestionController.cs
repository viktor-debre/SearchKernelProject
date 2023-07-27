namespace SearchKernelProject.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models;

[ApiController]
[Route("[controller]")]
public class QuestionController : ControllerBase
{
    private readonly ILogger<QuestionController> _logger;

    public QuestionController(ILogger<QuestionController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("/ask")]
    public IActionResult Get(
        [FromQuery] QuestionModel model)
    {
        return Ok();
    }
}