using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhotoBook.Entities
{
    public class Publisher
    {
        
        public  int PublisherId { get; set; }
        [Required]
        public  string Name { get; set; }
        [Required]
        public  string IdNumber { get; set; }
        public  string IdImageUrl { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public  string Telephone { get; set; }
        [Required]
        public  string Email { get; set; }
        public string TwitterAccount { get; set; }
        public string Facebook { get; set; }
        public string ProfileImageUrl { get; set; }
        public decimal PricePerService { get; set; }
        public string DescriptionService { get; set; } //this is where people will add their texts
        public bool IsActive { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }

        public ICollection<PublisherPic> PublisherPics { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
    }
}