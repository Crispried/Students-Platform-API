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
                
                var LANGUAGE1 = new Language() { Code = LanguageCode.eng, Name = "English" };

                var LANGUAGE2 = new Language() { Code = LanguageCode.rus, Name = "Russian" };

                var LANGUAGE3 = new Language() { Code = LanguageCode.ukr, Name = "Ukrainian" };

                db.Languages.Add(LANGUAGE1);

                db.Languages.Add(LANGUAGE2);

                db.Languages.Add(LANGUAGE3);

                db.SaveChanges();

                var bulletin1 = new HousingAnnouncment() { AuthorId = User1.UserId };

                var lang1 = new HousingAnnouncmentLang() { Title = "Русский", Bulletin = "Медведи на велосипеде", LanguageId = 2, HousingAnnouncmentId = 1 };

                var lang2 = new HousingAnnouncmentLang() { Title = "English", Bulletin = "Bears on cycle make me sasaikal", LanguageId = 1, HousingAnnouncmentId = 1 };

                var lang3 = new HousingAnnouncmentLang() { Title = "Українська", Bulletin = "Бурi ведмедики, а росiяни педики", LanguageId = 3, HousingAnnouncmentId = 1 };

                bulletin1.HousingAnnouncmentLangs.Add(lang1);
                bulletin1.HousingAnnouncmentLangs.Add(lang2);
                bulletin1.HousingAnnouncmentLangs.Add(lang3);
                db.HousingAnnouncments.Add(bulletin1);

                db.SaveChanges();               
            }
        }
    }
}
