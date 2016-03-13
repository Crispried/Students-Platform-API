using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Students.Domain.Entities;
using Students.Domain.Abstract;
using System.Threading.Tasks;

namespace Students.Domain.Concrete
{
    public class EFGroupRepository : IGroupRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Group> Groups
        {
            get
            {
                return context.Groups;
            }
        }

        public void ChangeAdmin(Group groupId, int newAdminId)
        {
            Group dbEntry = context.Groups.Find(groupId);
            if (dbEntry != null)
            {
                dbEntry.AdminId = newAdminId;
                context.SaveChanges();
            }
        }

        public void DeleteGroup(int groupId)
        {
            User dbEntry = context.Users.Find(groupId);
            if (dbEntry != null)
            {
                context.Users.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        public void SaveGroup(Group group)
        {
            if (group.GroupId == 0)
            {
                context.Groups.Add(group);
            }
            else
            {
                Group dbEntry = context.Groups.Find(group.GroupId);
                if (dbEntry != null)
                {
                    dbEntry.Name = group.Name;
                    dbEntry.University = group.University;
                    dbEntry.Faculty = group.Faculty;
                    dbEntry.Course = group.Course;
                    dbEntry.Number = group.Number;
                    dbEntry.AdminId = group.AdminId;
                }
            }
            context.SaveChanges();
        }
    }
}
