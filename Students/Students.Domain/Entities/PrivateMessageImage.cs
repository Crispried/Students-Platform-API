using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class PrivateMessageImage : Image
    {
        [Key]
        public int PrivateMessageImageId { get; set; }

        [Required]
        [ForeignKey("PrivateMessage")]
        public int PrivateMessageId { get; set; }

        public virtual PrivateMessage PrivateMessage { get; set; }

        public PrivateMessageImage() : base() { }
    }
}
