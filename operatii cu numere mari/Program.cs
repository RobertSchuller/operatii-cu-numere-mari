using System;
using System.Linq;

namespace operatii_cu_numere_mari
{
    internal partial class Program
    {

        // Adunare 
        static string Adunare(string a, string b)
        {

            if (a.Length > b.Length)
            {
                string t = a;
                a = b;
                b = t;
            }

            // am luat un string gol pentru a stoca rezultatul
            string str = "";

            // am calculat lungimea celor doua string-uri 
            int n1 = a.Length, n2 = b.Length;

            // am dat reverse la cele doua string-uri
            char[] ch = a.ToCharArray();
            Array.Reverse(ch);
            a = new string(ch);
            char[] ch1 = b.ToCharArray();
            Array.Reverse(ch1);
            b = new string(ch1);

            int carry = 0;
            for (int i = 0; i < n1; i++)
            {
                // formula

                int sum = ((int)(a[i] - '0') +
                        (int)(b[i] - '0') + carry);
                str += (char)(sum % 10 + '0');

                // Calculam 'carry' pentru urmatorul pas 
                carry = sum / 10;
            }

            // am adaugat cifrele ramase
            for (int i = n1; i < n2; i++)
            {
                int sum = ((int)(b[i] - '0') + carry);
                str += (char)(sum % 10 + '0');
                carry = sum / 10;
            }


            if (carry > 0)
                str += (char)(carry + '0');

            // am dat reverse la rezultat
            char[] ch2 = str.ToCharArray();
            Array.Reverse(ch2);
            str = new string(ch2);

            return str;
        }

        static bool mic(string a, string b)
        {
            // ne asiguram ca 'a' nu este mai mic decat 'b' pentru a realiza apoi diferenta 'a-b'
            int n1 = a.Length, n2 = b.Length;

            if (n1 < n2)
                return true;
            if (n2 < n1)
                return false;

            for (int i = 0; i < n1; i++)
            {
                if (a[i] < b[i])
                    return true;
                else if (a[i] > b[i])
                    return false;
            }
            return false;
        }

        // realizam diferenta a-b 
        static string Diferenta(string a, string b)
        {
            // verificam daca a>b
            if (mic(a, b))
            {
                string t = a;
                a = b;
                b = t;
            }


            String str = "";


            int n1 = a.Length, n2 = b.Length;
            int diff = n1 - n2;


            int carry = 0;


            for (int i = n2 - 1; i >= 0; i--)
            {
                // formula diff
                int sub = (((int)a[i + diff] - (int)'0')
                           - ((int)b[i] - (int)'0') - carry);
                if (sub < 0)
                {
                    sub = sub + 10;
                    carry = 1;
                }
                else
                    carry = 0;

                str += sub.ToString();
            }

            // adaugam cifrele ramase din a[]
            for (int i = n1 - n2 - 1; i >= 0; i--)
            {
                if (a[i] == '0' && carry > 0)
                {
                    str += "9";
                    continue;
                }
                int sub = (((int)a[i] - (int)'0') - carry);
                if (i > 0 || sub > 0) // am eliminat zerourile ramase
                    str += sub.ToString();
                carry = 0;
            }

            // reverse
            char[] aa = str.ToCharArray();
            Array.Reverse(aa);
            return new string(aa);
        }
        static void Main()
        {
            string a = "10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            string b = "2";
            Console.WriteLine("Suma dintre cele doua numere este: " + Adunare(a, b));
            Console.WriteLine("Diferenta dintre cele doua numere este: " + Diferenta(a, b));
        }
    }

}