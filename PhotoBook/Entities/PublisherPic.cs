using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoBook.Entities
{
   public class PublisherPic
    {
        public int PublisherPicId { get; set; }
        public int PublisherId { get; set; }
        //[StringLength(50)]
        //[Index("IX_PublisherPic_ImageUrl",IsUnique=true)]
        public string ImageUrl { get; set; }
        public DateTime? UploadedOn { get; set; }
        public string UploadedByUserId { get; set; }
        public int Order { get; set; }
        
        public Publisher Publisher { get; set; }
    }
}
