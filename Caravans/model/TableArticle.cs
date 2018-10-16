using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravans.model
{
    public class TableArticle
    {
        private string Id;
        private string Name;
        private int Price;
        private int Production;
        private int Requisition;

        public TableArticle(string Id, string Name, int Price, int Production, int Requisition)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Production = Production;
            this.Requisition = Requisition;
        }

        //GETs

        public string GetId()
        {
            return this.Id;
        }

        public string GetName()
        {
            return this.Name;
        }

        public int GetPrice()
        {
            return this.Price;
        }

        public int GetProduction()
        {
            return this.Production;
        }

        public int GetRequisition()
        {
            return this.Requisition;
        }

        //SETs

        public void SetId(string Id)
        {
            this.Id = Id;
        }

        public void SetName(string Name)
        {
            this.Name = Name;
        }

        public void SetPrice(int Price)
        {
            this.Price = Price;
        }
        public void SetProduction(int Production)
        {
            this.Production = Production;
        }

        public void SetRequisition(int Requisition)
        {
            this.Requisition = Requisition;
        }
    }
}
