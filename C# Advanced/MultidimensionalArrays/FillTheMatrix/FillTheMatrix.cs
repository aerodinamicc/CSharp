using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheMatrix
{
    class FillTheMatrix
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[,] array = new int[size, size];
            string Case = Console.ReadLine();

            //case A
            if (Case == "a")
            {
                int num = 1;
                for (int col = 0; col < size; col++)
                {

                    for (int row = 0; row < size; row++)
                    {
                        array[row, col] = num;
                        num++;
                    }
                }
            }

            
            //case 2
            if (Case == "b")
            {
                int num = 1;
                for (int col = 0; col < size; col++)
                {
                    if (col % 2 == 0)
                    {
                        for (int row = 0; row < size; row++)
                        {
                            array[row, col] = num;
                            num++;
                        }
                    }
                    else if (col % 2 == 1)
                    {
                        for (int row = size - 1; row >= 0; row--)
                        {
                            array[row, col] = num;
                            num++;
                        }
                    }
                }
            }
            //case 3
            if (Case == "c")
            { 
                int num = 1;
                int currRow = size - 1;
                int currCol = 0;
                while (currRow > -1 && currCol < size && num < size * size + 1)
                {
                    //additional variables that could be used inside the next loop
                    int rowCount = currRow;
                    int colCount = currCol;
                    while (rowCount < size && colCount < size)
                    {
                        array[rowCount, colCount] = num;
                        num++;
                        rowCount++;
                        colCount++;
                    }    
                    if (currRow > 0)
                    {
                        currRow--;
                    }
                    else
                    {
                        currCol++;
                    }
                }
            }
            //case 4
            if (Case == "d")
            {
                int num = 1;
                int currRow = 0;
                int currCol = 0;
                while (num < size*size+1)
                {
                    //going down
                    while (currRow < array.GetLength(0) && array[currRow, currCol] == 0)
                    {
                        array[currRow, currCol] = num;
                        //with the next step we might go out of boundaries and fail to enter the next itiration
                        currRow++;
                        num++;
                    }
                    //with the next two lines we correct for the OutOfRange value of currRow and go to the next cell in the sequence
                    currRow--;
                    currCol++;
                    //going right
                    while (currCol < array.GetLength(1) && array[currRow, currCol] == 0)
                    {
                        array[currRow, currCol] = num;
                        currCol++;
                        num++;
                    }
                    currRow--;
                    currCol--;
                    //going up
                    while (currRow > -1 && array[currRow, currCol] == 0)
                    {
                        array[currRow, currCol] = num;
                        currRow--;
                        num++;
                    }
                    currRow++;
                    currCol--;
                    //going left
                    while (currCol > -1 && array[currRow, currCol] == 0)
                    {
                        array[currRow, currCol] = num;
                        currCol--;
                        num++;
                    }
                    currRow++;
                    currCol++;

                }

            }
            //printing
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (col == size - 1)
                    {
                        Console.Write("{0}", array[row, col]);
                    }
                    else
                    {
                        Console.Write("{0} ", array[row, col]);
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
