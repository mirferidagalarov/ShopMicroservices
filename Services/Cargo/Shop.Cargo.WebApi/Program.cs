using Microsoft.AspNetCore.Authentication.JwtBearer;
using Shop.Cargo.Business.Abstract;
using Shop.Cargo.Business.Concrete;
using Shop.DataAccess.Abstract;
using Shop.DataAccess.Concrete.DataContext;
using Shop.DataAccess.Concrete.EfRepositories;

namespace Shop.Cargo.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.Authority = builder.Configuration["IdentityServerUrl"];
                opt.Audience = "ResourceCargo";
                opt.RequireHttpsMetadata = false;

            });
            #region DP Injection
            builder.Services.AddDbContext<CargoContext>();
            builder.Services.AddScoped<ICargoCompanyDal, CargoCompanyEfDal>();
            builder.Services.AddScoped<ICargoCompanyService, CargoCompanyService>();
            builder.Services.AddScoped<ICargoCustomerDal, CargoCustomerEfDal>();
            builder.Services.AddScoped<ICargoCustomerService, CargoCustomerService>();
            builder.Services.AddScoped<ICargoDetailDal, CargoDetailEfDal>();
            builder.Services.AddScoped<ICargoDetailService, CargoDetailService>();
            builder.Services.AddScoped<ICargoOperationDal, CargoOperationEfDal>();
            builder.Services.AddScoped<ICargoOperationService, CargoOperationService>();
            #endregion


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
