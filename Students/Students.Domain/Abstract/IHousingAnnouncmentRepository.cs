using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Students.Domain.Entities;
using System.Threading.Tasks;

namespace Students.Domain.Abstract
{
    public interface IHousingAnnouncmentRepository
    {
        /// <summary>
        /// get all housing announcments from database
        /// </summary>
        IQueryable<HousingAnnouncment> HousingAnnouncments { get; }

        /// <summary>
        /// saves housing announcment in database
        /// </summary>
        /// <param name="housingAnnouncment"></param>
        void SaveTravelAnnouncment(HousingAnnouncment housingAnnouncment);

        /// <summary>
        /// deletes housing announcment which id = housingAnnouncmentId from database
        /// </summary>
        /// <param name="housingAnnouncmentId"></param>
        void DeleteHousingAnnouncment(int housingAnnouncmentId);
    }
}
