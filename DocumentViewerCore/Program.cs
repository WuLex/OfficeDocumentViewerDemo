using DocumentViewerCore.Common;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("default", c =>
{
    c.BaseAddress = new Uri("https://localhost");
    c.DefaultRequestHeaders.Add("Accept", "application/json");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

//◊¢≤·±‡¬ÎÃ·π©≥Ã–Ú
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

//≈‰÷√Http
HttpContextHelper.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());
HttpContextHelper.Configure(app.Services.GetRequiredService<IWebHostEnvironment>());

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();