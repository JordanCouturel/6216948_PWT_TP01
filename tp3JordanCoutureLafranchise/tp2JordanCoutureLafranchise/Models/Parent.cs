namespace tp2JordanCoutureLafranchise.Models
{
    public class Parent
    {

        public int Id { get; set; }

        public List<Enfant> Enfants { get; set; }

        public string Nom { get; set; }

        public int NbJoueurs { get; set; }

        public int SalaireMoyen { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }
    }
}
