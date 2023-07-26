using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullStack.API.Data;
using FullStack.API.Models;

namespace FullStack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly FullStackDbContext _context;

        public AssignmentController(FullStackDbContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<IActionResult> GetAssignments()
        {
            var assignments = await _context.Assignments.ToListAsync();
            return Ok(assignments);
        }

        // POST: api/Tasks
        [HttpPost]
        public async Task<IActionResult> CreateAssignment([FromBody] Assignment assignment)
        {
            assignment.Id = Guid.NewGuid();
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
            return Ok(assignment);
        }

        // GET: api/Tasks/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignment(Guid id)
        {
            var assignment = await _context.Assignments.FirstOrDefaultAsync(t => t.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }
            return Ok(assignment);
        }

        // PUT: api/Tasks/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignment(Guid id, [FromBody] Assignment updatedTask)
        {
            var assignment = await _context.Assignments.FirstOrDefaultAsync(t => t.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            assignment.Title = updatedTask.Title;
            assignment.Description = updatedTask.Description;
            assignment.DueDate = updatedTask.DueDate;
            assignment.Completed = updatedTask.Completed;

            await _context.SaveChangesAsync();
            return Ok(assignment);
        }

        // DELETE: api/Tasks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(Guid id)
        {
            var assignment = await _context.Assignments.FirstOrDefaultAsync(t => t.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return Ok(assignment);
        }
    }
}
