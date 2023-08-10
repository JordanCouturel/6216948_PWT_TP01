using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp2JordanCoutureLafranchise.Models
{
    public class Parent
    {
        [Key]
        public int ParentId { get; set; }


        [Required(ErrorMessage = "Entrez un nom")]
        [StringLength(35, ErrorMessage = "Le nom doit contenir moins de 36 caracteres")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Entrez une description")]
        [StringLength(250, ErrorMessage = "La description doit contenir moins de 251 caracteres")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Entrez un URL d'image")]
        public string ImageURL { get; set; }


        [ValidateNever]
        //propriété de navigation
        public virtual List<Enfant>? Enfants { get; set; }

    }
}
