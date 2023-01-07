using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PS.MangoRestaurant.Services.ProductAPI;
using PS.MangoRestaurant.Services.ProductAPI.DbContexts;

var builder = WebApplication.CreateBuilder(args);

//                                                Add services to the container.

//Подключение к бд
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Подключение автомаппера
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Подключеие свагера
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Подключение контроллеров
builder.Services.AddControllers();

var app = builder.Build();

//                                              Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
