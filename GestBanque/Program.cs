using Models;

namespace GestBanque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Personne doeJohn = new Personne()
            {
                Nom = "Doe",
                Prenom = "John",
                DateNaiss = new DateTime(1970,1,1)
            };

            Courant courant = new Courant()
            {
                Numero = "0000001",
                LigneDeCredit = 200,
                Titulaire = doeJohn
            };

            courant.Depot(-500);
            Console.WriteLine(courant.Solde);

            courant.Depot(500);
            Console.WriteLine(courant.Solde);

            courant.Retrait(-500);
            Console.WriteLine(courant.Solde);

            courant.Retrait(500);
            Console.WriteLine(courant.Solde);

            courant.Retrait(500);
            Console.WriteLine(courant.Solde);
        }
    }
}