using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E18Ekstenzije
{
    internal static class Ekstenzije
    {
        public static void OdradiPosao(this ISucelje sucelje) {
            sucelje.Posao();
        }
    }
}
