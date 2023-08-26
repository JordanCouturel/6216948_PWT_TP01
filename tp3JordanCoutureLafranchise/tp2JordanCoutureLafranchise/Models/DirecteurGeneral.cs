using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tp2JordanCoutureLafranchise.Models;

namespace tp3JordanCoutureLafranchise.Models
{
    public class DirecteurGeneral
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }


        public string Prénom { get; set; }


        //prop nav
        [ForeignKey("Parent")]
        public int EquipeID { get; set; }

        public virtual Parent? Equipe { get; set; }

    }
}
