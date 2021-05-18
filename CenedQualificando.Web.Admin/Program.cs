using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Queries;
using CenedQualificando.Web.Admin.Services;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddMudServices();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<StateContainer>();

            builder.Services.AddScoped<IFiscalSalaQuery, FiscalSalaQuery>();

            builder.Services.AddScoped<IFiscalSalaService, FiscalSalaService>();

            await builder.Build().RunAsync();
        }
    }
}
