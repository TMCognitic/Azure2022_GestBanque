using Models;

namespace GestBanque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banque banque = new Banque("TFTIC Banking");
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Courant courant = new Courant("0000001", 200, doeJohn);
            Epargne epargne = new Epargne("0000002", doeJohn);

            banque.Ajouter(courant);
            banque.Ajouter(epargne);

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

            try
            {
                banque["0000002"].Retrait(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            banque["0000001"].AppliquerInteret();
            banque["0000002"].AppliquerInteret();

            Console.WriteLine($"Avoir des comptes de {doeJohn.Nom} {doeJohn.Prenom} : {banque.AvoirDesComptes(doeJohn)}");
        }
    }
}