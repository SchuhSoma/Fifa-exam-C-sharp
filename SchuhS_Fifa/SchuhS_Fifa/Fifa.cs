using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhS_Fifa
{
    class Fifa
    {
        // Csapat;Helyezes;Valtozas;Pontszam
        public string Csapat;
        public int Helyezes;
        public int Valtozas;
        public int Pontszam;

        public Fifa(string sor)
        {
            var dbok = sor.Split(';');
            this.Csapat = dbok[0];
            this.Helyezes = int.Parse(dbok[1]);
            this.Valtozas = int.Parse(dbok[2]);
            this.Pontszam = int.Parse(dbok[3]);

        }
    }
}
