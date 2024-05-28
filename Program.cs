using Microsoft.AspNetCore.Cors.Infrastructure;
using MyTea.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.AddScoped<DataService>();
builder.Services.AddScoped<FuncionarioService>();
builder.Services.AddScoped<DepartamentoService>();
builder.Services.AddScoped<LancamentoHorasService>();
builder.Services.AddScoped<NivelAcessoService>();
builder.Services.AddScoped<WBSService>();

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
