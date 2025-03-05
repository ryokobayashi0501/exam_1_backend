using Microsoft.AspNetCore.Mvc;
using exam_1_backend.Models;
using exam_1_backend.Data;

namespace exam_1_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : Controller
    {
        [HttpGet]
        public IActionResult GetString()
        {
            using (NoteContext nc = new NoteContext())
            {
                List<Note> notes = nc.Note.ToList();
                return Ok(notes);
            }
        }

        [HttpPost]
        public IActionResult PostString([FromBody] Note newNote)
        {
            if (newNote == null)
            {
                return BadRequest("Note Data is required");            
            }

            using (NoteContext nc = new NoteContext())
            {
                nc.Note.Add(newNote);
                nc.SaveChanges();
                return Ok(newNote);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutSting(long id, [FromBody] Note updateNote)
        {
            if(updateNote == null)
            {
                return BadRequest("Note data is required.");
            }

            using (NoteContext nc = new NoteContext())
            {
                var note = nc.Note.FirstOrDefault(n => n.NoteId == id);

                if(note == null)
                {
                    return NotFound($"Note with ID {id} was not found.");
                }

                note.NoteTitle = updateNote.NoteTitle;
                note.NoteContent = updateNote.NoteContent;

                nc.SaveChanges();
                return Ok(note);
            }
        }
    }
}
