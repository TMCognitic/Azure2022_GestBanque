using Models;

namespace GestBanque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banque banque = new Banque() { Nom = "TFTIC Banking" };

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

            Courant courant2 = new Courant()
            {
                Numero = "0000002",
                LigneDeCredit = 200,
                Titulaire = doeJohn
            };

            banque.Ajouter(courant);
            banque.Ajouter(courant2);

            //courant.Depot(-500);
            //Console.WriteLine(courant.Solde);

            banque["0000001"].Depot(500);
            Console.WriteLine($"Solde du compte '{banque["0000001"].Numero}' : {banque["0000001"].Solde}");

            //courant.Retrait(-500);
            //Console.WriteLine(courant.Solde);

            banque["0000001"].Retrait(400);
            Console.WriteLine($"Solde du compte '{banque["0000001"].Numero}' : {banque["0000001"].Solde}");


            //banque["0000001"].Retrait(200);
            //Console.WriteLine($"Solde du compte '{banque["0000001"].Numero}' : {banque["0000001"].Solde}");


            banque["0000002"].Depot(1000);
            Console.WriteLine($"Solde du compte '{banque["0000002"].Numero}' : {banque["0000002"].Solde}");

            Console.WriteLine($"Avoir des comptes de {doeJohn.Nom} {doeJohn.Prenom} : {banque.AvoirDesComptes(doeJohn)}");
        }
    }
}