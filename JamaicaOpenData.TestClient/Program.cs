// See https://aka.ms/new-console-template for more information
using JamaicaOpenData.SharedLibrary.Common.Services;
using JamaicaOpenData.SharedLibrary.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");


try
{
    var builder = new HostBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        services.RegisterJamaicaOpenDataServices();
    }).UseConsoleLifetime();

    var host = builder.Build();

    using (var serviceScope  = host.Services.CreateScope())
    {
        var services = serviceScope.ServiceProvider;
        var jamaicaOpenDataService =  services.GetRequiredService<IJamaicaOpenDataService>();
        var result = await jamaicaOpenDataService.GetPetrolPrices(5, 1);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    throw;
}

//var jamaicaOpenDataService = new JamaicaOpenDataService();