using System;
using System.Linq;

namespace Sudoku
{
    class Program
    {
        public static bool validSolution(int[][] grid)
        {
            return validDimension(grid) 
                && validRows(grid) 
                && validRows(grid) 
                && validColumns(grid) 
                && validSquares(grid);
        }

        public static bool validDimension (int[][] grid)
        {
            return grid.GetLength(0) != 9 || grid.GetLength(1) != 9;
        }

        public static bool validRows (int[][] grid)
        {
            bool p = true;
            foreach (int[] row in grid)
            {
                p &= validateNumbers(row);
            }
            return true;
        }

        public static bool validColumns (int[][] grid)
        {
            bool p = true;
            for (int i = 0; i < 9; i++)
            {
                int[] arr = new int[9];
                foreach (int[] row in grid)
                {
                    arr[i] = row[i];
                }
                p &= validateNumbers(arr);
            }
            return p;
        }


        public static bool validSquares (int[][] grid)
        {
            bool p = true;
            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    int[] arr = new int[9];
                    int c = 0;
                    for (int k = i; k < i+3; k++)
                    {
                        for (int o = j; o < j + 3; o++)
                        {
                            arr[c] = grid[k][o];
                            c++;
                        }
                    }
                    p &= validateNumbers(arr);
                }
            }
            return p;
        }


        public static bool validateNumbers(int[] arr)
        {
            return arr.Length == 9
                && arr.Sum() == 45 
                && arr.Distinct().Count() == arr.Length;
        }

    }
}
