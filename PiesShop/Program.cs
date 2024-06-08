using PiesShop.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPieRepository, PieReposetory>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<IShopingCard, ShopingCard>(xx => ShopingCard.GetCart(xx));

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ShopDBContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

var app = builder.Build();
app.UseStaticFiles();////?? 
app.UseSession();

app.MapControllerRoute(name:"default",//this for first page when we start the project 
    pattern:"{controller=home}/{action=Home}/{id?}" );//shoud take care of space
app.Run();

//app.UseRouting();//when we need to use "UseEndpoints" must we call this feature 
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "products",
//        pattern: "app/Products",
//        defaults: new { controller = "Pie", action = "List" }
//    );
//    endpoints.MapControllerRoute(
//        name: "allproducts",
//        pattern: "app/allproducts",
//        defaults: new { controller = "Pie", action = "List" }
//    );
//    endpoints.MapControllerRoute(
//        name: "products",
//        pattern: "app/products/{category}/{id}",
//        defaults: new { controller = "Pie", action = "Details" }
//    );
//});





