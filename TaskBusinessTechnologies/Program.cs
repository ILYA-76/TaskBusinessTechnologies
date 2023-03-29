using System;

class Program
{
    static void Main(String[] args)
    {
        int[] array = { 9, 5, 8, 1, 10, 2, 3, 7, 4, 6 };
        Console.WriteLine("Массив до сортировки");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i]} ");
        }
        array = sort(array);

        Console.WriteLine();

        for (int i = 0;i < array.Length; i++)
        {
            Console.Write($"{array[i]} ");
        }


    }

    public static int[] sort(int[] x)
    {
        if (x.Length == 1)
            return x;
        else
        {
            int half = x.Length / 2;
            int[] halfFirst = new int[half];
            int[] halfSecond = new int[x.Length - half];

            for (int i = 0; i < x.Length; i++)
            {
                if (i < half)
                    halfFirst[i] = x[i];
                else
                    halfSecond[i-half] = x[i];
            }
            halfFirst = sort(halfFirst);
            halfSecond = sort(halfSecond);
            x = sortNext(halfFirst, halfSecond);
            return x;
        }
    }

    public static int[] sortNext(int[] x, int[] y)
    {
        int[] c = new int[x.Length + y.Length];
        int a = 0, b = 0;

        for (int i = 0; i < x.Length +y.Length; i++)
        {
            if (a == x.Length)
            {
                c[i] = y[b];
                b++;
            }
            else if (b == y.Length)
            {
                c[i] = x[a];
                a++;
            }
            else if (x[a] > y[b])
            {
                c[i] = y[b];
                b++;
            }
            else
            {
                c[i] = x[a];
                a++;
            }
        }
        return c;
    }
}