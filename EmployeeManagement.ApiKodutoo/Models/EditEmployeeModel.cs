using System;
using EmployeeManagement.ModelsKodutoo.CustomValidators;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.ModelsKodutoo;
using EmployeeManagement.WebKodutoo.Services;

namespace EmployeeManagement.ApiKodutoo.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; } = new Department();
        public NavigationManager NavigationManager { get; set; }

        protected void HandleValidSubmit()
        {
            Mapper.Map(EditEmployeeModel, Employee);
            var result = await EmployeeService.UpdateEmployee(Employee);

            if(result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
