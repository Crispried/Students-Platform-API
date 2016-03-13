using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public abstract class Comment
    {
        [Required]
        [StringLength(1500)]
        public string Body { get; set; } // comment body 

        [DataType(DataType.DateTime)]
        public DateTime AddedTime { get; set; }

        public Comment()
        {
            this.AddedTime = DateTime.Now; // default value for added time is the time when comment was added
        }
    }
}
