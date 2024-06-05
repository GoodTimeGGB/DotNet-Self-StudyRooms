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

// 注册Service
builder.Services.AddScoped<IMyService, MyService>();
builder.Services.AddScoped<MyFilter>();

// 注册全局过滤器
builder.Services.AddControllers(options => {
    options.Filters.Add<MyFilter>();
    options.Filters.Add<GlobalExceptionFilter>();
});

// 读取配置文件
var ipAddress = builder.Configuration["AppSettings:IpAddress"];
var port = builder.Configuration["AppSettings:Port"];

// 配置Kestrel服务器监听的IP地址和端口
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

#region [自己添加]

// 中间件异常处理
app.UseExceptionHandler("/Home/Error");

// 注册中间件
app.UseMiddleware<CustomExceptionHandlerMiddleware>();

#endregion

app.Run();
