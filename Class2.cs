using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
    
{ 
    
    public class Specification  

    {
       

        public enum Specification1 { Fruits, Vegetables, DairyProducts, Sweets }
        public enum Specification2 { Alcohol, Water, Juice }
        public enum Specification3 { Bread, Rolls, Pasta, Rice }
        public enum Specification4 { TV, Laptop, Cleanner, Dryer}
        public enum Specification5 { WashinngMachine, Washer, Firdge}
        public Specification1 Sp1 { get; set; } 
        public Specification2 Sp2 { get; set; }

        public Specification() { }

        public Specification(Specification1 sp1, Specification2 sp2)
        {
            this.Sp1 = sp1;
            this.Sp2 = sp2;

        }
    
        
        
    }

}