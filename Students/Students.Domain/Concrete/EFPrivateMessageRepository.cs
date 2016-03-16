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

        public bool DeletePrivateMessage(int privateMessageId)
        {
            PrivateMessage dbEntry = context.PrivateMessages.Find(privateMessageId);
            if (dbEntry != null)
            {
                context.PrivateMessages.Remove(dbEntry);
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public bool SavePrivateMessage(PrivateMessage privateMessage)
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
                catch (DbUpdateException privateMessageUpdateException)
                {
                    privateMessageUpdateException = new DbUpdateException("Problems with private message update.");
                    return false;
                }
                catch (DbEntityValidationException privateMessageValidationException)
                {
                    privateMessageValidationException = new DbEntityValidationException("Problems with private message validation.");
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
