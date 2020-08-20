using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Power.Models;
using Power.Services;

namespace Power.Pages
{
    public class employModel : PageModel
    {
        private readonly IEmployeeRepository dB;

        public employModel(IEmployeeRepository DB)
        {
            dB = DB;
        }
        public IEnumerable<Employee> employees { get; set; }
        public void OnGet()
        {
            employees = dB.GetAllEmployees();
        }
    }
}