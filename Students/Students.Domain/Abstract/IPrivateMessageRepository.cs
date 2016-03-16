using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Entities;

namespace Students.Domain.Abstract
{
    public interface IPrivateMessageRepository
    {
        /// <summary>
        /// get all private messages from database
        /// </summary>
        IQueryable<PrivateMessage> PrivateMessages { get; }

        /// <summary>
        /// saves private message in database
        /// </summary>
        /// <param name="privateMessage"></param>
        bool SavePrivateMessage(PrivateMessage privateMessage);

        /// <summary>
        /// deletes private message which id = privateMessageId from database
        /// </summary>
        /// <param name="privateMessageId"></param>
        bool DeletePrivateMessage(int privateMessageId);
    }
}
