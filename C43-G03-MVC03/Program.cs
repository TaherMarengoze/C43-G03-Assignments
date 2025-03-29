using Company.Data.Contexts;
using Company.Repo.Interfaces;
using Company.Repo.Repositories;
using Company.Service.Interfaces.Department;
using Company.Service.Interfaces.Employee;
using Company.Service.Mapping.Department;
using Company.Service.Mapping.Employee;
using Company.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace Company.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<CompanyDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("MainConn"));
        });

        //builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IDepartmentService, DepartmentService>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();

        builder.Services.AddAutoMapper(
            c => c.AddProfile(new EmployeeProfile()) //method 1
            //System.Reflection.Assembly.GetAssembly(typeof(EmployeeProfile)) //method 2
        );
        builder.Services.AddAutoMapper(c => c.AddProfile(new DepartmentProfile()));

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
    }
}
