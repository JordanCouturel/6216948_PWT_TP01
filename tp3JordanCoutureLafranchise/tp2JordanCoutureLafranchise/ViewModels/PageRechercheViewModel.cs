using tp2JordanCoutureLafranchise.Models;

namespace tp2JordanCoutureLafranchise.ViewModels
{
    public class PageRechercheViewModel
    {
        public CritereRechercheViewModel? Criteres { get; set; }

        public List<Enfant> Resultat { get; set; }

    }
}
