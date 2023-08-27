using System.ComponentModel.DataAnnotations;
using tp2JordanCoutureLafranchise.Models;

namespace tp3JordanCoutureLafranchise.Models
{
    public class Entraineur
    {
        [Key]
        public int Id { get; set; }

        public string NomComplet { get; set; }

        public string Specialite { get; set; }

        //prop nav
        public virtual ICollection<Enfant> Joueurs { get; set; }
    }
}
