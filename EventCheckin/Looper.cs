using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCheckin
{
    class Looper
    {
        private int nr = 100000;
        private string id;

        public string LoopID()
        {
            if (nr > 99999)
            {
                nr = nr + 1;
                id = "0000" + Convert.ToString(nr);    
            }
           return id;
        }
    }
}
