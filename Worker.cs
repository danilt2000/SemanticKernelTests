using Microsoft.SemanticKernel;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;
using SemanticKernelTests.Controllers;

namespace SemanticKernelTests
{
        public class Worker : IHostedService
        {
                private readonly IHostApplicationLifetime _hostApplicationLifetime;
                private readonly Kernel _kernel;

                public Worker(IHostApplicationLifetime hostApplicationLifetime, Kernel kernel)
                {
                        _hostApplicationLifetime = hostApplicationLifetime;
                        _kernel = kernel;
                }

                public async Task StartAsync(CancellationToken cancellationToken)
                {
                        // Логика запуска сервиса
                    
                }

                public Task StopAsync(CancellationToken cancellationToken)
                {
                        // Логика завершения работы сервиса
                     
                        return Task.CompletedTask;
                }
        }
}