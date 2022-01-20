using System;

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
            int len1 = a.Length, len2 = b.Length;

            // am dat reverse la cele doua string-uri
            char[] ch = a.ToCharArray();
            Array.Reverse(ch);
            a = new string(ch);
            char[] ch1 = b.ToCharArray();
            Array.Reverse(ch1);
            b = new string(ch1);

            int carry = 0;
            for (int i = 0; i < len1; i++)
            {
                // formula

                int sum = ((int)(a[i] - '0') +
                        (int)(b[i] - '0') + carry);
                str += (char)(sum % 10 + '0');

                // Calculam 'carry' pentru urmatorul pas 
                carry = sum / 10;
            }

            // am adaugat cifrele ramase
            for (int i = len1; i < len2; i++)
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

        static bool Mic(string a, string b)
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
            if (Mic(a, b))
            {
                string t = a;
                a = b;
                b = t;
            }


            string str = "";


            int len1 = a.Length, len2 = b.Length;
            int diff = len1 - len2;


            int carry = 0;


            for (int i = len2 - 1; i >= 0; i--)
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
            for (int i = len1 - len2 - 1; i >= 0; i--)
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

        //Inmultire
        static string Inmultire(string a, string b)
        {
            int len1 = a.Length;
            int len2 = b.Length;
            if (len1 == 0 || len2 == 0)
                return "0";

            // se va pastra numarul rezultat în vector in ordine inversa
            
            int[] result = new int[len1 + len2];

            // mai jos am utilizat doi indici pentru a gasi pozitii în rezultat
            int i_n1 = 0;
            int i_n2 = 0;
            int i;

            
            for (i = len1 - 1; i >= 0; i--)
            {
                int carry = 0;
                int n1 = a[i] - '0';
                i_n2 = 0;

                          
                for (int j = len2 - 1; j >= 0; j--)
                {
                    // se ia cifra curenta a celui de al doilea numar
                    
                    int n2 = b[j] - '0';

                    //  inmultim cu cifra curenta a primului numar si adaugam rezultatul 
                    //  la rezultatul stocat anterior
                    int sum = n1 * n2 + result[i_n1 + i_n2] + carry;

                    // folosim carry
                    carry = sum / 10;

                    //si stocam rezultatul 
                    result[i_n1 + i_n2] = sum % 10;

                    i_n2++;
                }

                // stocam carry
                if (carry > 0)
                    result[i_n1 + i_n2] += carry;
                i_n1++;
            }

            // ignoram zerourile din partea dreapta 
            i = result.Length - 1;
            while (i >= 0 && result[i] == 0)
                i--;

            // daca rezultatul e 0 => unul din numere a fost 0 
            if (i == -1)
                return "0";

            // se genereaza string-ul rezultat 
            string s = "";

            while (i >= 0)
                s += (result[i--]);

            return s;
        }
        public static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Selectati operatia dorita:");
            Console.WriteLine("1.Adunare.");
            Console.WriteLine("2.Diferenta.");
            Console.WriteLine("3.Inmultire.");
            
            n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                string a = "10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                string b = "492189080917489013749827309532485098275890237509237508927589023780392740923740923789043939393832929";
                Console.WriteLine("Suma dintre cele doua numere este: " + Adunare(a, b));
            }
            if (n == 2)
            {
                string a = "10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                string b = "7732846376746732838238777777777777777777777777777777777723263726372188294786724768767386782683917";
                Console.WriteLine("Diferenta dintre cele doua numere este: " + Diferenta(a, b));

            }

            if (n == 3)
            {
                string a = "73598248972394127856213894572938479283576289759823146578346589237492347023147013974013740127598126598721398507";
                string b = "345972659823740923749823174091384";
                
                
                //aici am determinat daca rezultatul este cu minus sau fara
                if ((a[0] == '-' || b[0] == '-') && (a[0] != '-' || b[0] != '-'))
                    Console.Write("-");

                if (a[0] == '-' && b[0] != '-')
                {
                    a = a.Substring(1);
                }
                else if (a[0] != '-' && b[0] == '-')
                {
                    b = b.Substring(1);
                }
                else if (a[0] == '-' && b[0] == '-')
                {
                    a = a.Substring(1);
                    b = b.Substring(1);
                }
                Console.WriteLine("Rezultatul inmultirii este: " + Inmultire(a, b));
                
            }
            
           
        }

    }
}   
