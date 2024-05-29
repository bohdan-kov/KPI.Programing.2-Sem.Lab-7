using System;

namespace Labs_7
{
    class SelectionSortStrategy
    {
        public int[] Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
            return array;
        }
    }

    class InsertionSortStrategy
    {
        public int[] Sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
            return array;
        }
    }

    class BogoSortStrategy
    {
        private bool IsSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public int[] Sort(int[] array)
        {
            Random random = new Random();
            int iterations = 0;

            while (!IsSorted(array))
            {
                iterations++;
                for (int i = 0; i < array.Length; i++)
                {
                    int randomIndex = random.Next(0, array.Length); 
                    int temp = array[i];
                    array[i] = array[randomIndex];
                    array[randomIndex] = temp;
                }
            }

            Console.WriteLine($"\nЗнадобилося для Бого сортування: {iterations} iтерацiй.");
            return array;
        }
    }

    internal class Program
    {
        private static void PrintResult(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public static int[] RandomGenerationArray(Random rnd, int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Довжина массива повинна бути більша за 0.");
            }

            int[] resultArray = new int[length];

            for (int i = 0; i < length; i++)
            {
                resultArray[i] = rnd.Next(1, 101);
            }

            return resultArray;
        }

        public static void Main(string[] args)
        {
            Random rnd = new Random();

            int arrayLength = 5;

            int[] originalArray = RandomGenerationArray(rnd, arrayLength);

            Console.WriteLine("Початковий масив:");
            PrintResult(originalArray);

            //Вибору
            SelectionSortStrategy selectionSort = new SelectionSortStrategy();
            int[] sortedSelection = selectionSort.Sort((int[])originalArray.Clone());
            Console.WriteLine("\nСортування вибором:");
            PrintResult(sortedSelection);

            //Вставок
            InsertionSortStrategy insertionSort = new InsertionSortStrategy();
            int[] sortedInsertion = insertionSort.Sort((int[])originalArray.Clone());
            Console.WriteLine("\nСортування вставками:");
            PrintResult(sortedInsertion);

            //Вogo Sort
            BogoSortStrategy bogoSort = new BogoSortStrategy();
            int[] sortedBogo = bogoSort.Sort((int[])originalArray.Clone());
            Console.WriteLine("\nСортування Бого(Bogo):");
            PrintResult(sortedBogo);
        }
    }
}
