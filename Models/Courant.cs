using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Courant : Compte
    {
        private double _ligneDeCredit;

        public double LigneDeCredit
        {
            get
            {
                return _ligneDeCredit;
            }

            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException();
                }

                _ligneDeCredit = value;
            }
        }

        public Courant(string numero, Personne titulaire) : base(numero, titulaire)
        {
        }

        public Courant(string numero, Personne titulaire, double solde) : base(numero, titulaire, solde)
        {
        }

        public Courant(string numero, double ligneDeCredit, Personne titulaire) : base(numero, titulaire)
        {
            LigneDeCredit = ligneDeCredit;
        }

        public override void Retrait(double montant)
        {
            double oldSolde = Solde;

            Retrait(montant, LigneDeCredit);

            if(Solde < 0 && oldSolde >= 0)
            {
                Notify();
            }
        }

        protected override double CalculInteret()
        {
            return Solde * (Solde > 0 ? .03 : .0975);
        }
    }
}
