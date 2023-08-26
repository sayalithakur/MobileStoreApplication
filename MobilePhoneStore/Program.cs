using Microsoft.EntityFrameworkCore;
using MobilePhoneStore.DBContext;
using MobilePhoneStore.Repository;
using MobilePhoneStore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var data = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Demo;Integrated Security=True;TrustServerCertificate=False;";
builder.Services.AddDbContext<MobileStoreDBContext>(options =>
{
    options.UseSqlServer(data);
});

builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IMobilePhoneRepository, MobilePhoneRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
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
