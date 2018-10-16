using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravans.model
{
    public class TableState
    {
        private string Id;
        private string Name;
        private string Description;
        private string ShortDes;

        public TableState(string Id, string Name, string Description)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
        }

        //gety

        public string GetId()
        {
            return this.Id;
        }

        public string GetName()
        {
            return this.Name;
        }

        public string GetDescription()
        {
            return this.Description;
        }

        //sety

        public void SetId(string Id)
        {
            this.Id = Id;
        }

        public void SetName(string Name)
        {
            this.Name = Name;
        }

        public void SetDescription(string Description)
        {
            this.Description = Description;
        }

    }
}
