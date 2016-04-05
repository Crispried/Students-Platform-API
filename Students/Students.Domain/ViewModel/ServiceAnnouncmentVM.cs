using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.ViewModel
{
    public class ServiceAnnouncmentVM
    {
        public int Id { get; set; }

        public UserAnnouncmentVM Author { get; set; }

        public DateTime AddedDate { get; set; }

        public ICollection<ImageVM> ServiceAnnouncmentImagesVM { get; set; }

        public ICollection<ServiceAnnouncmentLangVM> ServiceAnnouncmentLangsVM { get; set; }

        public ServiceAnnouncmentVM()
        {
            this.ServiceAnnouncmentLangsVM = new List<ServiceAnnouncmentLangVM>();
            this.ServiceAnnouncmentImagesVM = new List<ImageVM>();
        }
    }
}
