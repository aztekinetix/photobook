using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoBook.Entities
{
   public class PublisherPic
    {
        public int PublisherPicId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? UploadedOn { get; set; }
        public string UploadedByUserId { get; set; }
        public int Order { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
