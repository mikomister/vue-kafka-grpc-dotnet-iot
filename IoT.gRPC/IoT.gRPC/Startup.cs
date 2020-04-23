using IoT.gRPC.kafka;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IoT.gRPC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomConsumer, Consumer>();
            services.AddGrpc();
            services.AddGrpcWeb(o => o.GrpcWebEnabled = true);

            services.AddCors(
                o => o.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
                })
            );
            services.AddSpaStaticFiles();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseGrpcWeb(); // Must be added between UseRouting and UseEndpoints

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<LigthSensorService>().RequireCors("AllowAll"); ;
                //endpoints.MapGrpcService<LightSensorMessage>().EnableGrpcWeb();

            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
