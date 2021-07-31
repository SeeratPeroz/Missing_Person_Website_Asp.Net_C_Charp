using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Missing_Person.Models.Entity
{
    public class MissingPerson
    {
        [Display(Name = "Person ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int personID { get; set; }

        
        [Display(Name = "Person Name")]
        [Required(ErrorMessage = "Person name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Person Last is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Father Name")]
        public String FatherName { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }

        [Display(Name = "Nationality")]
        public String Nation { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender name is required")]
        public String Gender { get; set; }
        [Display(Name = "Date of Brith")]
        public DateTime DOB { get; set; }

        [Display(Name = "Missing Place")]
        public String MissingPlace { get; set; }

        [Display(Name = "Missing Date")]
        public DateTime MissingFrom { get; set; }

        [Display(Name = "Person Image")]
        //[Required(ErrorMessage = "Person Image is required")]
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "Contact Email")]
        //[Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Display(Name = "Contact Phone")]
        
        //[Required(ErrorMessage = "Contact number is required.")]
        public string Phone { get; set; }


        public string userID { get; set; }
        
    }
}