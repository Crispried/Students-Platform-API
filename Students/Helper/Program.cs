using System;
using System.Collections.Generic;
using System.Data.Entity;
using Students.Domain.Entities;
using Students.Domain.Concrete;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Announcment> test = new List<Announcment>();
            var obj1 = new TravelAnnouncment();
            test.Add(obj1);
            using (var db = new EFDbContext())
            {
                var User1 = new User() { UserName = "user1", Email = "tes1t@gmail.com", Password = "password1", Role = UserRole.User, Status = UserStatus.Normal };
                var User2 = new User() { UserName = "user2", Email = "test2@gmail.com", Password = "password2", Role = UserRole.Admin, Status = UserStatus.Normal };
                db.Users.Add(User1);
                db.Users.Add(User2);
                db.SaveChanges();

                var Group1 = new Group() { Name = "group1" };
                Group1.AdminId = User1.UserId;
                Group1.Users.Add(User1);
                Group1.Users.Add(User2);
                db.Groups.Add(Group1);
                db.SaveChanges();

                var PM1 = new PrivateMessage() { Title = "Test", Message = "I am testing you", AuthorId = User1.UserId, RecieverId = User2.UserId };
                db.PrivateMessages.Add(PM1);
                db.SaveChanges();

                var bulletin1 = new MarketAnnouncment() { AuthorId = User1.UserId, Title = "title1", Bulletin = "Announcment1" };
                var bulletin2 = new ServiceAnnouncment() { AuthorId = User1.UserId, Title = "title2", Bulletin = "Announcment2" };
                var bulletin3 = new TravelAnnouncment() { AuthorId = User1.UserId, Title = "title3", Bulletin = "Announcment3" };
                var bulletin4 = new HousingAnnouncment() { AuthorId = User1.UserId, Title = "title4", Bulletin = "Announcment4" };

                db.MarketAnnouncments.Add(bulletin1);
                db.ServiceAnnouncments.Add(bulletin2);
                db.TravelAnnouncments.Add(bulletin3);
                db.HousingAnnouncments.Add(bulletin4);
                db.SaveChanges();
            }
        }
    }
}
