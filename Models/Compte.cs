namespace Models
{
    public abstract class Compte : ICustomer, IBanker
    {
        //double = double + Courant
        public static double operator +(double d, Compte compte)
        {
            return (d < 0 ? 0 : d) + (compte.Solde < 0 ? 0 : compte.Solde);
        }

        private string _numero;
        private double _solde;
        private Personne _titulaire;

        public string Numero
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

        public Personne Titulaire
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

        public virtual void Retrait(double montant)
        {
            Retrait(montant, 0D);
        }

        //Seules les classes héritant de la classe Compte et présente dans le même assembly (projet)
        //pourront appeler cette méthode (private protected)
        private protected void Retrait(double montant, double ligneDeCredit)
        {
            if (montant <= 0)
            {
                //Todo : Déclencher une erreur (plus tard)
                return;
            }

            if (Solde - montant < -ligneDeCredit)
            {
                //Todo : Déclencher une erreur (plus tard)
                return;
            }

            _solde -= montant;
        }

        protected abstract double CalculInteret();

        public void AppliquerInteret()
        {
            Solde += CalculInteret();
        }
    }
}