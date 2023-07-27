namespace SearchKernelProject.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.Extensions.Options;
using SearchKernelProject.Configuration;
using Microsoft.SemanticKernel;

[ApiController]
[Route("[controller]")]
public class QuestionController : ControllerBase
{
    private readonly ILogger<QuestionController> _logger;
    private readonly IOptions<OpenAPI> _openApi;
    //private readonly IKernel _kernel;

    public QuestionController(ILogger<QuestionController> logger,
        IOptions<OpenAPI> openApi//,
        //IKernel kernel
        )
    {
        _logger = logger;
        _openApi = openApi;
        //_kernel = kernel;
    }

    [HttpPost]
    [Route("/ask")]
    public async Task<ResponseModel> Get(
        [FromBody] QuestionModel model)
    {
        var builder = new KernelBuilder();

        var chatModel = "text-davinci-003";
        var openApiKey = _openApi.Value.OpenApiKey;
        builder.WithOpenAITextCompletionService(
                 chatModel,
                 openApiKey);

        var kernel = builder.Build();//_kernel;

        var prompt = @"{{$input}}

            One line TLDR with the fewest words.";

        var summarize = kernel.CreateSemanticFunction(prompt);

        var result1 = await summarize.InvokeAsync(model.Question);

        return new ResponseModel
        {
            Result = result1.Result,
        };
    }
}