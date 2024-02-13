using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E18Ekstenzije
{
    internal class Smjer : Entitet, ISucelje
    {
        public void Posao()
        {
            Console.WriteLine("Radim posao na smjeru");
        }
    }
}
