using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp2JordanCoutureLafranchise.Models
{
    public class Enfant
    {
        [Key]
        public int? Id { get; set; }


        [ForeignKey("Parent")]
        public int? ParentId { get; set; }


        //propriété de navigation
        public virtual Parent? Parent { get; set; }


        [Display(Name = "URL de l'image")]
        [Required(ErrorMessage = "Entrez un URL")]
        public string ImageURL { get; set; }


        [Required(ErrorMessage = "Entrez un nom")]
        [StringLength(30, ErrorMessage = "Le nom doit contenir moins de 30 caracteres")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Entrez une description")]
        [StringLength(299, ErrorMessage = "La description doit contenir moins de 300 caracteres")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Entrez un numéro de chandail")]
        [Range(0, 99, ErrorMessage = "Entrez un numéro de chandail entre 1 et 100")]
        public int NumeroDeChandail { get; set; }


        [Required(ErrorMessage = "Entrez un age")]
        public string Age { get; set; }


        [Required(ErrorMessage = "Choissisez une position")]
        public string Position { get; set; }


        [Required(ErrorMessage = "Entrez un salaire en M$/Année")]
        public int Salaire { get; set; }

        [ValidateNever]
        [Required(ErrorMessage = "Choissisez une équipe")]
        public string Equipe { get; set; }


        [Required(ErrorMessage = "Indiquez si le joueur est en vedette ou non")]
        public string EnVedette { get; set; }


        [Required(ErrorMessage = "Indiquez si le joueur est dans les favoris")]
        public bool Favoris { get; set; }


    }
}
