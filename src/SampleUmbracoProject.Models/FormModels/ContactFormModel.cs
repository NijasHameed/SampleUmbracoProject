using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUmbracoProject.Models.FormModels
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Please select a title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your message")]
        [StringLength(1000, ErrorMessage = "Message cannot be longer than 1000 characters")]
        public string Message { get; set; }
    }
}
