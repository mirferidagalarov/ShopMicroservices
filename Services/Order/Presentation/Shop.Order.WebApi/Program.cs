using Microsoft.AspNetCore.Authentication.JwtBearer;
using Shop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using Shop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Shop.Order.Application.Features.CQRS.Queries.AddressQueries;
using Shop.Order.Application.Interfaces;
using Shop.Order.Application.Services;
using Shop.Order.Persistence.Context;
using Shop.Order.Persistence.Repositories;

namespace Shop.Order.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region DPInjection
            builder.Services.AddScoped<GetAddressQueryHandler>();
            builder.Services.AddScoped<GetAddressByIdQueryHandler>();
            builder.Services.AddScoped<CreateAddressCommandHandler>();
            builder.Services.AddScoped<UpdateAddressCommandHandler>();
            builder.Services.AddScoped<RemoveAddressCommandHandler>();


            builder.Services.AddScoped<GetOrderDetailQueryHandler>();
            builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
            builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
            builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
            builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();
            #endregion

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.Authority = builder.Configuration["IdentityServerUrl"];
                opt.Audience = "ResourceOrder";
                opt.RequireHttpsMetadata = false;
            });



            builder.Services.AddDbContext<OrderContext>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddApplicationService(builder.Configuration);


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
