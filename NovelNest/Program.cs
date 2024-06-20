


using Microsoft.EntityFrameworkCore;
using NovelNest.DataAccess.Data;
using NovelNest.Repository;
using NovelNest.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using NovelNest.Utility;
using Stripe;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container. //services are registered to dependency injection
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));  //inject value from appsettings for stripe our secret api keys and put them into the stripesetting model in the utilties because the names are same in both the files for the properties
////as long as the prop names inside StripeSettings match what is insie Stripe they will be automatically inject the values in prop
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();



//for one request it will use the same service -AddScoped
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
//to configure the stripe package with out apikey present in the appsetting.json
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
//default route that .NET has configured 
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();