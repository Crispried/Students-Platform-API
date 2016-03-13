using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Entities;
using Students.Domain.Abstract;

namespace Students.Domain.Concrete
{
    public class EFHousingAnnouncmentRepository : IHousingAnnouncmentRepository
    {
        public IQueryable<HousingAnnouncment> HousingAnnouncments
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void DeleteHousingAnnouncment(int housingAnnouncmentId)
        {
            throw new NotImplementedException();
        }

        public void SaveTravelAnnouncment(HousingAnnouncment housingAnnouncment)
        {
            throw new NotImplementedException();
        }
    }
}
