using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EFCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


//for DependincyInjection can bi IoC
builder.Services.AddSingleton<IUserDal, EfUserDal>();
builder.Services.AddSingleton<IFormDal,EfFormDal>();
builder.Services.AddSingleton<IFieldDal,EfFieldDal>();


builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<IFormService, FormManager>();
builder.Services.AddSingleton<IFieldService, FieldManager>();
//----------------------------------



var app = builder.Build();

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
