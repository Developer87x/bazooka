

using Ocelot.DependencyInjection;
using Ocelot;
using Ocelot.Middleware;
using Serilog;

new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config
                    .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                    .AddJsonFile("configuration.json")
                    .AddEnvironmentVariables();
            })
            .ConfigureServices(s => {
                s.AddOcelot();
                s.AddCors(op=>{
                    op.AddPolicy("AllowAngularSite",p=>{
                        p.WithOrigins("http://localhost:4200");
                    });
                });
                
                
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                //add your logging
                var logger= new LoggerConfiguration().ReadFrom.Configuration(hostingContext.Configuration).Enrich.FromLogContext().CreateLogger();
                logging.ClearProviders();
                logging.AddSerilog(logger);
                

                
            })
            .UseIISIntegration()
            .Configure(app =>
            {
                app.UseOcelot().Wait();
                app.UseCors("AllowAngularSite");
                app.UseHttpsRedirection();
            })
            .Build()
            .Run();

