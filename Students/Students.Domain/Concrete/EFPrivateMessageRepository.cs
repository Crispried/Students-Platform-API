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

                    List<PrivateMessageImage> oldPrivateMessageImages = dbEntry.PrivateMessageImages.ToList();
                    List<PrivateMessageImage> updatedPrivateMessageImages = new List<PrivateMessageImage>();
                    List<PrivateMessageImage> newPrivateMessageImages = privateMessage.PrivateMessageImages.ToList();
                    foreach (var oldPrivateMessageImage in oldPrivateMessageImages)
                    {
                        if (newPrivateMessageImages.Any(npmi => npmi.PrivateMessageImageId == oldPrivateMessageImage.PrivateMessageImageId))
                        {
                            updatedPrivateMessageImages.Add(oldPrivateMessageImage);
                        }
                        else
                        {
                            context.PrivateMessageImages.Remove(oldPrivateMessageImage);
                        }
                    }
                    for (int i = 0; i < updatedPrivateMessageImages.Count; i++)
                    {
                        if (newPrivateMessageImages[i].PrivateMessageImageId == updatedPrivateMessageImages[i].PrivateMessageImageId)
                        {
                            updatedPrivateMessageImages[i] = newPrivateMessageImages[i];
                            newPrivateMessageImages.Remove(newPrivateMessageImages[i]);
                        }
                    }
                    foreach (var newPrivateMessageImage in newPrivateMessageImages)
                    {
                        dbEntry.PrivateMessageImages.Add(newPrivateMessageImage);
                    }
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
