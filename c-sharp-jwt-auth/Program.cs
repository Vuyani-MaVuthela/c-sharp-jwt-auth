global using Microsoft.AspNetCore.Mvc;
global using c_sharp_jwt_auth.Entities;
global using c_sharp_jwt_auth.Helpers;
global using c_sharp_jwt_auth.Models;
global using c_sharp_jwt_auth.Services;

var builder = WebApplication.CreateBuilder(args);

{ // Add services to the container. //(Di ontainer)
    builder.Services.AddCors();
    builder.Services.AddControllers();

    builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    builder.Services.AddScoped<IUserService, UserService>();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

{ // Configure the HTTP request pipeline.
    app.UseCors(x => x
       .AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader());

    // custom jwt auth middleware
    app.UseMiddleware<JwtMiddleware>();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}

app.Run("https://localhost:4000");
