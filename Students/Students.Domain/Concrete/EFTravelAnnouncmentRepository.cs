using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Abstract;
using Students.Domain.Entities;

namespace Students.Domain.Concrete
{
    public class EFTravelAnnouncmentRepository : ITravelAnnouncmentRepository
    {
        public IQueryable<TravelAnnouncment> TravelAnnouncments
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void DeleteTravelAnnouncment(int travelAnnouncmentId)
        {
            throw new NotImplementedException();
        }

        public void SaveTravelAnnouncment(TravelAnnouncment travelAnnouncment)
        {
            throw new NotImplementedException();
        }
    }
}
