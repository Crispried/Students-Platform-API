﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public class ServiceAnnouncment : Announcment
    {
        [Key]
        public int ServiceAnnouncmentId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int AuthorId { get; set; } // announcment owner

        public virtual User User { get; set; }

        public virtual ICollection<ServiceComment> ServiceComments { get; set; }

        public ServiceAnnouncment()
        {
            this.ServiceComments = new List<ServiceComment>();
        }
    }
}
