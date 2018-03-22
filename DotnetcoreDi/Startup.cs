using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.RegistrationAttributes;
using Autofac.Features.AttributeFilters;
using DotnetcoreDi.Controllers;
using DotnetcoreDi.Repositories;
using DotnetcoreDi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DotnetcoreDi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {

            _env = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }
        private readonly IHostingEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider  ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddControllersAsServices();

            // Create the container builder.
            var builder = new ContainerBuilder();

            // Note that Populate is basically a foreach to add things
            // into Autofac that are in the collection. If you register
            // things in Autofac BEFORE Populate then the stuff in the
            // ServiceCollection can override those things; if you register
            // AFTER Populate those registrations can override things
            // in the ServiceCollection. Mix and match as needed.
            builder.RegisterModule<AutoRegistrationModule>();
            builder.RegisterModule<DefaultModule>();
            builder.Populate(services);
            builder.RegisterType<ServiceOne>().As<IServiceOne>();
            builder.RegisterType<RepositoryY1>().Named<IRepositoryX>("firstY");
            builder.RegisterType<RepositoryY2>().Named<IRepositoryX>("secondY");

            builder.RegisterType<RepositoryX1>().Keyed<IRepositoryX>("firstX");
            builder.RegisterType<RepositoryX2>().Keyed<IRepositoryX>("secondX");

            builder.RegisterType<QuestionController>().WithAttributeFiltering();

            ApplicationContainer = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env,
            IApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // If you want to dispose of resources that have been resolved in the
            // application container, register for the "ApplicationStopped" event.
            // You can only do this if you have a direct reference to the container,
            // so it won't work with the above ConfigureContainer mechanism.
            appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
        }
    }
}
