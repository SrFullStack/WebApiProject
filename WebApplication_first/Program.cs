using Microsoft.EntityFrameworkCore;
using Service;
using T_Repository;
using Swashbuckle.AspNetCore;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddControllers();
builder.Host.UseNLog();

string ConnectionString = builder.Configuration.GetConnectionString("home");

builder.Services.AddDbContext<UserContext>(option => option.UseSqlServer(ConnectionString));
//builder.Services.AddDbContext<UserContext>(option => option.UseSqlServer("Server=SRV2\\PUPILS;Database=User;Trusted_Connection=True;"));
//builder.Services.AddDbContext<UserContext>(option => option.UseSqlServer("Data Source=DESKTOP-2DTT4MQ;Initial Catalog=User2;Integrated Security=True"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
