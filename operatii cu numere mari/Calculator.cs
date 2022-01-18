using System;

namespace operatii_cu_numere_mari
{
    static class Calculator
    {
        public static int Adunare(int first, int second)
        {
            return first + second;
        }

        public static int Impartire(int first, int second)
        {
            try//Mi a dat eraorea DivideByZeroException,si am reusit sa o rezolv astfel:
            {

                return first / second;
            }
            catch (DivideByZeroException)
            {

                Console.WriteLine("Diviziunea nu e posibila");
                return 0;
            }

        }
        public static int Inmultire(int first, int second)
        {
            return first * second;
        }
        public static int Scadere(int first, int second)
        {
            return first - second;
        }

        public static int Radical(int first)
        {
            return (int)Math.Sqrt(first);
        }
        

    }
}