using ChatService.Hubs;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllHeaders",

        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        }


        );
});

builder.Services.AddSignalR();

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowAllHeaders");

app.MapHub<MessageHub>("/MessageHub");

app.Run();
