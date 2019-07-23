using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLib
{
    public interface ISudokuSolver
    {
        Sudoku Solve(Sudoku sudoku);
    }

    public class SudokuSolver : ISudokuSolver
    {
        public Sudoku Solve(Sudoku s)
        {
            return new Sudoku();
        }
    }
}

