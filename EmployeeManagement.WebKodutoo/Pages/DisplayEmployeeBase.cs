using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.ModelsKodutoo;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.WebKodutoo.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }
        [Parameter]
        public bool ShowFooter { get; set; }
        public EventCallback<bool> OnEmployeeSelection { get; set; }

        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            await OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }
    
}
