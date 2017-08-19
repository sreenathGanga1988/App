using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Extensions
{
    class Controls
    {
    }

    class ValueButton : System.Windows.Forms.Button //this inherits from button
    {

        //constructor
        public ValueButton()
        {  /*you dont need to do anything here*/  }


        //add public property
        private string btnvalue;
        public string _value
        {
            get { return btnvalue; }
            set { btnvalue = value; }
        }
    }
}
