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
                var User1 = new User() { UserName = "user1", Email = "tes1t@gmail.com", Password = "password1", Role = UserRole.User, Status = UserStatus.Normal, Photo = "Students/Images/User/BigBoobs.jpg" };
                var User2 = new User() { UserName = "user2", Email = "test2@gmail.com", Password = "password2", Role = UserRole.Admin, Status = UserStatus.Normal, Photo = "Students/Images/User/BigOiledAss.jpg" };
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

                #region housing announcment test data
                var bulletin1 = new HousingAnnouncment() { AuthorId = User1.UserId };

                var image1 = new HousingAnnouncmentImage() { Url = "Students/Images/HousingAnnouncment/image1.jpg" };

                var image2 = new HousingAnnouncmentImage() { Url = "Students/Images/HousingAnnouncment/image2.jpg" };

                var image3 = new HousingAnnouncmentImage() { Url = "Students/Images/HousingAnnouncment/image3.jpg" };

                var lang1 = new HousingAnnouncmentLang() { Title = "Русский", Bulletin = "Медведи на велосипеде", LanguageId = 2, HousingAnnouncmentId = 1 };

                var lang2 = new HousingAnnouncmentLang() { Title = "English", Bulletin = "Bears on cycle make me sasaikal", LanguageId = 1, HousingAnnouncmentId = 1 };

                var lang3 = new HousingAnnouncmentLang() { Title = "Українська", Bulletin = "Бурi ведмедики, а росiяни педики", LanguageId = 3, HousingAnnouncmentId = 1 };

                bulletin1.HousingAnnouncmentLangs.Add(lang1);
                bulletin1.HousingAnnouncmentLangs.Add(lang2);
                bulletin1.HousingAnnouncmentLangs.Add(lang3);
                bulletin1.HousingAnnouncmentImages.Add(image1);
                bulletin1.HousingAnnouncmentImages.Add(image2);
                bulletin1.HousingAnnouncmentImages.Add(image3);
                db.HousingAnnouncments.Add(bulletin1);

                var bulletin2 = new HousingAnnouncment() { AuthorId = User2.UserId };

                var image4 = new HousingAnnouncmentImage() { Url = "Students/Images/HousingAnnouncment/image4.jpg" };

                var image5 = new HousingAnnouncmentImage() { Url = "Students/Images/HousingAnnouncment/image5.jpg" };

                var image6 = new HousingAnnouncmentImage() { Url = "Students/Images/HousingAnnouncment/image6.jpg" };

                var lang4 = new HousingAnnouncmentLang() { Title = "Русский", Bulletin = "Ёжик - птица гордая: пока не пнёшь - не полетит.", LanguageId = 2, HousingAnnouncmentId = 2 };

                var lang5 = new HousingAnnouncmentLang() { Title = "English", Bulletin = "Imma boss ass bitch", LanguageId = 1, HousingAnnouncmentId = 2 };

                var lang6 = new HousingAnnouncmentLang() { Title = "Українська", Bulletin = "Хоп-хей хелулей, танцюй гопака, валяй дурака!", LanguageId = 3, HousingAnnouncmentId = 2 };

                bulletin1.HousingAnnouncmentLangs.Add(lang1);
                bulletin1.HousingAnnouncmentLangs.Add(lang2);
                bulletin1.HousingAnnouncmentLangs.Add(lang3);
                bulletin1.HousingAnnouncmentImages.Add(image1);
                bulletin1.HousingAnnouncmentImages.Add(image2);
                bulletin1.HousingAnnouncmentImages.Add(image3);
                db.HousingAnnouncments.Add(bulletin1);

                bulletin2.HousingAnnouncmentLangs.Add(lang4);
                bulletin2.HousingAnnouncmentLangs.Add(lang5);
                bulletin2.HousingAnnouncmentLangs.Add(lang6);
                bulletin2.HousingAnnouncmentImages.Add(image4);
                bulletin2.HousingAnnouncmentImages.Add(image5);
                bulletin2.HousingAnnouncmentImages.Add(image6);
                db.HousingAnnouncments.Add(bulletin2);

                db.SaveChanges();
                #endregion
                #region housing comment test data  
                var comment1 = new HousingComment() { AuthorId = User1.UserId, Body = "Куку, бестолочь.", HousingAnnouncmentId = 1 };
                var comment2 = new HousingComment() { AuthorId = User2.UserId, Body = "Опять ты??", HousingAnnouncmentId = 1 };
                var commentImage1 = new HousingCommentImage() { Url = "Students/Images/HousingComment/hello_motherfucker.jpg" };
                var comment3 = new HousingComment() { AuthorId = User1.UserId, Body = "Прекрати сам с собой разговаривать, наркоман.", HousingAnnouncmentId = 1 };
                comment2.HousingCommentImages.Add(commentImage1);
                db.HousingComments.Add(comment1);
                db.HousingComments.Add(comment2);
                db.HousingComments.Add(comment3);

                db.SaveChanges();
                #endregion
            }
        }
    }
}
