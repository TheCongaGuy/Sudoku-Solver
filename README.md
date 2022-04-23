# Sudoku-Solver
This project was the result of a challenge I found on [leetcode](https://leetcode.com/problems/sudoku-solver/ "Hard Sudoku Solver Challenge") that I just had to try. This was my first time re-creating a game in C#, and I learned quite a bit about how you can use arrays. I've always prefered `List<T>` in C#, but this coding excercise really flipped my perspective. It can solve any Sudoku board, as long as it has one exclusive solution. Otherwise, it will fill in any spaces with only one possible solution.
## Installation
If you would like to use my Grid class, all you need to do is download the Gameboard.cs file and add it to your C# project. It simulates a game of Sudoku with a grid of 9x9 numbers, initially set at 0.

The Program.cs file is just the main file used in my release build of Suduko Solver, if you would like to see how I used this class.

To run this command line program, extract the .zip file, and run the exe inside.
## Methods
- `.PrintGrid()`  This will print the current grid, seperating each 3x3 cell with a blank space
- `.SetPoint(value, x-coordinate, y-coordinate)`  This will set a value at a specified point, so long as it does not break Sudoku's rules
- `.CheckValue(value, x-coordinate, y-coordinate)`  This will check to see if a value, when placed at a given location, would break one of Sudoku's rules
