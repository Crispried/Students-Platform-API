using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Students.Domain.Entities;
using System.Threading.Tasks;

namespace Students.Domain.Abstract
{
    public interface IServiceAnnouncmentRepository
    {
        /// <summary>
        /// get all service announcments from database
        /// </summary>
        IQueryable<ServiceAnnouncment> ServiceAnnouncments { get; }

        /// <summary>
        /// saves service announcment in database
        /// </summary>
        /// <param name="serviceAnnouncment"></param>
        void SaveServiceAnnouncment(ServiceAnnouncment serviceAnnouncment);

        /// <summary>
        /// deletes service announcment which id = serviceAnnouncmentId from database
        /// </summary>
        /// <param name="serviceAnnouncmentId"></param>
        void DeleteServiceAnnouncment(int serviceAnnouncmentId);
    }
}
