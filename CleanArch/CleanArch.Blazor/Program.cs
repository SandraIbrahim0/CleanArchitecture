using CleanArch.Blazor.Areas.Identity;
using CleanArch.Data.Context;
using CleanArch.IoC;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<ProductDBContext>(options =>
{
    options.UseSqlite("Data Source = Products.db");
});

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlite("Data Source = Identity.db");
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultUI().AddDefaultTokenProviders();
DependencyContainer.RegisterServices(builder.Services);
builder.Services.AddScoped<TokenProvider>();
//builder.Services.AddScoped<IEmailSender, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
