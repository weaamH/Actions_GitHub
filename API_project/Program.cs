using Microsoft.Extensions.Configuration;
using API_project.Repositories;
using Microsoft.EntityFrameworkCore;
using API_project.Models;
using API_project;
using AutoMapper;
using API_project.ClassesViewModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Initilize();

var mapperConfig = new MapperConfiguration(mc => {
    mc.AddProfile(new MappingConfiguration());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();
app.UseExceptionHandlerMiddleware();
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
