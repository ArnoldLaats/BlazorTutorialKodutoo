using EmployeeManagement.ModelsKodutoo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ApiKodutoo.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 2, DepartmentName = "HR" });


            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Hastings",
                Email = "David@pragimtech.com",
                DateOfBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/john.png"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "Wicky",
                LastName = "Sasky",
                Email = "SasWicky@dunno.com",
                DateOfBirth = new DateTime(1992, 20, 7),
                Gender = Gender.Female,
                DepartmentId = 1,
                PhotoPath = "images/wicky.png"
            });
        }
    }
}
