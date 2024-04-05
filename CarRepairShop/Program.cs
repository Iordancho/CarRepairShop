using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CarRepairShop.Infrastructure.Data;
var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("CarRepairShopDbContextConnection") ?? throw new InvalidOperationException("Connection string 'CarRepairShopDbContextConnection' not found.");

//builder.Services.AddDbContext<CarRepairShopDbContext>(options =>
//    options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<CarRepairShopDbContext>();

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews();

builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

    
app.UseEndpoints(endpoints =>
{
    //endpoints.MapControllerRoute(
    //name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "MyArea",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
	endpoints.MapDefaultControllerRoute();
});


app.MapRazorPages();



await app.RunAsync();
