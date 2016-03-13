using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required] // every group must to have creator
                   // it is the refference on the UserId which created the group
        [Index(IsUnique = true)] // the same user can't be admin (create) of many groups
        public int AdminId { get; set; }  

        [MaxLength(20), MinLength(3)]
        public string Name { get; set; }

        [MaxLength(40), MinLength(3)]
        public string University { get; set; }

        [MaxLength(30), MinLength(3)]
        public string Faculty { get; set; }

        [Range(1, 6)]
        public int? Course { get; set; }

        [Range(1, 20)]
        public int? Number { get; set; } // number of the group

        public virtual ICollection<User> Users { get; set; }

        public Group()
        {
            this.Users = new List<User>();
        }
    }
}
