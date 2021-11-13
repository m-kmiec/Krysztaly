using System;
using System.IO;

namespace Krysztaly
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader stream = new StreamReader("in.txt");

            int size = Convert.ToInt32(stream.ReadLine());

            int[] arr = new int[size];

            string line;
            int p = 0;

            while((line = stream.ReadLine())!= null)
            {
                arr[p] = Convert.ToInt32(line);
                p++;
            }
          
            Array.Sort(arr);
            Array.Reverse(arr);

            int max_weight = arr[0], min_amount = 1, j;

            for (int i = 0; i < arr.Length; i++)
            {
                int weight = arr[i];
                int amount = 0;
                j = i + 1;

                while (j < arr.Length)
                {
                    if (weight + arr[j] > 300)
                        j++;
                    else
                    { 
                        weight += arr[j];
                        //Console.WriteLine($"{arr[j]},{weight}");
                        j++;
                        amount++;
                    }
                }

                if(weight > max_weight)
                {
                    max_weight = weight;
                    min_amount = amount;
                }
                else if(weight == max_weight)
                {
                    if (amount < min_amount)
                        min_amount = amount;
                }
            }
            Console.WriteLine($"{max_weight}, {min_amount + 1}");
            StreamWriter streamWriter = new StreamWriter("out.txt");
            streamWriter.WriteLine($"{max_weight}, {min_amount + 1}");
        }
    }
}
