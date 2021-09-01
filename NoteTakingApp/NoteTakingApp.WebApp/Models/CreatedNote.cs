using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NoteTakingApp.Domain;

namespace NoteTakingApp.WebApp.Models
{
    public class CreatedNote //: IValidatableObject
    {
        [Required]
        [MinLength(3)]
        public string Text { get; set; }

        public List<string> Tags { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    //var repo = validationContext.GetService(typeof(IRepository));
        //    //repo.
        //}

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
