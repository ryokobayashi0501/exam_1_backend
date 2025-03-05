using System.ComponentModel.DataAnnotations;

namespace exam_1_backend.Models
{
    public class Note
    {
        [Key]
        public long NoteId { get; set; }
        public String? NoteContent { get; set; }
        public String? NoteTitle { get; set; }
    }
}
