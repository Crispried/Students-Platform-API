using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public abstract class Image
    {
        [Required]
        [StringLength(300)]
        public string Url { get; set; }
    }
}
