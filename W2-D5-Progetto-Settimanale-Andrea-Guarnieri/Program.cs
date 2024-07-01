using W2_D5_Progetto_Settimanale_Andrea_Guarnieri.Services;

var builder = WebApplication.CreateBuilder(args);

// Aggiunge i servizi al contenitore.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configura la pipeline delle richieste HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
