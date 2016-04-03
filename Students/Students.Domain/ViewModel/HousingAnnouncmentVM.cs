﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.ViewModel
{
    public class HousingAnnouncmentVM
    {
        public int Id { get; set; }

        //public int AuthorId { get; set; }

        public DateTime AddedDate { get; set; }

        public UserVM Author { get; set; }

        public ICollection<HousingAnnouncmentLangVM> HousingAnnouncmentLangsVM { get; set; }

        public HousingAnnouncmentVM()
        {
            this.HousingAnnouncmentLangsVM = new List<HousingAnnouncmentLangVM>();
        }
    }
}
