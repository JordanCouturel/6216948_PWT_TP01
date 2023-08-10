namespace tp2JordanCoutureLafranchise.Models
{
    public class Enfant
    {
        public int Id { get; set; }

        public int IdParent { get; set; }

        public Parent? Parent { get; set; }

        public string ImageURL { get; set; }

        public string Nom { get; set; }

        public string Description { get; set; }

        public int NumeroDeChandail { get; set; }

        public string Age { get; set; }

        public string Position { get; set; }

        public int Salaire { get; set; }

        public string Equipe { get; set; }

        public string EnVedette { get; set; }

        public bool Favoris { get; set; }


    }
}
