using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Abstract;
using Students.Domain.Entities;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

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

        public bool Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            User user = GetUserByUserName(username);
            return CheckPassword(user, password);
        }

        public bool ChangePassword(int userId, string newPassword, string oldPassword)
        {
            User dbEntry = context.Users.Find(userId);
            if (dbEntry != null)
            {
                if (CheckPassword(dbEntry, oldPassword))
                {
                    dbEntry.Password = newPassword;
                }
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public bool ChangeRate(int userId, RateAction rateAction)
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
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public bool ChangeRole(int userId, UserRole newUserRole)
        {
            User dbEntry = context.Users.Find(userId);
            if (dbEntry != null)
            {
                dbEntry.Role = newUserRole;
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public bool ChangeStatus(int userId, UserStatus newUserStatus)
        {
            User dbEntry = context.Users.Find(userId);
            if (dbEntry != null)
            {
                dbEntry.Status = newUserStatus;
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public bool DeleteUser(int userId)
        {
            User dbEntry = context.Users.Find(userId);
            if (dbEntry != null)
            {
                context.Users.Remove(dbEntry);
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public User GetUserById(int id)
        {
            User dbEntry = context.Users.Where(user => user.UserId == id).First();
            return dbEntry;
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

        public bool LeaveGroup(int userId)
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
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public bool SaveUser(User user)
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
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public bool SetLastVisit(int userId)
        {
            User dbEntry = context.Users.Find(userId);
            if (dbEntry != null)
            {
                dbEntry.LastVisit = DateTime.Now;
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        private static bool CheckPassword(User user, string oldPassword)
        {
            if(user.Password == oldPassword)
            {
                return true;
            }
            return false;
        }

        public bool ContextWasSaved()
        {
            if (EFDbContext.HasUnsavedChanges(context))
            {
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException userUpdateException)
                {
                    userUpdateException = new DbUpdateException("Problems with user update.");
                    return false;
                }
                catch (DbEntityValidationException userValidationException)
                {
                    userValidationException = new DbEntityValidationException("Problems with user validation.");
                    return false;
                }
                catch (ObjectDisposedException contextDisposedException)
                {
                    contextDisposedException = new ObjectDisposedException("Context was disposed.");
                    return false;
                }
            }
            return true;
        }
    }
}
