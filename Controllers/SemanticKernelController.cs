using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace SemanticKernelTests.Controllers
{
        public class UserInput
        {
                public string Command { get; set; }
        }
        
        [ApiController]
        [Route("[controller]")]
        public class SemanticKernelController : ControllerBase
        {
                private readonly ILogger<SemanticKernelController> _logger;
                private readonly IChatCompletionService _chatCompletionService;
                private readonly Kernel _kernel;

                public SemanticKernelController(ILogger<SemanticKernelController> logger, IChatCompletionService chatCompletionService, Kernel _kernel)
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
                                        User = "Buddy",
                                        //ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions,
                                        FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
                                        //AzureChatDataSource = new AzureSearchChatDataSource() { ... } // could be handy to set this up
                                },
                                kernel: _kernel);

                        return Ok(new
                        {
                                UserInput = userInput.Command,
                                Response = data
                        });
                }
        }
}
