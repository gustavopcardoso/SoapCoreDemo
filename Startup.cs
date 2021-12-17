using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using SoapCore;
using SoapCoreDemo.WebApi.Interfaces;
using SoapCoreDemo.WebApi.InternalServices;
using SoapCoreDemo.WebApi.SoapServices;

namespace soapcoredemo_webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSoapCore();
            services.TryAddScoped<PurchaseOrderSOAP>();

            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            var soapEncoder = new SoapEncoderOptions
            {
                MessageVersion = System.ServiceModel.Channels.MessageVersion.Soap12WSAddressing10,
                WriteEncoding = System.Text.Encoding.UTF8
            };

            var settings = Configuration.GetSection("FileWSDL").Get<WsdlFileOptions>();
            settings.AppPath = env.ContentRootPath;

            app.UseEndpoints(endpoints =>
            {
                endpoints.UseSoapEndpoint<PurchaseOrderSOAP>("/PurchaseOrderService", soapEncoder, SoapSerializer.XmlSerializer, false, null, settings);
                endpoints.MapControllers();
            });
        }
    }
}
