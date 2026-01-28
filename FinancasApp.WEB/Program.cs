using FinancasApp.WEB;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//configurando a biblioteca HTTPCLIENTE (fazer requisições para Apis)
builder.Services.AddScoped(sp => new HttpClient
{
    //Endereço da API
    BaseAddress = new Uri("http://localhost:5107/")
});

await builder.Build().RunAsync();
