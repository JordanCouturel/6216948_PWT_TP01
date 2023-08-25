using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using tp3JordanCoutureLafranchise.Models;

namespace tp2JordanCoutureLafranchise.Models
{
    public class Parent
    {
        [Key]
        public int ParentId { get; set; }

        [DisplayName("Nom")]
        [Required(ErrorMessage = "EnterName")]
        [StringLength(35, ErrorMessage = "stringLengthValidationNom")]
        public string Nom { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "EnterDescription")]
        [StringLength(250, ErrorMessage = "stringlengthvalidation")]
        public string Description { get; set; }

        [DisplayName("URL de l'image")]
        [Required(ErrorMessage = "EnterImageURL")]
        public string ImageURL { get; set; }


        [ValidateNever]
        //propriété de navigation
        public virtual List<Enfant>? Enfants { get; set; }

        //prop nav 1..1 DirecteurGeneral
        public virtual DirecteurGeneral DirecteurGeneral { get; set; }


    }
}
