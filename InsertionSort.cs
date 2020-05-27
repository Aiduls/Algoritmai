using System;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int[] arr;

            Console.WriteLine("Įveskite masyvo elementų kiekį");
            n = Convert.ToInt32(Console.ReadLine());
            arr = new int[n];

            createElements(n, arr);

            Console.WriteLine("Sugeneruotas masyvas:");
            for (int i = 0; i < n; i++) Console.Write(arr[i] + " ");
            Console.WriteLine();

            sortElements(n, arr);

            Console.WriteLine("Surūšiuotas masyvas:");
            for (int i = 0; i < n; i++) Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        /*
         * Sugeneruoja n random elementų masyve nuo -1000 iki 1000 imtinai.
         */
        static protected int[] createElements(int n, int[] arr)
        {
            var rand = new Random();
            for (int i = 0; i < n; i++)
            {
                arr[i] = rand.Next(-1001,1001);
            }
            return arr;
        }

        /*
         * Surūšiuoja masyvo narius naudojant Insertion Sort algoritmą
         */
        static protected int[] sortElements(int n, int[] arr)
        {
            int val;
            bool isBigger;
            for (int i = 1; i < n; i++)
            {
                val = arr[i]; // elementas, kurį reikia įterpti
                isBigger = false; // priskiria defaultinę reikšmę, kad arr[j] NĖRA didesnis nei val

                /*
                 * ciklas, tikrinantis ar dabartinis val yra mažesnis už ankstesnius elementus. 
                 * Jei val mažesnis, didesnį elementą perstumia į dešinę ir tikrina toliau.
                 * Jei randa elementą, mažesnį už val, įstato val reikšmę už jo - t.y. į neseniausiai paslinkto į dešinę elemento vietą.
                 */
                for (int j = i - 1; j >= 0 && isBigger != true;) 
                {
                    if (val < arr[j])
                    {
                        arr[j + 1] = arr[j];
                        j--;
                        arr[j + 1] = val;
                    }
                    else isBigger = true; // jei dabartinis arr[j] tampa didesnis už arr[i], ciklas baigiasi
                }
            }
            return arr;
        }
    }
}
