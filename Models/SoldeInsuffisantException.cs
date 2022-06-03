using System.Runtime.Serialization;

namespace Models
{
    [Serializable]
    public class SoldeInsuffisantException : Exception
    {
        public SoldeInsuffisantException() : base("Solde insuffisant")
        {
        }
    }
}