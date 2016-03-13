using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Abstract;
using Students.Domain.Entities;

namespace Students.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<User> Users
        {
            get
            {
                return context.Users;
            }
        }

        public void ChangePassword(int userId, string newPassword, string oldPassword)
        {
            User dbEntry = context.Users.Find(userId);
            if (dbEntry != null)
            {
                if (CheckPassword(dbEntry, oldPassword))
                {
                    dbEntry.Password = newPassword;
                }
                context.SaveChanges();

            }
        }

        public void ChangeRate(int userId, RateAction rateAction)
        {
            User dbEntry = context.Users.Find(userId);
            if (dbEntry != null)
            {
                switch (rateAction)
                {
                    case RateAction.Increase:
                        dbEntry.Rate++;
                        break;
                    case RateAction.Decrease:
                        dbEntry.Rate--;
                        break;
                }
                context.SaveChanges();
            }
        }

        public void ChangeRole(int userId, UserRole newUserRole)
        {
            User dbEntry = context.Users.Find(userId);
            if (dbEntry != null)
            {
                dbEntry.Role = newUserRole;
                context.SaveChanges();
            }
        }

        public void ChangeStatus(int userId, UserStatus newUserStatus)
        {
            User dbEntry = context.Users.Find(userId);
            if (dbEntry != null)
            {
                dbEntry.Status = newUserStatus;
                context.SaveChanges();
            }
        }

        public void DeleteUser(int userId)
        {
            User dbEntry = context.Users.Find(userId);
            if (dbEntry != null)
            {
                context.Users.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        public User GetUserByEmail(string email)
        {
            User dbEntry = context.Users.Where(user => user.Email == email).First();
            return dbEntry;
        }

        public User GetUserByUserName(string userName)
        {
            User dbEntry = context.Users.Where(user => user.UserName == userName).First();
            return dbEntry;
        }

        public void LeaveGroup(int userId)
        {
            User dbEntry = context.Users.Find(userId);
            if(dbEntry.GroupId != null)
            {
                Group userGroup = context.Groups.Where(group => group.GroupId == dbEntry.GroupId).First();
                if (userGroup.AdminId == dbEntry.UserId)
                {
                    foreach (User usr in userGroup.Users)
                    {
                        usr.GroupId = null;
                    }
                }
                else
                {
                    dbEntry.GroupId = null;
                }
            }
            context.SaveChanges();
        }

        public void SaveUser(User user)
        {
            if (user.UserId == 0)
            {
                context.Users.Add(user);
            }
            else
            {
                User dbEntry = context.Users.Find(user.UserId);
                if (dbEntry != null)
                {
                    dbEntry.UserName = user.UserName;
                    dbEntry.Password = user.Password;
                    dbEntry.Email = user.Email;
                    dbEntry.Address = user.Address;
                    dbEntry.Phone = user.Phone;
                    dbEntry.Photo = user.Photo;
                    dbEntry.About = user.About;
                    dbEntry.Country = user.Country;
                    dbEntry.City = user.City;
                    dbEntry.University = user.University;
                    dbEntry.Faculty = user.Faculty;
                    dbEntry.Course = user.Course;
                    dbEntry.Group = user.Group;
                    dbEntry.GroupId = user.GroupId;
                }
            }
            context.SaveChanges();
        }

        public void SetLastVisit(int userId)
        {
            User dbEntry = context.Users.Find(userId);
            if (dbEntry != null)
            {
                dbEntry.LastVisit = DateTime.Now;
                context.SaveChanges();
            }
        }

        private static bool CheckPassword(User user, string oldPassword)
        {
            if(user.Password == oldPassword)
            {
                return true;
            }
            return false;
        }
    }
}
