

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Error/HandleError/{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
                name: "Etkinlik", pattern: "Etkinlik/etkinlik-list", defaults: new { controller = "Etkinlik", action = "Index" }
                );


app.MapControllerRoute(
                name: "Bilet", pattern: "Bilet/bilet-list", defaults: new { controller = "Bilet", action = "Index" }
                );


app.MapControllerRoute(name: "Salon", pattern: "Salon/salon-list", defaults: new { controller = "Salon", action = "Index" });


app.MapControllerRoute(
                name: "Seans", pattern: "Seans/seans-list", defaults: new { controller = "Seans", action = "Index" }
                );

app.MapControllerRoute(
                name: "Seyirci", pattern: "Seyirci/seyirci-list", defaults: new { controller = "Seyirci", action = "Index" }
                );


app.MapControllerRoute(
                name: "Tur", pattern: "Tur/tur-list", defaults: new { controller = "Tur", action = "Index" }
                );

app.MapControllerRoute(
                name: "Slider", pattern: "Slider/slider-list", defaults: new { controller = "Slider", action = "Index" }
                );

app.MapControllerRoute(
                name: "Menu", pattern: "Menu/menu-list", defaults: new { controller = "Menu", action = "Index" }
                );
app.Run();
