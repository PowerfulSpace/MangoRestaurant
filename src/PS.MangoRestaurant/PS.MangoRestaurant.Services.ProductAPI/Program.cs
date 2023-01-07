using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PS.MangoRestaurant.Services.ProductAPI;
using PS.MangoRestaurant.Services.ProductAPI.DbContexts;
using PS.MangoRestaurant.Services.ProductAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

//                                                Add services to the container.

//����������� � ��
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//����������� �����������
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//����������� ��������� ������������
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//���������� �������
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//����������� ������������
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
