using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Hipermarket : Specification
    {
        

        public enum Types { Food, Drink, Stationery, RTV, AGD, }
        public enum Marks { Pepsi, CocaCola, Sprite, Bakoma }
        public string Product { get; set; }
        public float Prize { get; set; }
        public Types Type { get; set; }
        public Marks Mark { get; set; }
        public object sp2 { get;  set; }

        public Hipermarket() { }

      

        public Hipermarket(string product, float prize, Types type, Marks mark, Specification1 sp1, Specification2 sp2 )
        {
            this.Product = product;
            this.Prize = prize;
            this.Type = type;
            this.Mark = mark;
            this.Sp1 = sp1;
            this.Sp2 = sp2;
         
            
        }

        public Hipermarket(string product, float prize, Types type, Marks mark, Specification1 sp1)
        {
            Product = product;
            Prize = prize;
            Type = type;
            Mark = mark;
            Sp1 = sp1;
        }
    }
}
