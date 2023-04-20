//using api: https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=6
//and: https://deckofcardsapi.com/api/deck/<<deck_id>>/draw/?count=5



using Deck_of_Cards_Api_2023.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ShuffleApiService>(s =>
{
    s.BaseAddress = new Uri("https://deckofcardsapi.com/api/deck/new/");
});
builder.Services.AddHttpClient<DrawApiService>(d =>
{
    d.BaseAddress = new Uri("https://deckofcardsapi.com/api/deck/");
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
