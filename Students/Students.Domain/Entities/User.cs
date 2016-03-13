using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [ForeignKey("Group")]
        public int? GroupId { get; set; }

        [Required]
        [MaxLength(30), MinLength(3)]
        [Index(IsUnique = true)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(30)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        [MaxLength(30), MinLength(6)]
        public string Password { get; set; }

        [StringLength(200)]
        public string Photo { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RegisterDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? LastVisit { get; set; }

        [Required]
        public UserRole Role { get; set; }

        [Required]
        public UserStatus Status { get; set; }

        [Range(-999999, 999999)]
        public int Rate { get; set; }

        [MaxLength(30), MinLength(3)]
        public string Country { get; set; }

        [MaxLength(30), MinLength(3)]
        public string City { get; set; }

        [MaxLength(40), MinLength(3)]
        public string Address { get; set; }

        [MaxLength(40), MinLength(3)]
        public string University { get; set; }

        [MaxLength(30), MinLength(3)]
        public string Faculty { get; set; }

        [Range(1, 6)]
        public int? Course { get; set; }

        [Range(1, 20)]
        public int? GroupNumber { get; set; }

        [Phone]
        public int? Phone { get; set; }

        [StringLength(1500)]
        public string About { get; set; }

        public virtual Group Group { get; set; }

        public virtual ICollection<PrivateMessage> PrivateMessages { get; set; }

        public virtual ICollection<HousingAnnouncment> HousingAnnouncments { get; set; }

        public virtual ICollection<TravelAnnouncment> TravelAnnouncments { get; set; }

        public virtual ICollection<MarketAnnouncment> MarketAnnouncments { get; set; }

        public virtual ICollection<ServiceAnnouncment> ServiceAnnouncments { get; set; }

        public virtual ICollection<HousingComment> HousingComments { get; set; } // housing announcments

        public virtual ICollection<TravelComment> TravelComments { get; set; } // travel announcments

        public virtual ICollection<MarketComment> MarketComments { get; set; } // market announcments

        public virtual ICollection<ServiceComment> ServiceComments { get; set; } // service announcments

        public User()
        {
            this.Rate = 0; // default value for user rate is 0
            this.RegisterDate = DateTime.Now; // default value for register date is the date when register

            this.PrivateMessages = new List<PrivateMessage>();

            this.HousingAnnouncments = new List<HousingAnnouncment>();
            this.TravelAnnouncments = new List<TravelAnnouncment>();
            this.MarketAnnouncments = new List<MarketAnnouncment>();
            this.ServiceAnnouncments = new List<ServiceAnnouncment>();

            this.HousingComments = new List<HousingComment>();
            this.TravelComments = new List<TravelComment>();
            this.MarketComments = new List<MarketComment>();
            this.ServiceComments = new List<ServiceComment>();
        }

        public enum UserRole
        {
            Admin,
            Moderator,
            User
        }

        public enum UserStatus
        {
            Normal,
            ReadOnly,
            Blocked
        }
    }
}
