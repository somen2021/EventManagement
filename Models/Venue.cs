﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Models
{
    public class Venue
    {
        [Key]
        public int VenueID { get; set; }

        [Required(ErrorMessage = "VenueName Required")]
        public string VenueName { get; set; }

        [Required(ErrorMessage = "VenueCost Required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enter only numeric number")]
        public int? VenueCost { get; set; }

        public string Createdby { get; set; }

        public DateTime? Createdate { get; set; }
    }
}
