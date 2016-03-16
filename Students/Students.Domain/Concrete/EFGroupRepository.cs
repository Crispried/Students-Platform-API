using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Students.Domain.Entities;
using Students.Domain.Abstract;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

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

        public bool ChangeAdmin(Group groupId, int newAdminId)
        {
            Group dbEntry = context.Groups.Find(groupId);
            if (dbEntry != null)
            {
                dbEntry.AdminId = newAdminId;
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public bool DeleteGroup(int groupId)
        {
            User dbEntry = context.Users.Find(groupId);
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

        public bool SaveGroup(Group group)
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
            if (ContextWasSaved())
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
                catch (DbUpdateException groupUpdateException)
                {
                    groupUpdateException = new DbUpdateException("Problems with group update.");
                    return false;
                }
                catch (DbEntityValidationException groupValidationException)
                {
                    groupValidationException = new DbEntityValidationException("Problems with group validation.");
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
