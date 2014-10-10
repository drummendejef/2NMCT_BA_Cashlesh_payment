using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_medewerkers.Model
{
    class Bestelling
    {
        public double Totaalprijs { get; set; }

        public List<Product> Bestelde_producten { get; set; }
    }
}
