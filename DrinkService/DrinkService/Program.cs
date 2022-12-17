using DrinkService.Interfaces;
using DrinkService.Services;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(o =>
    o.AddPolicy("AllowAll", b =>
    {
        b.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    }));

// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// }).AddJwtAuthentication().AddBasicNsAuthentication(); //custom extensions

builder.Services.AddInfrastructure();

builder.Services.AddScoped<IDrinkChoiceService, DrinkChoiceService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

InitializeDatabase(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


void InitializeDatabase(IApplicationBuilder applicationBuilder)
{
    using var scope = applicationBuilder.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
    scope?.ServiceProvider.GetRequiredService<DrinkServiceDbContext>().Database.Migrate();
}