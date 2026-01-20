using DATN_TMS.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession(); 

builder.Services.AddDbContext<QuanLyDoAnTotNghiepContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.UseSession();
<<<<<<< HEAD

//app.MapControllerRoute(
//    name: "areas",
//    pattern: "{area:exists}/{controller=QuanLyDotDoAn}/{action=Index}/{id?}");
//Gi?ng vien
=======

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=QuanLyDotDoAn}/{action=Index}/{id?}");

>>>>>>> c87eb8f5d493f6a5fe313fffa7b0a2f410b7a55b
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=QuanLyDotDoAn}/{action=DeXuatDT}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=QuanLyDotDoAn}/{action=DeXuatDT}/{id?}"
);
//Sinhvien
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=QL_DotDoAn}/{action=DK_NV}/{id?}"
);

app.MapControllerRoute(
    name: "default",
<<<<<<< HEAD
    pattern: "{controller=QL_DotDoAn}/{action=DK_NV}/{id?}"
);
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Account}/{action=Login}/{id?}");
=======
    pattern: "{controller=Account}/{action=Login}/{id?}");
>>>>>>> c87eb8f5d493f6a5fe313fffa7b0a2f410b7a55b

app.Run();