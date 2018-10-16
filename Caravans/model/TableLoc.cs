using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravans.model
{
    public class TableLoc
    {
        private string Id;
        private string Name;


        public TableLoc(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
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

        //sety

        public void SetId(string Id)
        {
            this.Id = Id;
        }

        public void SetName(string Name)
        {
            this.Name = Name;
        }
    }
}
