using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;

namespace SemanticKernelTests.Controllers
{
        public class UserInput
        {
                public string Command { get; set; }
        }
        [ApiController]
        [Route("[controller]")]
        public class WeatherForecastController : ControllerBase
        {
                private static readonly string[] Summaries = new[]
                {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

                private readonly ILogger<WeatherForecastController> _logger;
                private readonly IChatCompletionService _chatCompletionService;
                private readonly Kernel _kernel;

                public WeatherForecastController(ILogger<WeatherForecastController> logger, IChatCompletionService chatCompletionService, Kernel _kernel)
                {
                        _logger = logger;
                        _chatCompletionService = chatCompletionService;
                        this._kernel = _kernel;
                }

                [HttpPost("query")]
                public async Task<IActionResult> QueryUserCommand([FromBody] UserInput userInput)
                {
                        // Create chat history and add user's input
                        var chatHistory = new ChatHistory();
                        chatHistory.AddUserMessage(userInput.Command);

                        var data = await _chatCompletionService.GetChatMessageContentsAsync(chatHistory,
                                executionSettings: new AzureOpenAIPromptExecutionSettings
                                {
                                        User = "ElysiumBuddy",
                                        FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
                                        //AzureChatDataSource = new AzureSearchChatDataSource() { ... } // could be handy to set this up
                                },
                                kernel: _kernel);
                        // Set up execution settings


                        return Ok(new
                        {
                                UserInput = userInput.Command,
                                Response = data
                        });
                }

                [HttpGet(Name = "GetWeatherForecast")]
                public async Task<IEnumerable<WeatherForecast>> Get()
                {

                        ChatHistory history = [];
                        history.AddUserMessage("get_team_members");
                       
                        //var response = await _chatCompletionService.GetChatMessageContentAsync(
                        //        history, _kernel
                        ////kernel: kernel
                        //);
                        var data = await _chatCompletionService.GetChatMessageContentsAsync(history,
                                executionSettings: new AzureOpenAIPromptExecutionSettings
                                {
                                        User = "ElysiumBuddy",
                                        FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
                                        //AzureChatDataSource = new AzureSearchChatDataSource() { ... } // could be handy to set this up
                                },
                                kernel: _kernel);
                        foreach (var chatMessageContent in data)
                        {
                                Debug.Write(chatMessageContent);
                        }
                        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                        {
                                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                                TemperatureC = Random.Shared.Next(-20, 55),
                                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                        })
                        .ToArray();
                }
        }
}
