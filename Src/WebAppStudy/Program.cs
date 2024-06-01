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

app.Run();

// 中间件异常处理
app.UseExceptionHandler("/Home/Error");

// 注册中间件
app.UseMiddleware<CustomExceptionHandlerMiddleware>();
