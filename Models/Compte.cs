namespace Models
{
    public abstract class Compte : ICustomer, IBanker
    {
        //double = double + Courant
        public static double operator +(double d, Compte compte)
        {
            return (d < 0 ? 0 : d) + (compte.Solde < 0 ? 0 : compte.Solde);
        }

        public event Action<Compte> PassageEnNegatifEvent;

        private string _numero;
        private double _solde;
        private Personne _titulaire;


        protected Compte(string numero, Personne titulaire)
        {
            Numero = numero;
            Titulaire = titulaire;
        }

        protected Compte(string numero, Personne titulaire, double solde) : this(numero, titulaire)
        {
            Solde = solde;
        }

        public string Numero
        {
            get
            {
                return _numero;
            }

            private set
            {
                _numero = value;
            }
        }

        public Personne Titulaire
        {
            get
            {
                return _titulaire;
            }

            private set
            {
                _titulaire = value;
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

        

        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException();
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
                throw new ArgumentOutOfRangeException();
            }

            if (Solde - montant < -ligneDeCredit)
            {
                throw new SoldeInsuffisantException();
            }

            _solde -= montant;
        }

        protected abstract double CalculInteret();

        public void AppliquerInteret()
        {
            Solde += CalculInteret();
        }

        protected void Notify()
        {
            PassageEnNegatifEvent?.Invoke(this);
        }
    }
}