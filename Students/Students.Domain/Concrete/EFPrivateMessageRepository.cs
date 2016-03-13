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
        public IQueryable<PrivateMessage> PrivateMessages
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void DeletePrivateMessage(int privateMessageId)
        {
            throw new NotImplementedException();
        }

        public void SavePrivateMessage(PrivateMessage privateMessage)
        {
            throw new NotImplementedException();
        }
    }
}
