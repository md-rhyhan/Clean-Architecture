using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(jsonOptions =>
{
    jsonOptions.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
    jsonOptions.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    jsonOptions.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});
var baseUrl = builder.Configuration.GetValue<string>("TestFluentValidationApiBase");
builder.Services.AddHttpClient("TestFluentValidationApi", c =>
{
    c.BaseAddress = new Uri(baseUrl!);
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
