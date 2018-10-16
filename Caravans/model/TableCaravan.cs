using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravans.model
{
    public class TableCaravan
    {
        private string Id;
        private string IdLoc;
        private int Wagons;
        private int Guard;
        private int Duration;
        private int Minions;

        public TableCaravan(string Id, string IdLoc, int Wagons, int Guard, int Duration, int Minions)
        {
            this.Id = Id;
            this.IdLoc = IdLoc;
            this.Wagons = Wagons;
            this.Guard = Guard;
            this.Duration = Duration;
            this.Minions = Minions;
        }

        public string GetId()
        {
            return this.Id;
        }

        public string GetIdLoc()
        {
            return this.IdLoc;
        }

        public int GetWagons()
        {
            return this.Wagons;
        }

        public int GetGuard()
        {
            return this.Guard;
        }

        public int GetDuration()
        {
            return this.Duration;
        }

        public int GetMinions()
        {
            return this.Minions;
        }

        //Sety

        public void SetId(string Id)
        {
            this.Id = Id;
        }

        public void SetIdLoc(string IdLoc)
        {
            this.IdLoc = IdLoc;
        }

        public void SetWagons(int Wagons)
        {
            this.Wagons = Wagons;
        }

        public void SetGuard(int Guard)
        {
            this.Guard = Guard;
        }

        //inne

        public void ChangeDuration()
        {
            if (this.Duration > 0)
            {
                this.Duration--;
            }
        }

        public void BackDuration()
        {
            this.Duration++;
        }

        public void ChangeDuration(int zmienna)
        {
                this.Duration = zmienna;
        }

        public void SetMinions(int Minions)
        {
            this.Minions = Minions;
        }
    }
}
