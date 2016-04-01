using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Students.Domain.Entities;
using System.Threading.Tasks;
using Students.Domain.ViewModel;

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
        /// <returns></returns>
        bool SaveHousingAnnouncment(HousingAnnouncment housingAnnouncment);

        /// <summary>
        /// deletes housing announcment which id = housingAnnouncmentId from database
        /// </summary>
        /// <param name="housingAnnouncmentId"></param>
        bool DeleteHousingAnnouncment(int housingAnnouncmentId);
    }
}
