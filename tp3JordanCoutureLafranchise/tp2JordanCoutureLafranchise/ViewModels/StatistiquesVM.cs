using tp2JordanCoutureLafranchise.Models;
using tp3JordanCoutureLafranchise.Models;

namespace tp3JordanCoutureLafranchise.ViewModels
{
    public class StatistiquesVM
    {
        public Entraineur entraineur { get; set; }

        public int? NbJoueurs { get; set; }

        public Enfant Joueur { get; set; }

        public int? NbEntraineurs { get; set; }

    }  
}
