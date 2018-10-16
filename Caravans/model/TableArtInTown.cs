﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravans.model
{
    public class TableArtInTown
    {
        private string Id;
        private string IdArticle;
        private int Number;
        private int Requisition;
        private int Production;

        public TableArtInTown(string Id, string IdArticle, int Number, int Requisition, int Production)
        {
            this.Id = Id;
            this.IdArticle = IdArticle;
            this.Number = Number;
            this.Requisition = Requisition;
            this.Production = Production;
        }

        public string GetId()
        {
            return this.Id;
        }

        public string GetIdArticle()
        {
            return this.IdArticle;
        }

        public int GetNumber()
        {
            return this.Number;
        }

        public int GetRequisition()
        {
            return this.Requisition;
        }

        public int GetProduction()
        {
            return this.Production;
        }

        //Set

        public void SetId(string Id)
        {
            this.Id = Id;
        }

        public void SetIdArticle(string IdArticle)
        {
            this.IdArticle = IdArticle;
        }

        public void SetNumber(int Number)
        {
            this.Number = Number;
        }

        public void SetRequisition(int Requisition)
        {
            this.Requisition = Requisition;
        }

        public void SetProduction(int Production)
        {
            this.Production = Production;
        }
    }
}
