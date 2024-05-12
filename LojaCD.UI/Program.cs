using LojaCD.Domain.Interfaces;
using LojaCD.Repository;
using LojaCD.Services.AutoMapper;
using LojaCD.Services.Interfaces;
using LojaCD.Services;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddTransient<IDbConnection>((sp) => new SqlConnection(connectionString));

builder.Services.AddScoped<ICDService, CDService>();
builder.Services.AddScoped<ICDRepository, CDRepository>();

builder.Services.AddScoped<IGeneroMusicalService, GeneroMusicalService>();
builder.Services.AddScoped<IGeneroMusicalRepository, GeneroMusicalRepository>();

builder.Services.AddScoped<IArtistaService, ArtistaService>();
builder.Services.AddScoped<IArtistaRepository, ArtistaRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
