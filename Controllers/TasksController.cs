using LabProjectTracker.Data;
using LabProjectTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabProjectTracker.Controllers
{
    public class TasksController : Controller
    {
        private readonly AppDbContext _context;
        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(int projectId)
        {
            ViewBag.ProjectId = projectId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _context.TaskItems.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Projects", new { id = task.ProjectId });
            }
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Complete(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);
            if (task != null)
            {
                task.Status = "Done";
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Details", "Projects", new { id = task.ProjectId });
        }
    }
}
