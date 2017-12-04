using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResidentCare.Models
{
    public class Note
    {

        public int NoteId { get; set; }
        public int ResidentId { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Text { get; set; }


//TODO
//	public DateTime DateCreated
//	public int CreatedByID
//	public DateTime DateLastUpdated
//	public int LastUpadtedByID

        public virtual Resident Resident { get; set; }
    }
}
