using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TP3_csharpe.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SudokuLib.Sudoku sudo = new SudokuLib.Sudoku();

            SudokuLib.Sudoku sudok = new SudokuLib.Sudoku(sudo.ParseFile(@"C:\Users\Sven\Documents\Workspace\201906\Hard.txt")[0].CellsList);
            Console.WriteLine(sudok.ToString());
            Sudoku.solver_dancing_link solver = new Sudoku.solver_dancing_link();
            Console.WriteLine(solver.Solve(sudok).ToString());;

            Console.ReadLine();
        }
    }
}

