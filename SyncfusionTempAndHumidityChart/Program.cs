using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using ServiceLayer.Repository;
using ServiceLayer.Services;

namespace SyncfusionTempAndHumidityChart
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Add your Syncfusion license key for Blazor platform with corresponding Syncfusion NuGet version referred in project. For more information about license key see https://help.syncfusion.com/common/essential-studio/licensing/license-key.
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDM5ODMwQDMxMzkyZTMxMmUzME1uTzMvdG1UbzhjSEU4WlhKMDVjRHdHUUlFejk4eERiUiswaGNOYWRoU2c9"); 
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            

            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IGenericRepository, GenericRepository>();
            builder.Services.AddScoped<IMeasurementService, MeasurementService>();

            builder.Services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader());
            });

            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Auth0", options.ProviderOptions);
                options.ProviderOptions.ResponseType = "code";
            });

            await builder.Build().RunAsync();
        }
    }
}
