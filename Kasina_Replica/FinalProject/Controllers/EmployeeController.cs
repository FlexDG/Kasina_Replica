using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmpDBContext _empdbContext;

        public EmployeeController(EmpDBContext empdbContext)
        {
            _empdbContext = empdbContext;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _empdbContext.Employees.Include(e => e.Designation).ToListAsync();
            return View(employees);
        }
        [HttpGet]
        public async Task<IActionResult> AddEmployee()
        {
            var designations = await _empdbContext.Designations.ToListAsync();
            ViewBag.DesignationList = new SelectList(designations, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            await _empdbContext.Employees.AddAsync(employee);
            await _empdbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(Guid id)
        {
            var designations = await _empdbContext.Designations.ToListAsync();
            ViewBag.DesignationList = new SelectList(designations, "Id", "Name");
            Employee? employee = await _empdbContext.Employees.FindAsync(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            _empdbContext.Employees.Update(employee);
            await _empdbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var employee = await _empdbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _empdbContext.Employees.Remove(employee);
            await _empdbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
