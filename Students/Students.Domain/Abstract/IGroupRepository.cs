using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Entities;

namespace Students.Domain.Abstract
{
    public interface IGroupRepository
    {
        /// <summary>
        /// gets all groups from database
        /// </summary>
        IQueryable<Group> Groups { get; }

        /// <summary>
        /// saves group in database
        /// </summary>
        /// <param name="group"></param>
        void SaveGroup(Group group);

        /// <summary>
        /// deletes group which id = groupId from database
        /// </summary>
        /// <param name="group"></param>
        void DeleteGroup(int groupId);

        /// <summary>
        /// changes admin of the group
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="newAdminId"></param>
        void ChangeAdmin(Group groupId, int newAdminId);
    }
}
