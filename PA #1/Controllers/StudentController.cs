using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering; 
using PA__1.Data;
using PA__1.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PA__1.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display all students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // Show Add Student Form
        public IActionResult Create()
        {
            // Create a SelectList for programs
            ViewBag.Programs = new SelectList(new string[] { "Computer Programmer", "Software Engineering", "Data Science", "IT Security", "Bachelor of Applied Computer Science" });
            return View();
        }

        // Handle Add Student Submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Pass the SelectList again in case of validation errors
            ViewBag.Programs = new SelectList(new string[] { "Computer Science", "Software Engineering", "Data Science", "IT Security", "Business Informatics" });
            return View(student);
        }

        // Show Edit Student Form
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            // Creating List of Programs available
            ViewBag.Programs = new SelectList(new string[] { "Computer Programmer", "Software Engineering", "Data Science", "IT Security", "Bachelor of Applied Computer Science" }, student.Program);
            return View(student);
        }

        // Handle Edit Student 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Pass the list again in case of validation errors
            ViewBag.Programs = new SelectList(new string[] { "Computer Programmer", "Software Engineering", "Data Science", "IT Security", "Bachelor of Applied Computer Science" }, student.Program);
            return View(student);
        }

        // Show Delete Confirmation
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            return View(student);
        }

        // Handle Delete 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
