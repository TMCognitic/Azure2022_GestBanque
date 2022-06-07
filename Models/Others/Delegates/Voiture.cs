using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Others.Delegates
{
    public class Voiture
    {
        public string Plaque { get; init; }

        public Voiture(string plaque)
        {
            Plaque = plaque;
        }
    }
}
