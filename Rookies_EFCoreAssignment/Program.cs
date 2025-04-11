using Microsoft.EntityFrameworkCore;
using Rookies_EFCoreAssignment.Application;
using Rookies_EFCoreAssignment.Domain.Interfaces;
using Rookies_EFCoreAssignment.Infrastructure.Data;
using Rookies_EFCoreAssignment.Infrastructure.Repositories;

namespace Rookies_EFCoreAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options
                => options.UseSqlServer(connectionString));

            builder.Services.AddApplicationServices();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<ISalaryRepository, SalaryRepository>();
            builder.Services.AddScoped<IProjectEmployeeRepository, ProjectEmployeeRepository>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.Migrate();
            }
            //Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            app.UseCors(builder =>
            {
                builder.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });

            app.Run();
        }
    }
}
