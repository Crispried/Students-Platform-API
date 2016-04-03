using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public abstract class Announcment
    {
        [Required]
        [MaxLength(30), MinLength(4)]
        public string Title { get; set; }

        [Required]
        [StringLength(1500)]
        public string Bulletin { get; set; } // announcment(bulletin) body 
    }
}
