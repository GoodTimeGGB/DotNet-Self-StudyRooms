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

// �м���쳣����
app.UseExceptionHandler("/Home/Error");

// ע���м��
app.UseMiddleware<CustomExceptionHandlerMiddleware>();
