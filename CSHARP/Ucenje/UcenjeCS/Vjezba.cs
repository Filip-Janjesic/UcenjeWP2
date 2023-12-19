namespace UcenjeCS
{
    internal class Vjezba
    {
        static void Main(string[] args)
        {
            // Task 1
            int a = 5;
            Console.WriteLine(a); //5
            a = a - 2; // decrease by 2
            Console.WriteLine(a); //3
            a -= 1; // decrease by 1
            Console.WriteLine(a); //2
            a--; // decrease by 1
            Console.WriteLine(a); //1

            // Task 2
            double b = 2.5;
            Console.WriteLine(b); //2.5
            b = b * 3; // multiply by 3
            Console.WriteLine(b); //7.5
            b *= 2; // multiply by 2
            Console.WriteLine(b); //15.0
            b++; // increase by 1
            Console.WriteLine(b); //16.0

            // Task 3
            float c = 8.0f;
            Console.WriteLine(c); //8.0
            c = c / 4; // divide by 4
            Console.WriteLine(c); //2.0
            c /= 2; // divide by 2
            Console.WriteLine(c); //1.0
            c++; // increase by 1
            Console.WriteLine(c); //2.0
        }
    }
}
