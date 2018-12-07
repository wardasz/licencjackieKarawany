using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravans.model
{
    public class TableRoad
    {
        private string Id;
        private string IdLoc_1;
        private string IdLoc_2;
        private int Length;
        private int Quality;

        public TableRoad(string Id, string IdLoc_1, string IdLoc_2, int Length, int Quality)
        {
            this.Id = Id;
            this.IdLoc_1 = IdLoc_1;
            this.IdLoc_2 = IdLoc_2;
            this.Length = Length;
            this.Quality = Quality;
        }

        public string GetId()
        {
            return this.Id;
        }

        public string GetIdLoc_1()
        {
            return this.IdLoc_1;
        }

        public string GetIdLoc_2()
        {
            return this.IdLoc_2;
        }

        public int GetLength()
        {
            return this.Length;
        }

        public int GetQuality()
        {
            return this.Quality;
        }

        public void SetId(string Id)
        {
            this.Id = Id;
        }

        public void SetQuality(int Quality)
        {
            this.Quality = Quality;
        }

        public void SetIdLoc_1(string IdLoc_1)
        {
            this.IdLoc_1 = IdLoc_1;
        }

        public void SetIdLoc_2(string IdLoc_2)
        {
            this.IdLoc_2 = IdLoc_2;
        }

        public void SetLength(int Length)
        {
            this.Length = Length;
        }
    }
}
