using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Entities;

namespace Students.Domain.Abstract
{
    public interface IMarketAnnouncmentRepository
    {
        /// <summary>
        /// get all market announcments from database
        /// </summary>
        IQueryable<MarketAnnouncment> MarketAnnouncments { get; }

        /// <summary>
        /// saves market announcment in database
        /// </summary>
        /// <param name="marketAnnouncment"></param>
        /// <returns></returns>
        bool SaveMarketAnnouncment(MarketAnnouncment marketAnnouncment);

        /// <summary>
        /// deletes market announcment which id = marketAnnouncmentId from database
        /// </summary>
        /// <param name="marketAnnouncmentId"></param>
        bool DeleteMarketAnnouncment(int marketAnnouncmentId);

        /// <summary>
        /// get announcment by id
        /// </summary>
        /// <param name="announcmentId"></param>
        /// <returns></returns>
        MarketAnnouncment GetAnnouncmentById(int announcmentId);
    }
}
