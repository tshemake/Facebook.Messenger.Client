using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;
using Facebook.Messenger.Client.Formatters;
using Facebook.Messenger.Client.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Facebook.Messenger.Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        private IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAggregateStore>(CreateEventStoreConnection());

            services.AddMvc(options =>
                {
                    options.InputFormatters.Insert(0, new RawRequestBodyInputFormatter());
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private AggregateStore CreateEventStoreConnection()
        {
            var localhost = new IPEndPoint(IPAddress.Loopback, 2113);

            var con = EventStoreConnection.Create(
                Configuration["eventStore:connectionString"], 
                ConnectionSettings.Create().KeepReconnecting(),
                Environment.ApplicationName);
            return new AggregateStore(con);
        }
    }
}
