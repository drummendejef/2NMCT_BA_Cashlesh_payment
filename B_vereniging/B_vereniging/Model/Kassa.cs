using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_vereniging.Model
{
    class Kassa
    {
        /*UITLEG: Kassa's*/
        //Properties

        public int ID { get; set; }

        private string _beschrijving;

        public string Beschrijving
        {
            get { return _beschrijving; }
            set { _beschrijving = value; }
        }

        private string _plaats;

        public string Plaats
        {
            get { return _plaats; }
            set { _plaats = value; }
        }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
        


        
        
    }
}
