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
                Sudoku sud = new Sudoku();
                ISudokuSolver localSolver = (ISudokuSolver)Activator.CreateInstance(item);

                var sud_one = sud.ParseFile(@"C:\Users\K\Documents\Work\CSharp\Sudoku_General\Benchmark\sudoku_files\Easy.txt")[0];

                var watch = System.Diagnostics.Stopwatch.StartNew();
                localSolver.Solve(sud_one);
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                Console.WriteLine(item.Name);
                Console.WriteLine(elapsedMs);
                Console.ReadKey();
            }
        }
    }
}
