---

Function Calling in .NET Semantic Kernel in 5 Minutes

Function calling is a way to enable LLM to call your functions in the code. Semantic Kernel does this elegantly and simply.

What is this?

Instead of simply generating text, the model can call real functions in your code - send emails, read databases, call APIs.

Quick Start1. Install the package:
dotnet add package Microsoft.SemanticKernel
2. Create a plugin:
public class WeatherPlugin
{
    [KernelFunction]
    [Description("Get weather for a city")]
    public string GetWeather(string city)
    {
        return $"In {city} it's currently 68°F, sunny";
    }
}
3. Use it:
var kernel = Kernel.CreateBuilder()
    .AddOpenAIChatCompletion("gpt-4", apiKey)
    .Build();
kernel.Plugins.AddFromType<WeatherPlugin>();
var result = await kernel.InvokePromptAsync(
    "What's the weather in Prague?");
Why Do You Need This?
🔌 Integrate AI with your business logic
🎯 Precise actions instead of hallucinations
🚀 Rapid AI agent development

Conclusion
Semantic Kernel turns function calling from a complex task into 10 lines of code. Try it yourself!

---
