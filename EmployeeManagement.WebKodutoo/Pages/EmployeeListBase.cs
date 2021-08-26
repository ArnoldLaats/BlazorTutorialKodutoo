using Microsoft.AspNetCore.Components;
using EmployeeManagement.ModelsKodutoo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.WebKodutoo.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadEmployees);
        }

        private void LoadEmployees()
        {
            System.Threading.Thread.Sleep(3000);
            Employee e1 = new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Hastings",
                Email = "David@pragimtech.com",
                DateOfBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/john.png"
            };
            Employee e2 = new Employee
            {
                EmployeeId = 1,
                FirstName = "Wicky",
                LastName = "Sasky",
                Email = "SasWicky@dunno.com",
                DateOfBirth = new DateTime(1992, 20, 7),
                Gender = Gender.Female,
                DepartmentId = 1,
                PhotoPath = "images/wicky.png"
            };

            Employees = new List<Employee> { e1, e2 };
        }
    }
}
