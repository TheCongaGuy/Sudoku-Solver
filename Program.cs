using System;
using System.Collections.Generic;

namespace Sudoku_Solver
{
    class Program
    {
        static void Main()
        {
            bool changed;

            Grid example = new Grid();

            Console.Clear();

            Console.WriteLine("Initial Grid\n");
            example.PrintGrid();

            // Repeat this code until no additional changes are made
            do
            {
                changed = false;
                // For each grid point; if it only has one possible solution set it to that solution
                for (int y = 0; y < 9; y++)
                    for (int x = 0; x < 9; x++)
                    {
                        if (example.Values[y, x] == 0)
                        {
                            // List of possible values
                            List<int> possible = new List<int>(9);

                            // Check every number to see what possible numbers there are
                            for (int i = 1; i <= 9; i++)
                            {
                                if (example.CheckValue(i, x, y))
                                    possible.Add(i);
                            }

                            // If only one possible value exists, assign that value
                            if (possible.Count == 1)
                            {
                                example.SetPoint(possible[0], x, y);
                                changed = true;
                            }
                        }
                    }
            } while (changed);

            // Print the best possible grid of certain values
            Console.WriteLine("Best Possible Grid:\n");
            example.PrintGrid();
        }
    }
}
