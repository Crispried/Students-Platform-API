using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Abstract;
using Students.Domain.Entities;

namespace Students.Domain.Concrete
{
    public class EFPrivateMessageRepository : IPrivateMessageRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<PrivateMessage> PrivateMessages
        {
            get
            {
                return context.PrivateMessages;
            }
        }

        public void DeletePrivateMessage(int privateMessageId)
        {
            PrivateMessage dbEntry = context.PrivateMessages.Find(privateMessageId);
            if (dbEntry != null)
            {
                context.PrivateMessages.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        public void SavePrivateMessage(PrivateMessage privateMessage)
        {
            if (privateMessage.PrivateMessageId == 0)
            {
                context.PrivateMessages.Add(privateMessage);
            }
            else
            {
                PrivateMessage dbEntry = context.PrivateMessages.Find(privateMessage.PrivateMessageId);
                if (dbEntry != null)
                {
                    dbEntry.Title = privateMessage.Title;
                    dbEntry.Message = privateMessage.Message;
                    dbEntry.AuthorId = privateMessage.AuthorId;
                    dbEntry.RecieverId = privateMessage.RecieverId;
                }
            }
            context.SaveChanges();
        }
    }
}
