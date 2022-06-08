namespace Models
{
    public interface IBanker : ICustomer
    {
        event Action<Compte> PassageEnNegatifEvent;
        string Numero { get; }
        Personne Titulaire { get; }
        void AppliquerInteret();
    }
}