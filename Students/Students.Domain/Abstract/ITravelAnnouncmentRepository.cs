using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Entities;

namespace Students.Domain.Abstract
{
    public interface ITravelAnnouncmentRepository
    {
        /// <summary>
        /// get all travel announcments from database
        /// </summary>
        IQueryable<TravelAnnouncment> TravelAnnouncments { get; }

        /// <summary>
        /// saves travel announcment in database
        /// </summary>
        /// <param name="travelAnnouncment"></param>
        void SaveTravelAnnouncment(TravelAnnouncment travelAnnouncment);

        /// <summary>
        /// deletes travel announcment which id = travelAnnouncmentId from database
        /// </summary>
        /// <param name="travelAnnouncmentId"></param>
        void DeleteTravelAnnouncment(int travelAnnouncmentId);
    }
}
