using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhotoBook.Domain.Entities
{
    class Publisher
    {
        
        public  int PublisherId { get; set; }
        [Required]
        public  string Name { get; set; }
        [Required]
        public  string IdNumber { get; set; }
        public  string IdImageUrl { get; set; }
        [Required]
        public string Address { get; set; }
        public  int StateId { get; set; }
        [Required]
        public  string Telephone { get; set; }
        [Required]
        public  string Email { get; set; }
        public string ProfileImageUrl { get; set; }

        public ICollection<ImageGallery> ImagesGallery { get; set; }



    }
}