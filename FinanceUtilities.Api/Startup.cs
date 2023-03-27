using FinanceUtilities.Api.Helpers;
using FinanceUtilities.Core;
using FinanceUtilities.Core.Mappers;
using FinanceUtilities.Core.Model;
using FinanceUtilities.Core.Services;
using FinanceUtilities.Core.Settings;
using FinanceUtilities.Data;
using FinanceUtilities.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinanceUtilities.Api
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

            // services.AddMvc().AddJsonOptions(options =>
            //     {
            //         options.JsonSerializerOptions.PropertyNamingPolicy = null;
            //     });

            // configure basic authentication 
            // services.AddAuthentication("BasicAuthentication")
            //     .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<ILoanCompareService, LoanCompareService>();
            services.AddScoped<ILoanScraperService, LoanScraperService>();
            services.AddScoped<IEntityService<LoanType, LoanType>, LoanTypeService>();
            services.AddScoped<IEntityService<IdName, ReferenceInterest>, ReferenceInterestService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IEntityService<IdName, ExpenseType>, ExpenseTypeService>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoanTotalsFactory, LoanTotalsFactory>();
            services.AddScoped<ILoanCalculate, LoanCalculate>();
            services.AddScoped<IQuoteRequestService, QuoteRequestService>();
            services.AddScoped<IExpensesService, ExpensesService>();
            services.AddScoped<ICurrencyUtils, CurrencyUtils>();
            var connstring = Configuration.GetConnectionString("FinanceDatabase");
            services.AddSingleton<ISettings, Settings>(a=> new Settings(new FinanceContext(null, connstring)));
            services.AddCors();

            services.AddScoped<IFinanceContext, FinanceContext>();
            services.AddDbContext<FinanceContext>(options => options.UseSqlServer(connstring));
            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.WithOrigins(new [] {"http://localhost:4200","https://test.kreditinfo.mk","https://kreditinfo.mk"})
                   .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseOpenApi();
			app.UseSwaggerUi3();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
