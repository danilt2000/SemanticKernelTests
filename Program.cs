
using Microsoft.SemanticKernel;
using SemanticKernelTests.Controllers;
using System.Net.Http;
using System.Numerics;
using System.Security.Principal;
using Nethereum.Model;
using Nethereum.Signer;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using Nethereum.Web3;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using Nethereum.Contracts.Extensions;

using Account = Nethereum.Web3.Accounts.Account;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;

namespace SemanticKernelTests
{
        public class Program
        {
                public static async Task Main(string[] args)
                {
                        var builder = WebApplication.CreateBuilder(args);

                        // Add services to the container.

                        builder.Services.AddControllers();
                        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                        builder.Services.AddEndpointsApiExplorer();
                        builder.Services.AddSwaggerGen();

                        builder.Services.AddKernel().AddOpenAIChatCompletion(
                                modelId: "gpt-4",
                                apiKey: "THEREPUTYOURCHATGPTKEY"
                        );

                        builder.Services.AddKernel().Plugins.AddFromType<StreamerInfoPlugin>();

                        var app = builder.Build();

                        // Configure the HTTP request pipeline.
                        if (app.Environment.IsDevelopment())
                        {
                                app.UseSwagger();
                                app.UseSwaggerUI();
                        }

                        app.UseHttpsRedirection();

                        app.UseAuthorization();


                        app.MapControllers();

                        app.Run();
                }
        }
}
