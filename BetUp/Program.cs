//добавить:
//1)NLOG(логирование в файлы)
//2)Тесты Xunit
//3)ASP.NET Identity(пользаки)
//4)Развертывание
//5)docker + k8s + redis
//6)gitlab ci/cd
//7)Ну и получение данных :)

using BetUp.DbContexts;
using BetUp.DbModels;
using BetUp.HttpClients.Interfaces;
using BetUp.Repositories;
using BetUp.Repositories.IRepositories;
using BetUp.Services;
using BetUp.Services.IServices;
using MarketPlace.Repositories.Base;
using MarketPlace.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using QuartzApp.Jobs;
using System.Net;
using Quartz;
using BetUp.Logger.Interfaces;
using BetUp.Logger;

System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//db context
builder.Services.AddDbContext<BetUpContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("BetUpDb")));

builder.Services.AddScoped<ILoggerActions, LoggerActions>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<ISaveModelService, SaveModelService>();
builder.Services.AddScoped<IBaseRepository<Role>, BaseRepository<Role>>();
builder.Services.AddScoped<IGenerateModelService<PariBetClient>, GenerateModelService<PariBetClient>>();
builder.Services.AddScoped<IGenerateModelService<WinlineClient>, GenerateModelService<WinlineClient>>();
builder.Services.AddScoped<IJsonToModelConvertService, JsonToModelConvertService>();

builder.Services.AddHttpClient<PariBetClient>(
    client =>
    {
        client.Timeout = TimeSpan.FromSeconds(10);
    }).ConfigurePrimaryHttpMessageHandler(() => 
    new HttpClientHandler { 
        AutomaticDecompression = DecompressionMethods.GZip,
        //ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
    });

builder.Services.AddHttpClient<WinlineClient>(
    client =>
    {
        client.Timeout = TimeSpan.FromSeconds(10);
    }).ConfigurePrimaryHttpMessageHandler(() =>
    new HttpClientHandler
    {
        AutomaticDecompression = DecompressionMethods.GZip,
        //ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
    });

//QUARTZ
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    // Just use the name of your job that you created in the Jobs folder.
    var jobKey = new JobKey("SendEmailJob");

    q.AddJob<EmailSender>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("trigger1", "group1")     // идентифицируем триггер с именем и группой
                .StartAt(new DateTimeOffset(DateTime.UtcNow).AddSeconds(5))                            // запуск сразу после начала выполнения
                .WithSimpleSchedule(x => x            // настраиваем выполнение действия
                    .WithIntervalInSeconds(20)          // через 1 минуту
                    .RepeatForever())                   // бесконечное повторение
    );
});

//activate Scheduler
builder.Services.AddQuartzHostedService(qService => qService.AwaitApplicationStarted = true);


//add Cors
/*builder.Services.AddCors(options => options.AddPolicy(name: "FrontendUI", policy =>
{
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
*/

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//use cors
//app.UseCors("FrontendUI");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();