using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Power.Models;
using Power.Services;

namespace Power.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
        {
           _employeeRepository = employeeRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public Employee Employee{ get; set; }

        [BindProperty]
        public IFormFile Photo{ get; set; }
        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployee(id);

            if (Employee == null) return RedirectToPage("/NotFound");

            return Page();
        }
        public IActionResult OnPost(Employee employee)
        {
            if (Photo != null) {
                if (employee.PhotoPath != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", employee.PhotoPath);
                    System.IO.File.Delete(filePath);
                }
                employee.PhotoPath = UpLoadFile();

            }
            Employee = _employeeRepository.Update(employee);
            return RedirectToPage("employ");
        }

        private string UpLoadFile()
        {
            string UniqFileName = null;

            if (Photo != null)
            {
                string UploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath,"images");
                UniqFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string FilePath = Path.Combine(UploadsFolder, UniqFileName);

                using (var fs = new FileStream(FilePath, FileMode.Create))
                {
                    Photo.CopyTo(fs);
                }
            }

            return UniqFileName;
        }
    }
}
