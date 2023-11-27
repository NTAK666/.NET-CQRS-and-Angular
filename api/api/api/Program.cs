using System.Reflection;
using System.Text.Json.Serialization;
using api.Database;
using api.Models.User;
using api.Repositories.Interfaces;
using api.Repositories.Repositories;
using api.Repositories.UoW;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(op =>
{
	op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(otps => { otps.EnableAnnotations(); });
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddLogging(config =>
{
	config.AddConsole();
	config.AddDebug();
});
// region Database

var connectionString = builder.Configuration["ConnectionStrings:Database"];
builder.Services.AddDbContext<SimpleDBContext>(opts => { opts.UseNpgsql(connectionString); });
builder.Services.AddIdentity<User, Role>(op =>
	{
		op.User.RequireUniqueEmail = true;
		op.Password.RequireDigit = true;
		op.Password.RequireLowercase = true;
		op.Password.RequireNonAlphanumeric = false;
		op.Password.RequireUppercase = false;
		op.Password.RequiredLength = 6;
		op.Password.RequiredUniqueChars = 1;
	})
	.AddEntityFrameworkStores<SimpleDBContext>()
	.AddDefaultTokenProviders();

builder.Services
	.AddScoped<IUnitOfWork, UnitOfWork>()
	.AddScoped<ICategoryRepository, CategoryRepository>()
	.AddScoped<IProductRepository, ProductRepository>()
	.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


// endregion
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
