﻿using System;
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
    public class NotesController : ControllerBase
    {
        private readonly FullStackDbContext _context;

        public NotesController(FullStackDbContext context)
        {
            _context = context;
        }

        // GET: api/notes
        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            var notes = await _context.Notes.ToListAsync();
            return Ok(notes);
        }

        // POST: api/Notes
        [HttpPost]
        public async Task<IActionResult> CreateAssignment([FromBody] Note note)
        {
            note.Id = Guid.NewGuid();
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return Ok(note);
        }

        // GET: api/Notes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNote(Guid id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(t => t.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        // PUT: api/Notes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(Guid id, [FromBody] Note updatedTask)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(t => t.Id == id);
            if (note == null)
            {
                return NotFound();
            }

            note.Title = updatedTask.Title;
            note.Content = updatedTask.Content;
            note.Date = updatedTask.Date;

            await _context.SaveChangesAsync();
            return Ok(note);
        }

        // DELETE: api/Notes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(Guid id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(t => t.Id == id);
            if (note == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return Ok(note);
        }
    }
}
