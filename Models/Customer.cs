using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly3.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "please enter your name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewLetter { get; set; }

        
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Min18YearsifAMember]
        [Display(Name = "Date of Birth")]
        public DateTime? Birthday { get; set; }
         
    }
}