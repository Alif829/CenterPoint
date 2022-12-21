using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CenterPoint.Data;
using CenterPoint.Models;
using CenterPoint.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CenterPoint.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _emprepo;

        public EmployeesController(IEmployeeRepository emprepo)
        {
            _emprepo = emprepo;
        }
       
        //public EmployeesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(_emprepo.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchString, bool notUsed)
        {
            var employee = _emprepo.Get(searchString);
            return View(employee);
        }



        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _emprepo.Find(id.GetValueOrDefault());

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Age,Gender,DateOfBirth")] Employee employee)
        {
           
            if (ModelState.IsValid)
            {
                _emprepo.Add(employee);

                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }


        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _emprepo.Find(id.GetValueOrDefault());
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Age,Gender,DateOfBirth")] Employee employee)
        {
            if (id != employee.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _emprepo.Update(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _emprepo.Delete(id.GetValueOrDefault());
            return RedirectToAction(nameof(Index));
        }

    }
}
