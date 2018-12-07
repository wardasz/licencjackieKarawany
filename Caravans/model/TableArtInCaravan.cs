using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravans.model
{
    public class TableArtInCaravan
    {
        private string Id;
        private string IdArticle;
        private int Number;

        public TableArtInCaravan(string Id, string IdArticle, int Number)
        {
            this.Id = Id;
            this.IdArticle = IdArticle;
            this.Number = Number;
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
    }
}
