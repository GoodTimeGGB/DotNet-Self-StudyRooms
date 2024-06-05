using System.Net;
using WebApiStudy.Api.Filter;
using WebApiStudy.Common.Core.Middleware;
using WebApiStudy.Service;
using WebApiStudy.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ע��Service
builder.Services.AddScoped<IMyService, MyService>();
builder.Services.AddScoped<MyFilter>();

// ע��ȫ�ֹ�����
builder.Services.AddControllers(options => {
    options.Filters.Add<MyFilter>();
    options.Filters.Add<GlobalExceptionFilter>();
});

// ��ȡ�����ļ�
var ipAddress = builder.Configuration["AppSettings:IpAddress"];
var port = builder.Configuration["AppSettings:Port"];

// ����Kestrel������������IP��ַ�Ͷ˿�
var host = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder => {
        webBuilder.UseKestrel(options => {
            options.Listen(IPAddress.Parse(ipAddress), int.Parse(port));
        });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#region [�Լ����]

// �м���쳣����
app.UseExceptionHandler("/Home/Error");

// ע���м��
app.UseMiddleware<CustomExceptionHandlerMiddleware>();

#endregion

app.Run();
