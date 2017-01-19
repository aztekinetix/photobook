using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoBook.Entities
{
    public class State
    {
        public int StateId { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
       
    }
}