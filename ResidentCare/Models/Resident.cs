using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ResidentCare.Models
{
    public class Resident
    {
        public int ResidentId { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [DisplayName("Medical Requirements")]
        [MaxLength(5000)]
        public string MedicalRequirements { get; set; }

        [MaxLength(5000)]
        public string Allergies { get; set; }

        public virtual ICollection<Note> Notes { get; set; }


    }

    public enum Title
    {
        Mr,
        Miss,
        Ms,
        Mrs
    }

}
