using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniCms.Web.Models.Entities
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Navn mangler")]
        [Display(Name = "Navn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email mangler")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Webside")]
        public string Website { get; set; }

        [Display(Name = "Adresse")]
        public Address Address { get; set; }

        [Required(ErrorMessage = "Telefon mangler")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Display(Name = "Faks")]
        public string Fax { get; set; }
    }
}