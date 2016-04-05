using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class PrivateMessage
    {
        [Key]
        public int PrivateMessageId { get; set; }

        [Required]
        public int RecieverId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int AuthorId { get; set; }

        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1500)]
        public string Message { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime SendTime { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<PrivateMessageImage> PrivateMessageImages { get; set; }

        public PrivateMessage()
        {
            this.SendTime = DateTime.Now; // default value for send time is the time when message was sent
            this.PrivateMessageImages = new List<PrivateMessageImage>();
        }

    }
}
