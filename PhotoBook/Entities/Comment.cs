using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoBook.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        [Display(Name ="Comment")]
        public string Text { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedByUserName { get; set; }
        public int? ReplyToCommentId { get; set; } // if this is not null indeed it is a reply
        public int PublisherId { get; set; }  // foreign key to know the comments belong to a specific portfolio.
        
    }

    
}