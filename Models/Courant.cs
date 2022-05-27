using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Courant
    {
        private string? _numero;
        private double _solde;
        private double _ligneDeCredit;
        private Personne? _titulaire;

        public string? Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

        public double Solde
        {
            get
            {
                return _solde;
            }

            private set
            {
                _solde = value;
            }
        }

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
                    //Todo : Déclencher une erreur (plus tard)
                    return;
                }

                _ligneDeCredit = value;
            }
        }

        public Personne? Titulaire
        {
            get
            {
                return _titulaire;
            }

            set
            {
                _titulaire = value;
            }
        }

        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                //Todo : Déclencher une erreur (plus tard)
                return;
            }

            _solde += montant;
        }

        public void Retrait(double montant)
        {

            if (montant <= 0)
            {
                //Todo : Déclencher une erreur (plus tard)
                return;
            }

            if(Solde - montant < -LigneDeCredit)
            {
                //Todo : Déclencher une erreur (plus tard)
                return;
            }

            _solde -= montant;            
        }
    }
}
