using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Entities;

namespace Students.Domain.ViewModel
{
    public class UserVM
    {
        public int Id { get; set; }

        public int? GroupId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Photo { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime? LastVisit { get; set; }

        public UserRole Role { get; set; }

        public UserStatus Status { get; set; }

        public int Rate { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string University { get; set; }

        public string Faculty { get; set; }

        public int? Course { get; set; }

        public int? GroupNumber { get; set; }

        public int? Phone { get; set; }

        public string About { get; set; }
    }
}
