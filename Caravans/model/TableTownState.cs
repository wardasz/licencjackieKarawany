using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravans.model
{
    public class TableTownState
    {
        private string Id;
        private string IdState;
        private int Duration;

        public TableTownState(string Id, string IdState, int Duration)
        {
            this.Id = Id;
            this.IdState = IdState;
            this.Duration = Duration;
        }

        //gety

        public string GetId()
        {
            return this.Id;
        }

        public string GetIdState()
        {
            return this.IdState;
        }

        public int GetDuration()
        {
            return this.Duration;
        }

        //Set

        public void SetId(string Id)
        {
            this.Id = Id;
        }

        public void SetIdState(string IdState)
        {
            this.IdState = IdState;
        }

        public void SetDuration(int Duration)
        {
            this.Duration = Duration;
        }
    }
}
