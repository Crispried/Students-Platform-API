using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Abstract;
using Students.Domain.Entities;

namespace Students.Domain.Concrete
{
    public class EFServiceAnnouncmentRepository : IServiceAnnouncmentRepository
    {
        public IQueryable<ServiceAnnouncment> ServiceAnnouncments
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void DeleteServiceAnnouncment(int serviceAnnouncmentId)
        {
            throw new NotImplementedException();
        }

        public void SaveServiceAnnouncment(ServiceAnnouncment serviceAnnouncment)
        {
            throw new NotImplementedException();
        }
    }
}
