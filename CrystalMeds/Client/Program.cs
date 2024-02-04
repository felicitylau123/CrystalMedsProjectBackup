using System.Xml.Linq;
using CrystalMeds.Client;
using CrystalMeds.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddHttpClient("CrystalMeds.ServerAPI",client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddHttpClient("CrystalMeds.ServerAPI", (sp, client) => {
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress); client.EnableIntercept(sp);
})
.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CrystalMeds.ServerAPI"));
builder.Services.AddHttpClientInterceptor();

builder.Services.AddApiAuthorization();
builder.Services.AddScoped<HttpInterceptorService>();
await builder.Build().RunAsync();
