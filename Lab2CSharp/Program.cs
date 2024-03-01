using System;

namespace Lab2CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 2 (variant 7)");
            Console.Write("Enter the number of task (1 - 4): ");
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.Write("One-dimensional array or Two-dimensional array?");
                        int t = Int32.Parse(Console.ReadLine());
                        if (t == 1)
                        {
                            Console.Write("Enter the n: ");
                            int n = int.Parse(Console.ReadLine());
                            int[] oneDimArray = entering_one_dim_arr(n);
                            Task1_1(oneDimArray);
                        }
                        else{
                            Console.Write("Enter the number of rows: ");
                            int r = int.Parse(Console.ReadLine());
                            Console.Write("Enter the number of columns: ");
                            int c = int.Parse(Console.ReadLine());
                            int[][] twoDimArray_1 = entering_two_dim_arr(r, c);
                            Task1_2(twoDimArray_1, r, c);
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Write("Enter the n: ");
                        int n = int.Parse(Console.ReadLine());
                        int[] oneDimArray = entering_one_dim_arr(n);
                        Task2(oneDimArray);
                        break;
                    }
                case 3:
                    Console.Write("Enter the number of rows: ");
                    int rows = int.Parse(Console.ReadLine());
                    Console.Write("Enter the number of columns: ");
                    int cols = int.Parse(Console.ReadLine());
                    int[][] twoDimArray = entering_two_dim_arr(rows, cols);
                    Console.WriteLine("Original array:");
                    PrintArray(twoDimArray, rows, cols);
                    if (cols % 2 == 0){
                        SwapMiddleColumns(twoDimArray, rows, cols);
                    } else{
                        SwapFirstAndMiddleColumn(twoDimArray, rows, cols);
                    }
                    Console.WriteLine("Result:");
                    PrintArray(twoDimArray, rows, cols);
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        static int[] entering_one_dim_arr(int n)
        {
            int[] array = new int[n];

            Console.WriteLine($"Enter {n} elements of the array:");

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Element {i + 1}: ");
                array[i] = int.Parse(Console.ReadLine());
            }
            return array;
        }

        static int[][] entering_two_dim_arr(int rows, int cols)
        {
            int[][] array = new int[rows][];

            Console.WriteLine($"Enter {rows} rows with {cols} elements each:");

            for (int i = 0; i < rows; i++)
            {
                array[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Element [{i + 1},{j + 1}]: ");
                    array[i][j] = int.Parse(Console.ReadLine());
                }
            }
            return array;
        }

        static void Task1_1(int[] array)
        {
            int count = 0;
            foreach (int element in array)
            {
                if (element % 2 != 0)
                    count++;
            }
            Console.WriteLine($"Number of odd elements in the one-dimensional array: {count}");
        }

        static void Task1_2(int[][] array, int rows, int cols)
        {
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (array[i][j] % 2 != 0)
                        count++;
                }
            }
            Console.WriteLine($"Number of odd elements in the two-dimensional array: {count}");
        }

        static void Task2(int[] arr){
            if (arr.Length == 0){
                Console.WriteLine("The array is empty. There is no maximum element.");
                return;
            }

            int max = arr[0];
            int lastIndex = 0;

            for (int i = 1; i < arr.Length; i++){
                if (arr[i] >= max)
                {
                    max = arr[i];
                    lastIndex = i;
                }
            }

            Console.WriteLine($"Index of the last maximum element: {lastIndex + 1}");
        }

        static void SwapMiddleColumns(int[][] arr, int rows, int cols){
            int middleColumn1 = cols / 2 - 1;
            int middleColumn2 = cols / 2;
            for (int i = 0; i < rows; i++){
                int temp = arr[i][middleColumn1];
                arr[i][middleColumn1] = arr[i][middleColumn2];
                arr[i][middleColumn2] = temp;
            }
        }

        static void SwapFirstAndMiddleColumn(int[][] arr, int rows, int cols){
            int middleColumn = cols / 2;
            for (int i = 0; i < rows; i++){
                int temp = arr[i][0];
                arr[i][0] = arr[i][middleColumn];
                arr[i][middleColumn] = temp;
            }
        }
        
        static void PrintArray(int[][] arr, int rows, int cols){
            for (int i = 0; i < rows; i++){
                for (int j = 0; j < cols; j++){
                    Console.Write(arr[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
