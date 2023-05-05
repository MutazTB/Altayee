using Domain;
using Domain.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Interfaces;
using Services;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager Configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers()
                    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


builder.Services.AddDbContext<AltayeeDBContext>(options => {
    // Our DATABASE_URL from js days
    string connectionString = Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<AltayeeDBContext>();

builder.Services.AddTransient<IUserService, IdentityUserService>();
builder.Services.AddTransient<IBrandsRepo<Brands>, BrandsRepo>();
builder.Services.AddTransient<IBrandsSvc<Brands>, BrandsSvc>();
//builder.Services.AddTransient<IProductsRepo<Products>, ProductsRepo>();
//builder.Services.AddTransient<IProductsSvc<Products>, ProductSvc>();
//builder.Services.AddTransient<IImagesRepo<Images>, ImagesRepo>();
//builder.Services.AddTransient<IImagesSvc<Images>, ImagesSvc>();
//builder.Services.AddTransient<IRelatedToRepo<Relateds>, RelatedsRepo>();
//builder.Services.AddTransient<IRelatedsSvc<Relateds>, RelatedsSvc>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
	.AddRazorPagesOptions(options =>
	{
		options.Conventions.AddAreaPageRoute("Admin", "/Account/Login", "/Admin/Account/Login");
	});

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
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();
