using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelNest.Models.Models
{
    public class ApplicationUser : IdentityUser
    {

        //provides more attributes to the default user
        [Required]
        public string Name { get; set; }

        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]  //companyId is the navigation property for the company 
        [ValidateNever]
        public Company? Company { get; set; }
        [NotMapped]
        public string Role { get; set; }

    }
}
