using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Apartment.App.Business.Abstract;
using Apartment.App.Business.Concrete;
using Apartment.App.DataAccess.EntityFramework;
using Apartment.App.DataAccessEntityFramework.Repository.Abstract;
using Apartment.App.DataAccessEntityFramework.Repository.Concrete;
using Apartment.App.Domain.Entities.IdentityEntities;
using Apartment.App.Web.Background;
using Apartment.App.Web.Models.MailModels;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Apartment.App.Web
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IMailSendService, MailSendService>();
            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            services.AddHostedService<BackgroundWorker>();
            services.AddSingleton<IBackgroundQueue<Mail>, BackgroundQueue<Mail>>();
            services.AddScoped<IMailSendService, MailSendService>();
            services.AddScoped<IHousingService, HousingService>();
            services.AddScoped<IinvoiceService, InvoiceService>();
            services.AddScoped<IinvoiceTypeService, InvoiceTypeService>();
            services.AddScoped<IBlockService,BlockService>();
            services.AddScoped<IFloorService, FloorService>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
