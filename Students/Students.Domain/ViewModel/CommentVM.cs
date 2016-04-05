using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Entities;

namespace Students.Domain.ViewModel
{
    public class CommentVM
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public string Body { get; set; }

        public ICollection<ImageVM> CommentImagesVM { get; set; }

        public DateTime AddedDate { get; set; }

        public CommentVM()
        {
            this.CommentImagesVM = new List<ImageVM>();
        }
    }
}
