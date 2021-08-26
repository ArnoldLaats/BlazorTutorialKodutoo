using EmployeeManagement.ModelsKodutoo;
using EmployeeManagement.WebKodutoo.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.WebKodutoo.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();

        public string Id { get; set; }

        [Parameter]
        public string Id { get; set; }
        public object DeparmentId { get; private set; }

        protected async override Task OnInitalizedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            Departments = (await DepartmentService.GetDepartments()).ToList();
            DeparmentId = Employee.DepartmentId.ToString();
        }
    }
}
