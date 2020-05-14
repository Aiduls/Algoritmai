using System;

namespace PalindromicPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0, b = 0;

            getInput(a, b);

        }
        static void getInput(int a, int b) 
        {
            try
            {
                Console.WriteLine("Įveskite nuo kurio skaičiaus pradėti rinkti palindrominius pirminius skaičius: ");
                a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Įveskite iki kurio skaičiaus rinkti palindrominius pirminius skaičius: ");
                b = Convert.ToInt32(Console.ReadLine());
                if (a >= b)
                {
                    throw new Exception("Pirmas skaičius turi būti mažesnis už antrą");
                }
                else
                {
                    if (b<1) 
                        printArray(a, b,null,0);
                    else
                        searchForSpecialNums(a, b);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Įveskite skaičius.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Klaida: " + e.Message);
            }
        }
        static void searchForSpecialNums(int a, int b)
        {
            int start = 1;
            int counter = 0;
            int[] arr;

            if (a > 1) start = a;

            arr = new int[b-start];
            
            for (int i = start; i < b; i++)
            {
                if (IsPalindromic(i))
                {
                    if (IsPrime(i))
                    {
                        Console.Write(i.ToString() + " ");
                        arr[counter] = i;
                        counter++;
                    }
                }
            }

            printArray(a, b, arr, counter);
        }
        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            /*
             *  method of checking the primality of a given number n, called trial division, tests
             *  whether n is a multiple of any integer between 2 and sqrt(n)
             */
            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
        static bool IsPalindromic(int number)
        {
            string str = number.ToString();
            int noOfDigits = str.Length;

            if (noOfDigits <= 1)
            {
                return true;
            }
            else
            {
                for (int i = 0; i<noOfDigits/2; i++)
                {
                    if (str[i] != str[noOfDigits - 1 - i])
                        return false;
                }
                return true;
            }

        }
        static void printArray(int a, int b, int[] arr, int counter)
        {
            if (counter == 0)
            {
                Console.WriteLine("Pirminių palendrominių skaičių intervale nuo " + a + " iki " + b + " nėra");
            }
            else
            {
                Console.WriteLine("Pirminiai palendrominiai skaičiai nuo " + a + " iki " + b);
                for (int i = 0; i < counter; i++)
                    Console.Write(arr[i] + " ");
            }
        }
    }
}
