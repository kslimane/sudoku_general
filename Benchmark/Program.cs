using SudokuLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_General
{
    class Program
    {
        static void Main(string[] args)
        {

            var types = AppDomain.CurrentDomain.GetAssemblies()
             .SelectMany(s => s.GetTypes())
                .Where(p => typeof(SudokuLib.ISudokuSolver).IsAssignableFrom(p));
            foreach (Type item in types)
            {
                ISudokuSolver localSolver = (ISudokuSolver)Activator.CreateInstance(item);
                //localSolver.Solve()

            }


        }
    }
}
