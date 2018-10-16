using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravans.model
{
    class Tablicadoliczenia
    {
        private string IdLoc = "";
        private int czas = -1;
        private int done = 0;
        private string poprzIdloc = "";// byc moze do wywalenia przy optymalizacji

        public Tablicadoliczenia()
        {
            this.IdLoc = "";
        }
        public Tablicadoliczenia(string IdLoc)
        {
            this.IdLoc = IdLoc;
            this.czas = -1;
            this.done = 0;
        }
        public string GetIdLoc()
        {
            return this.IdLoc;
        }
        public int Getczas()
        {
            return this.czas;
        }
        public int Getdone()
        {
            return this.done;
        }
        public string GetpoprzIdloc()// byc moze do wywalenia przy optymalizacji
        {
            return this.poprzIdloc;
        }

        //Sety

        public void SetIdLoc(string IdLoc)
        {
            this.IdLoc = IdLoc;
        }
        public void Setczas(int czas)
        {
            this.czas = czas;
        }
        public void Setdone(int done)
        {
            this.done = done;
        }
        public void SetpoprzIdloc(string poprzIdloc)// byc moze do wywalenia przy optymalizacji
        {
            this.poprzIdloc = poprzIdloc;
        }
    }
}
