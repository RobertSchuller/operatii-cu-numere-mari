using System;

namespace operatii_cu_numere_mari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Va rog sa selectati operatia:");
                Console.WriteLine("1. Adunare");
                Console.WriteLine("2. Scadere");
                Console.WriteLine("3. Inmultire");
                Console.WriteLine("4. Impartire");
                Console.WriteLine("5. Radical");
                Console.WriteLine("6. Ridicare la putere");
                Console.WriteLine("7. Iesire");

                string input = Console.ReadLine();

                int operation, result = 0;
                int.TryParse(input, out operation);
                if (operation == 7)
                {
                    Console.WriteLine("Calculatorul a fost oprit");
                    return;
                }

                int n, first = 0;
                int[] a = new int[100];
                Console.WriteLine("Dati numarul de cifre din vectorul a:");
                n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    Console.Write("a[{0}]=", i);
                    a[i] = int.Parse(Console.ReadLine());
                }
                for (int i = 0; i < n; i++)
                {
                    first = first * 10 + a[i];

                }
                Console.WriteLine("Primul numar este: " + first);
              
                if (operation == 5)
                {
                    result = Calculator.Radical(first);
                    Console.WriteLine("Radicalul primului numar este: " + result);

                }


                int m, second = 0;
                int[] b = new int[100];
                Console.WriteLine("Dati numarul de cifre din vectorul b:");
                m = int.Parse(Console.ReadLine());
                for (int i = 0; i < m; i++)
                {
                    Console.Write("b[{0}]=", i);
                    b[i] = int.Parse(Console.ReadLine());
                }
                for (int i = 0; i < m; i++)
                {
                    second = second * 10 + b[i];

                }
                Console.WriteLine("Al doilea numar este: " + second);
               
                if (operation == 5)
                {
                    result = Calculator.Radical(second);
                    Console.WriteLine("Radicalul celui de al doilea numar este: " + result);

                }
                if (operation == 6)
                {
                    int x = 1;
                    for(int i = 0; i < second; i++)
                    {
                        x = x * first;
                    }
                    Console.WriteLine("Rezultatul ridicarii la putere este: " + x);
                }



                switch (operation)
                {
                    case 1:
                        result = Calculator.Adunare(first, second);
                        Console.WriteLine("Rezultatul adunarii este: " + result);
                        break;
                    case 2:
                        result = Calculator.Scadere(first, second);
                        Console.WriteLine("Rezultatul scaderii este: " + result);
                        break;
                    case 3:
                        result = Calculator.Inmultire(first, second);
                        Console.WriteLine("Rezultatul inmultirii este: " + result);
                        break;
                    case 4:
                        result = Calculator.Impartire(first, second);
                        Console.WriteLine("Rezultatul impartirii este: " + result);
                        break;


                }
                
            }
        }
    }
}