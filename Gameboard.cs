using System;

namespace Sudoku_Solver
{
    /*
     * Grid Class simulates the grid board of Sudoku; a 9x9 board of numbers 1 - 9.
     * To win, all rows and collumns must be filled, but there are 3 rules
     * 1. No collumn may have repeating numbers
     * 2. No row may have repeating numbers
     * 3. No cluster (3x3 grid space) may have repeating numbers
     */
    class Grid
    {
        private readonly int[,] values = new int[9, 9];

        // Setup initial game board
        public Grid()
        {
            string[] input;
            int[] value;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Setup In Progress...\n");
                PrintGrid();
                Console.Write("Please input a value, with its coordinates 1-9 (value,x-cord,y-cord): ");

                // Record user input as an array of strings
                input = Console.ReadLine().Split(",");

                // Break the loop if input is null
                if (input[0] == "")
                    break;

                // Convert input to an integer array
                try
                {
                    value = new int[] { int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]) };
                } 
                // If there is an error, alert the user and continue the loop
                catch
                {
                    Console.WriteLine("Invalid Input. If you are done inputing values, press enter instead of a value");
                    Console.ReadKey();
                    continue;
                }

                // Set the point at that location
                SetPoint(value[0], value[1] - 1, value[2] - 1);
            }
        }

        // Accessor to the private value array
        public int[,] Values
        {
            get { return values; }
        }
            

        // Print the game board
        public void PrintGrid()
        {
            // For each x,y position in the grid, print it's value
            // Seperate the 3x3 grid spaces
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    Console.Write(values[y, x]);

                    // Seperate every group of 3 values
                    if ((x + 1) % 3 == 0)
                        Console.Write("\t");
                }

                // Once a row is completed, move on to the next row
                Console.WriteLine();

                // Seperate every group of 3 rows
                if ((y + 1) % 3 == 0)
                    Console.WriteLine();
            }
        }

        // Set a point on the game board with a value
        public void SetPoint(int value, int x, int y)
        {
            try
            {
                // If the value being set is 0; always set the value
                if (value == 0)
                    values[y, x] = value;

                // Otherwise; only set the value if it does not break Sudoku's rules
                else if (CheckValue(value, x, y))
                    values[y, x] = value;
            }
            // If there is an error; alert the user
            catch
            {
                Console.WriteLine("Invalid Index. Please keep your index between 1 - 9");
                Console.ReadKey();
            }
        }

        // Return true or false if a value at a position is legal
        public bool CheckValue(int value, int x, int y)
        {
            int yCorner, xCorner;

            for (int i = 0; i < 9; i++)
            {
                // If there is a repeat number in the row; end this funciton
                if (values[y, i] == value)
                    return false;

                // If there is a repeat number in the collumn; end this function
                if (values[i, x] == value)
                    return false;

                // Top right corner of a 3x3 group
                yCorner = (i / 3) + (y / 3) * 3;
                xCorner = (i % 3) + (x / 3) * 3;
                // If there is a repeat number in the 3x3 cluster; end this function
                if (values[yCorner, xCorner] == value)
                    return false;
            }

            return true;
        }
    }
}