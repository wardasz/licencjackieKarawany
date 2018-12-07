using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravans.model
{
    public class TableTown
    {
        private string Id;
        private string Name;
        private int Population;
        private string IdLoc;
        private int Military;
        private int Prosperity;
        private int Food;

        public TableTown(string Id, string Name, int Population, string IdLoc, int Military, int Prosperity, int Food)
        {
            this.Id = Id;
            this.Name = Name;
            this.Population = Population;
            this.IdLoc = IdLoc;
            this.Military = Military;
            this.Prosperity = Prosperity;
            this.Food = Food;
        }

        public string GetId()
        {
            return this.Id;
        }

        public string GetName()
        {
            return this.Name;
        }

        public int GetPopulation()
        {
            return this.Population;
        }

        public string GetIdLoc()
        {
            return this.IdLoc;
        }

        public int GetMilitary()
        {
            return this.Military;
        }

        public int GetProsperity()
        {
            return this.Prosperity;
        }

        public int GetFood()
        {
            return this.Food;
        }

        public void SetId(string Id)
        {
            this.Id = Id;
        }

        public void SetName(string Name)
        {
            this.Name = Name;
        }

        public void SetPopulation(int Population)
        {
            this.Population = Population;
        }

        public void SetIdLoc(string IdLoc)
        {
            this.IdLoc = IdLoc;
        }

        public void SetMilitary(int Military)
        {
            this.Military = Military;
        }

        public void SetProsperity(int Prosperity)
        {
            this.Prosperity = Prosperity;
        }

        public void SetFood(int Food)
        {
            this.Food = Food;
        }
    }
}
