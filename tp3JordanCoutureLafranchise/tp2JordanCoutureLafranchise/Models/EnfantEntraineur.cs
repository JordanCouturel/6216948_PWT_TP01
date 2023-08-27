using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tp2JordanCoutureLafranchise.Models;

namespace tp3JordanCoutureLafranchise.Models
{
    public class EnfantEntraineur
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Enfant")]
        public int EnfantId { get; set; }

        [ForeignKey("Entraineur")]
        public int EntraineurId { get; set; }

        // Navigation properties
        public virtual Enfant Enfant { get; set; }
        public virtual Entraineur Entraineur { get; set; }
    }
}