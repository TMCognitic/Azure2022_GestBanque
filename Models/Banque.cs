using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Banque
    {
        private Dictionary<string, Compte> _comptes = new Dictionary<string, Compte>();
        public string Nom { get; private set; }        

        public Compte this[string numero]
        {
            get { return _comptes.ContainsKey(numero) ? _comptes[numero] : null; }
        }

        public int Count
        {
            get { return _comptes.Count; }
        }

        public Banque(string nom)
        {
            Nom = nom;
        }

        public void Ajouter(Compte compte)
        {
            compte.PassageEnNegatifEvent += PassageEnNegatifAction;
            _comptes.Add(compte.Numero, compte);
        }

        public bool Supprimer(string numero)
        {
            if(_comptes.TryGetValue(numero, out Compte compte))
            {
                compte.PassageEnNegatifEvent -= PassageEnNegatifAction;
                return true;
            }

            return false;
        }

        private void PassageEnNegatifAction(Compte compte)
        {
            Console.WriteLine($"Le compte {compte.Numero} vient de passer en négatif!");
        }        

        public double AvoirDesComptes(Personne personne)
        {
            double total = 0D;

            foreach (Compte item in _comptes.Values)
            {
                if (item.Titulaire == personne)
                    total += item; //double = double + Courant 
            }

            return total;
        }
    }
}
