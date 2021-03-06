﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public enum CommentType
    {
        Housing,
        Market,
        Travel,
        Service
    }
    public abstract class Comment
    {
        [Required]
        [StringLength(1500)]
        public string Body { get; set; } // comment body 

        [DataType(DataType.DateTime)]
        public DateTime AddedDate { get; set; }

        public Comment()
        {
            this.AddedDate = DateTime.Now; // default value for added time is the time when comment was added
        }
    }
}
