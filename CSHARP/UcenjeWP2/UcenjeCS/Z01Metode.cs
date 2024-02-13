using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class Z01Metode
    {
        // Napisati metodu koja za dva primljena decimalna broja
        // vraća cijeli dio zbroja primljenih brojeva
        // primi 2,7 i 3,7    vraća 6

        public static int CijeliDioZbroja(float a, float b)
        {
            return CijeliDioZbroja((double)a,(double)b);
        }

        // method overloading
        // potpis metode: naziv + lista parametara

        public static int CijeliDioZbroja(double a, double b)
        {
            return (int)(a + b);
        }

    }
}
