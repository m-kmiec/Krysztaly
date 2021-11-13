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

            int result = arr[0], min_index = 1, j;

            for (int i = 0; i < arr.Length; i++)
            {
                int comp = arr[i];
                int index = 0;
                j = i + 1;

                while (j < arr.Length)
                {
                    if (comp + arr[j] > 300)
                        j++;
                    else
                    {
                        comp += arr[j];
                        j++;
                        index++;
                    }
                }

                if(comp > result)
                {
                    result = comp;
                    min_index = index + 1;
                }
                else if(comp == result)
                {
                    if (index < min_index)
                        min_index = index;
                }
            }
            Console.WriteLine($"{result}, {min_index}");
            
        }
    }
}
