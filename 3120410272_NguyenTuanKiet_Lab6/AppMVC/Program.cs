using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
using WebMVC.Services;
using WebMVC.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.AddControllersWithViews();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
builder.Services.AddScoped<BookStoreDbContextSeeder>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookRepository, BookRepository>();

// Cấu hình Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Kích hoạt Session middleware
app.UseSession();
app.UseAuthorization();

// Cấu hình route cho Admin
app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{controller=Account}/{action=Login}/{id?}");

// Route mặc định cho Books
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=index}/");

// Chuyển hướng trang mặc định đến Admin/Account/Login
app.MapGet("/", async context =>
{
    context.Response.Redirect("/Admin/Account/Login");
    await Task.CompletedTask;
});

// Seed dữ liệu vào cơ sở dữ liệu
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<BookStoreDbContextSeeder>();
    await seeder.InitialiseAsync();
    await seeder.SeedAsync();
}

app.Run();
