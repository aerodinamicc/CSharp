using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BishopPathFinder
{
    class Bishop
    {
        static void Main()
        {
            string line = Console.ReadLine();
            string[] dim = line.Split();
            int rows = int.Parse(dim[0]);
            int cols = int.Parse(dim[1]);
            int[,] array = new int[rows, cols];
            bool[,] BoolArray = new bool[rows, cols];
            FillingTheMatrix(array, rows, cols);
            int moves = int.Parse(Console.ReadLine());
            Console.WriteLine(Directions(moves, array, BoolArray));

        }
        static int Directions(int DirectionsChange, int[,] array, bool[,] BoolArray)
        {
            //as this array is created it will keep all temporary values of sum - temp[0], currRow - temp[1], currCol - temp[2];
            int[] temp = new int[3];
            temp[1] = array.GetLength(0) - 1;
            // the default value for temp[2] will be 0, which is fine since it is used for the columns
            int sum = 0;
            

            //do all the direction changes
            for (int i = 0; i < DirectionsChange; i++)// -1 comes because we have done one iteration already
            {
                //reading the direction and steps for each and every direction change
                string[] meta = Console.ReadLine().Split(' ');
                string direction = meta[0];
                int steps = int.Parse(meta[1]);
                
                //here the value of the key variables are updates using the temp matrix
                int currRow = temp[1];
                int currCol = temp[2];

                if (direction == "UR" || direction == "RU")
                {
                    //all the direction methods return a matrix having sum, currRow and currCol as 0, 1, 2;
                    UpRight(BoolArray, array, steps, currRow, currCol, temp);
                }
                else if (direction == "UL" || direction == "LU")
                {
                    UpLeft(BoolArray, array, steps, currRow, currCol, temp);
                }
                else if (direction == "DR" || direction == "RD")
                {
                    DownRight(BoolArray, array, steps, currRow, currCol, temp);
                 }
                else if (direction == "DL" || direction == "LD")
                {
                    DownLeft(BoolArray, array, steps, currRow, currCol, temp);
                }
                sum += temp[0];

            }
            return sum;

        }

        static int[] UpLeft(bool[,] BoolArray, int[,] array, int steps, int currRow, int currCol, int[]temp)
        {
            int sum = 0;
            while (currRow > -1 && currCol > -1 && steps>0)
            {
                if (BoolArray[currRow, currCol] == false)
                {
                    sum += array[currRow, currCol];
                    BoolArray[currRow, currCol] = true;
                }
                steps--;
                if (steps != 0)
                {
                    currCol--;
                    currRow--;
                }
            }
            //if we go OutOfRange we go one step back in the direction where we came from.
            if (currCol < 0 || currRow < 0) { currRow++; currCol++; }
            //result comes as sum, currRow, currCol. temp is an array initiated solely for the purpose of taking the values of sum, currRow, currCol out of the method.
            temp[0] = sum;
            temp[1] = currRow;
            temp[2] = currCol;

            return temp;
        }
        static int[] UpRight(bool[,] BoolArray, int[,] array, int steps, int currRow, int currCol, int[] temp)
        {
            int sum = 0;
            while (currCol < array.GetLength(1) && currRow > -1 && steps>0)
            {
               if (BoolArray[currRow, currCol] == false)
                {
                    sum += array[currRow, currCol];
                    BoolArray[currRow, currCol] = true;
                }
                steps--;
                if (steps != 0)
                {
                    currCol++;
                    currRow--;
                }
                
            }
            //if we go OutOfRange we go one step back in the direction where we came from.
            if (currCol > array.GetLength(1) - 1 || currRow < 0) { currRow++; currCol--; }
            //result comes as sum, currRow, currCol. temp is an array initiated solely for the purpose of taking the values of sum, currRow, currCol out of the method.
            temp[0] = sum;
            temp[1] = currRow;
            temp[2] = currCol;
            return temp;
        }
        static int[] DownLeft(bool[,] BoolArray, int[,] array, int steps, int currRow, int currCol, int[]temp)
        {
            int sum = 0;
            while (currCol > -1 && currRow < array.GetLength(0) && steps>0)
            {
                if (BoolArray[currRow, currCol] == false)
                {
                    sum += array[currRow, currCol];
                    BoolArray[currRow, currCol] = true;
                }
                steps--;
                if (steps != 0)
                {
                    currCol--;
                    currRow++;
                }
            }
            //if we go OutOfRange we go one step back in the direction where we came from.
            if (currCol < 0 || currRow > array.GetLength(0) - 1) { currRow--; currCol++; }
            //result comes as sum, currRow, currCol. temp is an array initiated solely for the purpose of taking the values of sum, currRow, currCol out of the method.
            temp[0] = sum;
            temp[1] = currRow;
            temp[2] = currCol;
            return temp;
        }
        static int[] DownRight(bool[,] BoolArray, int[,] array, int steps, int currRow, int currCol, int[] temp)
        {
            int sum = 0;
            while (currRow < array.GetLength(0) && currCol < array.GetLength(1) && steps>0)
            {
                if (BoolArray[currRow, currCol] == false)
                {
                    sum += array[currRow, currCol];
                    BoolArray[currRow, currCol] = true;
                }
                steps--;
                //next thing follows as if steps == 0, no move is made further
                if (steps != 0)
                {
                    currCol++;
                    currRow++;
                }
            }
            //if we go OutOfRange we go one step back in the direction where we came from.
            if (currCol > array.GetLength(1) - 1 || currRow > array.GetLength(0) - 1)
            {
                currRow--; currCol--;
            }
            //result comes as sum, currRow, currCol. temp is an array initiated solely for the purpose of taking the values of sum, currRow, currCol out of the method.
            temp[0] = sum;
            temp[1] = currRow;
            temp[2] = currCol;
            return temp;
        }

        static void FillingTheMatrix(int[,] array, int rows, int cols)
        {

            //the sides
            for (int i = rows - 1, multiplier = 0; i > -1; i--, multiplier++)
            {
                array[i, 0] = multiplier * 3;
            }
            //the bottom
            for (int i = 0; i < cols; i++)
            {
                array[rows - 1, i] = i * 3;
            }
            //the center fill
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    array[i, j] = array[i, 0] + array[rows - 1, j];
                }
            }


        }
    }
}
