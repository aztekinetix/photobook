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
        [Display(Name="Personal ID number")]
        public  string IdNumber { get; set; }
        public  string IdImageUrl { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public  string Telephone { get; set; }
        [Required]
        public  string Email { get; set; }
        [Display(Name = "Twitter")]
        public string TwitterAccount { get; set; }
        [Display(Name = "Facebook")]
        public string Facebook { get; set; }
        [Display(Name = "Profile Image Url")]
        public string ProfileImageUrl { get; set; }
        [Display(Name = "Price per hour of service")]
        public decimal PricePerService { get; set; }
        [Display(Name = "Description of the service")]
        public string DescriptionService { get; set; } //this is where people will add their texts
        public bool IsActive { get; set; }
        [Display(Name = "State")]
        public int? StateId { get; set; }
        [Display(Name = "Country")]
        public int? CountryId { get; set; }

        public ICollection<PublisherPic> PublisherPics { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
    }
}